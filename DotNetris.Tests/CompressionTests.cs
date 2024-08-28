using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris.Tests
{
    [TestClass()]
    public class CompressionTests
    {
        [TestMethod()]
        public void CompressionDecompressionWorks()
        {
            byte[] data = new byte[256];
            Random.Shared.NextBytes(data);
            byte[] compressed = Compression.Zip(data);
            byte[] decompressed = Compression.Unzip(compressed);
            CollectionAssert.AreEqual(data, decompressed);
        }

        
    }
}