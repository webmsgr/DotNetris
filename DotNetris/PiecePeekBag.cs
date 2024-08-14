using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public class PiecePeekBag
    {
        private PieceBag inner;
        private Piece peek;

        public PiecePeekBag(PieceBag bag)
        {
            inner = bag;
            peek = inner.Next();
        }

        public Piece Peek()
        {
            return peek;
        }

        public Piece Next()
        {
            var next = peek;
            peek = inner.Next();
            return next;
        }
    }
}
