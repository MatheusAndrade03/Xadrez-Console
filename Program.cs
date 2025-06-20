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
                    try
                    {
                        Console.Clear();

                        Tela.imprimirPartida(part);
                        Console.WriteLine();
                        

                        Console.WriteLine("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        part.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPosiveis = part.Tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(part.Tab, posicoesPosiveis);

                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        part.validarPosicaoDeDestino(origem,destino);


                        part.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }



            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
                
            }


        }
    }
}
