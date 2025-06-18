
using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char Coluna { set; get; }
        public int Linha { set; get; }
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

    


        public Posicao toPosicao()
        {

            return new Posicao(8 - Linha, Coluna - 'a');

        }



    }
}
