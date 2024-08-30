using board;

namespace chess {

    class Pawn : Piece {
        public Pawn(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "P";
        }

        private bool isThereAnEnemy(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool isFree(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White) {
                pos.defineValues(position.line - 1, position.column);
                if (board.isPositionValid(pos) && isFree(pos)) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (board.isPositionValid(p2) && isFree(p2) && board.isPositionValid(pos) && isFree(pos) && qtdMovements == 0) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line - 1, position.column - 1);
                if (board.isPositionValid(pos) && isThereAnEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line - 1, position.column + 1);
                if (board.isPositionValid(pos) && isThereAnEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }
            }
            else {
                pos.defineValues(position.line + 1, position.column);
                if (board.isPositionValid(pos) && isFree(pos)) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (board.isPositionValid(p2) && isFree(p2) && board.isPositionValid(pos) && isFree(pos) && qtdMovements == 0) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line + 1, position.column - 1);
                if (board.isPositionValid(pos) && isThereAnEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line + 1, position.column + 1);
                if (board.isPositionValid(pos) && isThereAnEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }
            }

            return mat;
        }
    }
}