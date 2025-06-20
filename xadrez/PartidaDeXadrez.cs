
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int _turno;
        private Cor _corJogador;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            _turno = 1;
            _corJogador = Cor.Branca;
            colocarPecas();
            Terminada = false;
        }

        // executa o movimento das peças no jogo

        public void executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca peca = Tab.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
             Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(peca, destino);
        }

        private void colocarPecas() 
        {
            this.Tab.colocarPeca(new Torre(Tab,Cor.Branca), new PosicaoXadrez('a',1).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Amarela), new PosicaoXadrez('a', 8).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Amarela), new PosicaoXadrez('h', 8).toPosicao());
            this.Tab.colocarPeca(new Rei(Tab,Cor.Branca), new PosicaoXadrez('e',1).toPosicao());
            this.Tab.colocarPeca(new Rei(Tab, Cor.Amarela), new PosicaoXadrez('e',8).toPosicao());
            this.Tab.colocarPeca(new Cavalo(Tab,Cor.Branca),new PosicaoXadrez('b',1).toPosicao());
            this.Tab.colocarPeca(new Cavalo(Tab, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());
            this.Tab.colocarPeca(new Cavalo(Tab, Cor.Amarela), new PosicaoXadrez('b', 8).toPosicao());
            this.Tab.colocarPeca(new Cavalo(Tab, Cor.Amarela), new PosicaoXadrez('g', 8).toPosicao());
            this.Tab.colocarPeca(new Bispo(Tab,Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
            this.Tab.colocarPeca(new Bispo(Tab, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
            this.Tab.colocarPeca(new Bispo(Tab, Cor.Amarela), new PosicaoXadrez('c', 8).toPosicao());
            this.Tab.colocarPeca(new Bispo(Tab, Cor.Amarela), new PosicaoXadrez('f', 8).toPosicao());
            this.Tab.colocarPeca(new Rainha(Tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
            this.Tab.colocarPeca(new Rainha(Tab, Cor.Amarela), new PosicaoXadrez('d', 8).toPosicao());
        }




    }
}
