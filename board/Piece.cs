namespace board {
    class Piece {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtdMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board) {
            this.board = board;
            this.position = null;
            this.color = color;
            this.qtdMovements = 0;
        }

        public void incrementQtdMovements() {
            qtdMovements++;
        }
    }
}