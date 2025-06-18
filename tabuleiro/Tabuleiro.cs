

namespace tabuleiro
{
    internal class Tabuleiro
    {

        public int Colunas { get; set; }
        public int Linhas { get; set; }

        public Peca[,] Pecas;


        public Tabuleiro(int colunas , int linhas) {

            this.Colunas = colunas;
            this.Linhas = linhas;

            this.Pecas = new Peca[colunas,linhas];
        }
    }
}
