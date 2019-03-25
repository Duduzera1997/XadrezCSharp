using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    // Extends;
    class Rei : Peca
    {

        // Constutor;
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        // Sobreposição;
        public override string ToString()
        {
            return "R";
        }
    }
}
