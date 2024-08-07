using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DotNetris.Network;
using Geralt;

namespace DotNetris.Tests
{
    [TestClass]
    public class ChunkedStreamTest
    {
        [TestMethod]
        public void ChunkedStream_ReadWrite_Works()
        {
            MemoryStream stream = new MemoryStream(9);

            ChunkedStream one = new ChunkedStream(stream);
            ChunkedStream two = new ChunkedStream(stream);

            one.WriteChunk(new byte[] { 12, 34, 56, 78 }.AsSpan());
            one.WriteChunk(new byte[] { 99, 44, 22, 11 }.AsSpan());
            stream.Position = 0;
            byte[] outBuf = two.ReadChunk();
            CollectionAssert.AreEqual(outBuf, new byte[] { 12, 34, 56, 78 });
            outBuf = two.ReadChunk();
            CollectionAssert.AreEqual(outBuf, new byte[] { 99, 44, 22, 11 });

            stream.Position = 0;
            two.WriteChunk(new byte[] { 11, 22, 33, 44 }.AsSpan());
            two.WriteChunk(new byte[] { 99, 44, 22, 11 }.AsSpan());
            stream.Position = 0;
            outBuf = one.ReadChunk();
            CollectionAssert.AreEqual(outBuf.ToArray(), new byte[] { 11, 22, 33, 44 });
            outBuf = one.ReadChunk();
            CollectionAssert.AreEqual(outBuf.ToArray(), new byte[] { 99, 44, 22, 11 });
        }

        [TestMethod]
        public void ChunkedStream_ReadWriteBigData_Works()
        {
            MemoryStream stream = new MemoryStream(4096);

            ChunkedStream one = new ChunkedStream(stream);
            ChunkedStream two = new ChunkedStream(stream);
            byte[] data = new byte[2048];
            SecureRandom.Fill(data); // not fast
            
            one.WriteChunk(data);
            stream.Position = 0;
            byte[] readData = two.ReadChunk();
            
            CollectionAssert.AreEqual(data, readData);

        }

        [TestMethod]
        public void ChunkedStream_ReadWriteEncryptedLargeData_Works()
        {
            MemoryStream stream = new MemoryStream(4096);

            ChunkedStream one = new ChunkedStream(stream, "password");
            ChunkedStream two = new ChunkedStream(stream, "password");
            // we gotta leap frog the encryption setup because memorystream
            one.WriteEncryptionChunk();
            stream.Position = 0;
            two.ReadDecryptionChunk();
            stream.Position = 0;
            two.WriteEncryptionChunk();
            stream.Position = 0;
            one.ReadDecryptionChunk();
            stream.Position = 0;
            
            // now we should be able to read write encrypted data
            byte[] data = new byte[2048];
            SecureRandom.Fill(data); // not fast
            
            one.WriteChunk(data);
            stream.Position = 0;
            byte[] readData = two.ReadChunk();
            
            CollectionAssert.AreEqual(data, readData);
        }
        
        [TestMethod]
        public void ChunkedStream_ReadWriteEncrypted_Works()
        {
            MemoryStream stream = new MemoryStream(1024);

            ChunkedStream one = new ChunkedStream(stream, "password");
            ChunkedStream two = new ChunkedStream(stream, "password");
            // we gotta leap frog the encryption setup because memorystream
            one.WriteEncryptionChunk();
            stream.Position = 0;
            two.ReadDecryptionChunk();
            stream.Position = 0;
            two.WriteEncryptionChunk();
            stream.Position = 0;
            one.ReadDecryptionChunk();
            stream.Position = 0;
            
            // now we should be able to read write encrypted data
            one.WriteChunk(new byte[] { 12, 34, 56, 78 }.AsSpan());
            one.WriteChunk(new byte[] { 99, 44, 22, 11 }.AsSpan());
            stream.Position = 0;
            byte[] outBuf = two.ReadChunk();
            CollectionAssert.AreEqual(outBuf, new byte[] { 12, 34, 56, 78 });
            outBuf = two.ReadChunk();
            CollectionAssert.AreEqual(outBuf, new byte[] { 99, 44, 22, 11 });
            
            stream.Position = 0;
            two.WriteChunk(new byte[] { 11, 22, 33, 44 }.AsSpan());
            two.WriteChunk(new byte[] { 99, 44, 22, 11 }.AsSpan());
            stream.Position = 0;
            outBuf = one.ReadChunk();
            CollectionAssert.AreEqual(outBuf.ToArray(), new byte[] { 11, 22, 33, 44 });
            outBuf = one.ReadChunk();
            CollectionAssert.AreEqual(outBuf.ToArray(), new byte[] { 99, 44, 22, 11 });
        }

        [TestMethod]
        public void ChunkedStream_ReadWriteEncryptedTCP_Works()
        {
            ushort port = 19743; // shouldn't be in use (i hope)
            int timesToCheck = 32;
            Thread server = new Thread(() =>
            {
                TcpListener channel = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                channel.Start();
                TcpClient client = channel.AcceptTcpClient();
                ChunkedStream stream = new ChunkedStream(client.GetStream(), "password1234");
                
                stream.EstablishEncryption();
                for (int i = 0; i < timesToCheck; i++)
                {
                    byte[] data = stream.ReadChunk().Reverse().ToArray();
                    stream.WriteChunk(data);
                }
            });
            server.Start();
            
            TcpClient client = new();
            client.Connect(IPAddress.Parse("127.0.0.1"), port);
            ChunkedStream stream = new ChunkedStream(client.GetStream(), "password1234");
            stream.EstablishEncryption();
            byte[] data = new byte[2048];
            for (int i = 0; i < timesToCheck; i++)
            {
                SecureRandom.Fill(data);
                // write our random data
                stream.WriteChunk(data);
                
                data = data.Reverse().ToArray();
                // read the reversed data from the server
                byte[] recvChunk = stream.ReadChunk();
                // check the data was actually reversed.
                CollectionAssert.AreEqual(data, recvChunk);
                Console.Out.WriteLine($"CLIENT: Successfully read chunk {i}");
            }
            // do client stuff
            server.Join();
            
        }
        
    }
}
