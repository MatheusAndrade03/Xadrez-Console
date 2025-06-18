

using Xadrez_Console.tabuleiro;

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

        // métodos ....................................................................

        // Retorna 1 peça 

        public Peca peca(int linha , int coluna) {

            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos) {

            return pecas[pos.Linha, pos.Coluna];
        }

        // Coloca 1 Peça no Tabuleiro
        public void colocarPeca(Peca p , Posicao pos) {

            if (existPeca(pos)) 
            {
                throw new TabuleiroException("já existe uma peça nesta posição, "+pos);
            }

            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        // identifica se a posição informada é valida
        public bool posicaoValida(Posicao pos) {

            if(pos.Linha<0 || pos.Linha>= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) return false;

            return true;
        }

        // Gera uma mensagem caso a posição seja invalida
        public void validarPosicao(Posicao pos) 
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida, "+pos);
                
            }
        }


        // veificar se existe uma peça na posição 

        public bool existPeca(Posicao pos)
        {
            validarPosicao (pos);

            if (peca(pos) != null)
            {
                return true;
            }
            
            return false;
       
        }




    }
}
