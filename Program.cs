using tabuleiro;
using xadrez;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez part = new PartidaDeXadrez();

                while (!part.Terminada)
                {

                    Tela.ImprimirTabuleiro(part.Tab);
                    Console.WriteLine();

                    Console.WriteLine("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    part.executarMovimento(origem, destino);

                   
                }



            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
