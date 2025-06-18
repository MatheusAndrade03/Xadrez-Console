

namespace tabuleiro
{
    internal class Tabuleiro
    {

        public int Colunas { get; set; }
        public int Linhas { get; set; }

        private Peca[,] pecas;


        public Tabuleiro(int colunas , int linhas) {

            this.Colunas = colunas;
            this.Linhas = linhas;

            this.pecas = new Peca[colunas,linhas];
        }

        // Retorna 1 peça 

        public Peca peca(int linha , int coluna) {

            return pecas[linha, coluna];
        
        }
    }
}
