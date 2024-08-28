using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Geralt;

namespace DotNetris.Network;

/// <summary>
/// Wraps a stream to allow reading/writing of chunks, with optional encryption.
/// </summary>
public class ChunkedStream: IDisposable
{
    
    /// <summary>
    /// How many chunks before a ReKey.
    /// </summary>
    private const int chunksPerRekey = 16;
    
    /// <summary>
    /// Hardcoded salt to use. Can't be random because the connectionKey needs to be the same on both client and server.
    /// </summary>
    private static byte[] salt = "wow encryption!!"u8.ToArray();

    /// <summary>
    /// The inner stream to wrap
    /// </summary>
    private Stream inner;
    
    /// <summary>
    /// The key used to establish encryption
    /// </summary>
    private byte[] connectionKey = new byte[IncrementalXChaCha20Poly1305.KeySize + IncrementalXChaCha20Poly1305.HeaderSize];
    //private byte[] salt;
    
    /// <summary>
    /// How many chunks this stream has left before a rekey.
    /// </summary>
    private int chunksUntilRekey = chunksPerRekey;

    private IncrementalXChaCha20Poly1305? writer;
    private IncrementalXChaCha20Poly1305? reader;

    public ChunkedStream(Stream inner, byte[] password)
    {
        this.inner = inner;
        DeriveKey(password);
    }

    public ChunkedStream(Stream inner, string password)
    {
        this.inner = inner;
        DeriveKey(Encoding.UTF8.GetBytes(password));
    }

    public ChunkedStream(Stream inner)
    {
        this.inner = inner;
    }

    private void DeriveKey(ReadOnlySpan<byte> password)
    {
        //connectionKey = new byte[IncrementalXChaCha20Poly1305.KeySize + IncrementalXChaCha20Poly1305.HeaderSize];
        //Span<byte> salt = stackalloc byte[Argon2id.SaltSize];
        //SecureRandom.Fill(salt);
        // this needs to be deterministic. Both sides need the same connectionKey
        Argon2id.DeriveKey(connectionKey, password, salt, Crypto.Argon2IdIterations, Crypto.Argon2IdMemorySize);
    }
    
    /// <summary>
    /// Establish encryption with the provided password. If no password was provided, the key exchange is not encrypted.
    /// </summary>
    public void EstablishEncryption()
    {
        WriteEncryptionChunk();
        ReadDecryptionChunk();
    }
    /// <summary>
    /// Writes the encryption chunk, and sets up writing encryption. Any calls to WriteChunk after this will be encrypted.
    /// </summary>
    internal void WriteEncryptionChunk()
    {
        Span<byte> header = stackalloc byte[IncrementalXChaCha20Poly1305.HeaderSize];
        Span<byte> key = stackalloc byte[IncrementalXChaCha20Poly1305.KeySize];
        SecureRandom.Fill(key);
        IncrementalXChaCha20Poly1305 newWriter = new IncrementalXChaCha20Poly1305(false, header, key);
        // yay!
        Span<byte> chunk =
            stackalloc byte[IncrementalXChaCha20Poly1305.HeaderSize + IncrementalXChaCha20Poly1305.KeySize];
        Geralt.Spans.Concat(chunk, header, key);
        if (chunk.Length != connectionKey.Length)
        {
            // uh oh
            throw new Exception("connectionKey.Length != chunk.Length");
        }

        // XOR with connectionKey
        // connectionKey is kind of like a one-time-pad except its not.
        for (int ptr = 0; ptr < connectionKey.Length; ptr++)
        {
            chunk[ptr] ^= connectionKey[ptr];
        }
        WriteChunk(chunk); // write the stuff
        writer = newWriter; // enable encryption from here on.
        WriteChunk(new byte[] { 0xDE, 0xAD, 0xBE, 0xEF }); // write magic encryption chunk
    }
    /// <summary>
    /// Reads a chunk from the stream and uses that to enable decryption. Any calls to ReadChunk after this will be decrypted.
    /// </summary>
    internal void ReadDecryptionChunk()
    {
        byte[] data = ReadChunk();
        // decrypt chunk with our key
        for (int ptr = 0; ptr < connectionKey.Length; ptr++)
        {
            data[ptr] ^= connectionKey[ptr];
        }
        // split it into our header and key
        Span<byte> header = data.AsSpan(0, IncrementalXChaCha20Poly1305.HeaderSize);
        Span<byte> key = data.AsSpan(IncrementalXChaCha20Poly1305.HeaderSize);
        // enable decryption
        reader = new IncrementalXChaCha20Poly1305(true, header, key);
        byte[] magic = ReadChunk(); // should be 0xDEADBEEF
        if (magic[0] != 0xDE || magic[1] != 0xAD || magic[2] != 0xBE || magic[3] != 0xEF)
        {
            throw new CryptographicException("Invalid password was used to create ChunkedStream");
        }
        
    }

