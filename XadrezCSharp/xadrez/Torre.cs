using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{   
    // Extends;
    class Torre : Peca
    {

        // Construtor;
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        // Sobreposição;
        public override string ToString()
        {
            return "T";
        }
    }
}
