
using tabuleiro;
using Xadrez_Console.tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            colocaPecas();
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
        private void colocaPecas() {
            this.Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Amarela), new PosicaoXadrez('a', 8).toPosicao());
            this.Tab.colocarPeca(new Torre(Tab, Cor.Amarela), new PosicaoXadrez('h', 8).toPosicao());
            this.Tab.colocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            this.Tab.colocarPeca(new Rei(Tab, Cor.Amarela), new PosicaoXadrez('e', 8).toPosicao());
        }


        // Realiza a jogada 
        public void realizaJogada(Posicao origem, Posicao destino) {
        
            executarMovimento(origem, destino);
            this.Turno++;
            mudaJogador(JogadorAtual);
        
        }

        // valida a Posição de Origem
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        // valida a posição de destino
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }


        private void mudaJogador(Cor cor) {

            if (cor == Cor.Branca)
            {
                JogadorAtual = Cor.Amarela;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        
        }

    }
}
