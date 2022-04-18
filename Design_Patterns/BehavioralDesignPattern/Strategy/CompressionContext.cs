using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Strategy
{
    public class CompressionContext
    {
        private ICompression Compression;

        public CompressionContext(ICompression Compression)
        {
            this.Compression = Compression;
        }
        public void SetStrategy(ICompression Compression)
        {
            this.Compression = Compression;
        }
        public void CreateArchive(string compressedArchiveFileName)
        {
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }
}
