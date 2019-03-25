using System;
using System.Collections.Generic;
using System.Text;

namespace exceptions
{
    class TabuleiroException : Exception
    {   
        // Método para lançar uma mensagem de exceção customizada;
        public TabuleiroException(string msg) : base(msg)
        {

        }
    }
}
