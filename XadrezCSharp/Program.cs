using System;
using Tabuleiro;

namespace XadrezCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao pos = new Posicao(5, 6);

            Console.WriteLine("Position: " + pos);

            Console.ReadLine();
        }
    }
}
