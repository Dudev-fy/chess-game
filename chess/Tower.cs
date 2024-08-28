using board;

namespace chess {
    class Tower : Piece {
        public Tower(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "T";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(position.line - 1, position.column);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.line = pos.line - 1;
            }
            //down
            pos.defineValues(position.line + 1, position.column);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.line = pos.line + 1;
            }
            //right
            pos.defineValues(position.line, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column + 1;
            }
            //left
            pos.defineValues(position.line, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;    
        }
    }
}