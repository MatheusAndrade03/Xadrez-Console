
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
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        // executa o movimento das peças no jogo

        public void executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca peca = Tab.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
             Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(Tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
           

            colocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rainha(Tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
           
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


        // muda o jogador
        private void mudaJogador(Cor cor) {

            if (cor == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        
        }


        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


    }
}
