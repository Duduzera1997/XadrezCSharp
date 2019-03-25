using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class Posicao
    {

        public int line { get; set; }
        public int column { get; set; }


        public Posicao(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        public override string ToString()
        {
            return this.line + ", " + this.column;
        }
    }
}
