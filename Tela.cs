

using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    static class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("vez das : " + partida.JogadorAtual + "s");

        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab) 
        
        {

            for (int i = 0; i < tab.Linhas; i++) 
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < tab.Colunas; j++)
                {

      
                        imprimirPeca(tab.peca(i, j));
                
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   a b c d e f g h");
        
        }


        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPosiveis)
        {
            ConsoleColor fundoOrigem = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPosiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;

                    }
                    else 
                    {
                        Console.BackgroundColor = fundoOrigem;
                    
                    }

                   
                        imprimirPeca(tab.peca(i, j));
                        Console.BackgroundColor = fundoOrigem;
                    

                }

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = fundoOrigem;
        }




        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {

                Console.Write("- ");

            }
            else
            {

                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                    Console.Write(" ");
                }
                else
                {

                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(peca);
                    Console.Write(" ");
                    Console.ForegroundColor = aux;
                }
            }

         
        }

        public static PosicaoXadrez lerPosicaoXadrez() {

            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+"");

            return new PosicaoXadrez(coluna, linha);

           
        
        }
    }
}
