using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public static class Compression
    {
        public static byte[] Zip(byte[] data)
        {
            using var ms = new System.IO.MemoryStream();
            using var ds = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
            ds.Write(data, 0, data.Length);
            ds.Close();
            return ms.ToArray();
        }

        public static byte[] Unzip(byte[] data)
        {
            using var ms = new System.IO.MemoryStream(data);
            using var ds = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);
            using var os = new System.IO.MemoryStream();
            ds.CopyTo(os);
            return os.ToArray();
        }
    }
}
