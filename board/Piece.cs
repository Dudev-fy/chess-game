namespace board {
    abstract class Piece {
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

        public void decrementQtdMovements() {
            qtdMovements--;
        }

        public bool isTherePossibleMovements() {
            bool [,] mat = possibleMovements();
            for (int i=0; i<board.lines; i++) {
                for (int j=0; j<board.columns; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isMovePossible(Position pos) {
            return possibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMovements();
    }
}