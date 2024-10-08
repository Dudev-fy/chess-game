
using board;

namespace chess {

    class Bishop : Piece {

        public Bishop(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }
        
        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // nw
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column - 1);
            }

            // ne
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column + 1);
            }

            // se
            pos.defineValues(position.line + 1, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column + 1);
            }

            // sw
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
