using System;

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
