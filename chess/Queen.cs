using board;

namespace chess {

    class Queen : Piece {

        public Queen(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "Q";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // left
            pos.defineValues(position.line, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line, pos.column - 1);
            }

            // right
            pos.defineValues(position.line, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line, pos.column + 1);
            }

            // up
            pos.defineValues(position.line - 1, position.column);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column);
            }

            // down
            pos.defineValues(position.line + 1, position.column);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column);
            }

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