    /// <summary>
    /// Writes a single chunk of data to the inner stream. One call to ReadChunk will read all data from one call to WriteChunk.
    /// </summary>
    /// <param name="data">Data to write</param>
    public void WriteChunk(ReadOnlySpan<byte> data)
    {
        if (writer != null)
        {
            Span<byte> encryptedData = new byte[data.Length + IncrementalXChaCha20Poly1305.TagSize];
            if (chunksUntilRekey == 0)
            {
                chunksUntilRekey = chunksPerRekey;
                writer.Push(encryptedData, data, IncrementalXChaCha20Poly1305.ChunkFlag.Rekey);
            }
            else
            {
                writer.Push(encryptedData, data);
            }
            
            data = encryptedData;
        }
        byte[] length = BitConverter.GetBytes(data.Length);
        if (BitConverter.IsLittleEndian)
        {
            length.AsSpan().Reverse();
        }
        inner.Write(length, 0, length.Length);
        inner.Write(data);
    }

    /// <summary>
    /// Reads a single chunk of data asyncly from the inner stream. Contains the data from one call to WriteChunk.
    /// </summary>
    /// <returns>A single chunk of data</returns>
    public async Task<byte[]> ReadChunkAsync(CancellationToken token)
    {
        // read the length bytes
        byte[] lengthBytes = new byte[4];
        await inner.ReadExactlyAsync(lengthBytes, token);
        if (token.IsCancellationRequested)
        {
            return [];
        }
        if (BitConverter.IsLittleEndian)
        {
            lengthBytes = lengthBytes.Reverse().ToArray();
        }
        int length = BitConverter.ToInt32(lengthBytes);


        byte[] packetData = new byte[length];
        await inner.ReadExactlyAsync(packetData, token);
        if (token.IsCancellationRequested)
        {
            return [];
        }
        if (reader != null)
        {
            byte[] decryptedData = new byte[packetData.Length - IncrementalXChaCha20Poly1305.TagSize];
            reader.Pull(decryptedData, packetData);
            return decryptedData;
        }
        else
        {
            return packetData.ToArray();
        }
    }
    
    /// <summary>
    /// Reads a single chunk of data from the inner stream. Contains the data from one call to WriteChunk.
    /// </summary>
    /// <returns>A single chunk of data</returns>
    public byte[] ReadChunk()
    {
        // allocate a kilobyte buffer.
        // ideally we would reuse this for the packet data, but if we have more than 1024 bytes then we need to reallocate
        // yayayay
        Span<byte> data = stackalloc byte[1024]; // the stack should be big enough for a kilobyte lol
        // read the length bytes
        Span<byte> lengthBytes = data[..4];
        inner.ReadExactly(lengthBytes);
        if (BitConverter.IsLittleEndian)
        {
            lengthBytes.Reverse();
        }
        int length = BitConverter.ToInt32(lengthBytes);
        if (length > 1024)
        {
            data = new byte[length]; // ensure its big enough (and put it on the heap)
        }

        Span<byte> packetData = data[..length];
        inner.ReadExactly(packetData);
        if (reader != null)
        {
            byte[] decryptedData = new byte[packetData.Length - IncrementalXChaCha20Poly1305.TagSize];
            reader.Pull(decryptedData, packetData);
            return decryptedData;
        }
        else
        {
            return packetData.ToArray();
        }
    }

    public void Dispose()
    {
        inner.Dispose(); // make sure its gone
        writer?.Dispose();
        reader?.Dispose();
    }
}