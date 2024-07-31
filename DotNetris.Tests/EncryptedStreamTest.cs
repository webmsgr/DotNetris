using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetris.Network;

namespace DotNetris.Tests
{
    [TestClass]
    public class EncryptedStreamTest
    {
        [TestMethod]
        public void EncryptedStream_ReadWrite_Works()
        {
            MemoryStream stream = new MemoryStream(9);

            EncryptedStream one = new EncryptedStream(stream, "hehehe");
            EncryptedStream two = new EncryptedStream(stream, "hehehe");

            one.WriteChunk(new byte[] { 12, 34, 56, 78 }.AsSpan());
            stream.Position = 0;
            byte[] outBuf = two.ReadChunk();
            CollectionAssert.AreEqual(outBuf, new byte[] { 12, 34, 56, 78 });

            stream.Position = 0;
            two.WriteChunk(new byte[] { 11, 22, 33, 44 }.AsSpan());
            stream.Position = 0;
            outBuf = one.ReadChunk();
            CollectionAssert.AreEqual(outBuf.ToArray(), new byte[] { 11, 22, 33, 44 });
        }
    }
}
