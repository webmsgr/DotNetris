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
        private Piece peek1;
        private Piece peek2;
        private Piece peek3;

        public PiecePeekBag(PieceBag bag)
        {
            inner = bag;
            peek1 = inner.Next();
            peek2 = inner.Next();
            peek3 = inner.Next();
        }

        public Piece Peek()
        {
            return peek1;
        }

        public Piece PeekSecond()
        {
            return peek2;
        }

        public Piece PeekThird()
        {
            return peek3;
        }

        public Piece Next()
        {
            var next = peek1;
            peek1 = peek2;
            peek2 = peek3;
            peek3 = inner.Next();
            return next;
        }
    }
}
