

namespace tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get;  protected set; }
        public Tabuleiro Tab { get; set; }


        public Peca(Posicao posicao, Cor cor, Tabuleiro tab) {
        
            this.Posicao = posicao;
            this.Cor = cor;
            this.Tab = tab;
            this.QtdMovimento = 0;
        }


    }
}
