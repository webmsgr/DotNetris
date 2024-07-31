using System.Drawing;
using System.Text;
using Geralt;

namespace DotNetris.Network;

public class EncryptedStream
{
    private static byte[] salt = Encoding.UTF8.GetBytes("wow encryption!!");

    private Stream inner;

    private byte[] password;

    private IncrementalXChaCha20Poly1305? writer;
    private IncrementalXChaCha20Poly1305? reader;


    private const int BUFFER_SIZE = 64 * 1024;
    private byte[] buffer;
    private int bufferFullness;


    private void readBuffer(Span<byte> buf)
    {
        int size = buf.Length;
        Console.Out.WriteLine(size);
        buffer[..size].CopyTo(buf);
        Buffer.BlockCopy(buffer, size, buffer, 0, BUFFER_SIZE - size);
        bufferFullness -= size;

    }

    public EncryptedStream(Stream inner, byte[] password)
    {
        this.inner = inner;
        this.password = password;
        this.buffer = new byte[BUFFER_SIZE];
        this.bufferFullness = 0;
    }

    public EncryptedStream(Stream inner, string password)
    {
        this.inner = inner;
        this.password = Encoding.UTF8.GetBytes(password);
        this.buffer = new byte[BUFFER_SIZE];
        this.bufferFullness = 0;
    }
    /// <summary>
    /// Writes a single chunk of data to the inner stream. One call to ReadChunk will read all data from one call to WriteChunk.
    /// </summary>
    /// <param name="data">Data to write</param>
    public void WriteChunk(ReadOnlySpan<byte> data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reads a single chunk of data from the inner stream. Contains the data from one call to WriteChunk.
    /// </summary>
    /// <returns>A single chunk of data</returns>
    public byte[] ReadChunk()
    {
        throw new NotImplementedException();
    }

    internal void _Read(Span<byte> data)
    {
        // firstly, copy as much from the buffer to data as we can
        int bufAmtToCopy = Math.Min(data.Length, bufferFullness);
        int dataLeftInSpan = data.Length - bufAmtToCopy;
        if (bufAmtToCopy != 0)
        {
            buffer[..bufAmtToCopy].CopyTo(data[..bufAmtToCopy]);
            // copy the buffer left 
            Console.Out.WriteLine($"Copied {bufAmtToCopy} bytes from the buffer");
            bufferFullness -= bufAmtToCopy;
        }
        // now, fill the rest with oh boy data!
        while (dataLeftInSpan != 0)
        {
            Console.Out.WriteLine($"Data left {dataLeftInSpan} bytes. buffer is {bufferFullness}/{BUFFER_SIZE} bytes full");
            
            int readAmt = inner.ReadAtLeast(buffer.AsSpan().Slice(bufferFullness), dataLeftInSpan);
            if (readAmt == 0)
            {
                throw new EndOfStreamException("Stream ended before span could be filled");
            }
            Console.Out.WriteLine($"Read {readAmt} bytes");
            bufferFullness += readAmt;
            int dataToShiftOut = Math.Min(bufferFullness, dataLeftInSpan);
            Console.Out.WriteLine($"Shifting out {dataToShiftOut} bytes from the read to out");
            int offset = data.Length - dataLeftInSpan;
            Console.Out.WriteLine($"Copying to {offset}..{offset + dataToShiftOut}");
            readBuffer(data[offset..(offset + dataToShiftOut)]);
            dataLeftInSpan -= dataToShiftOut;

        }
        
    }
    
}