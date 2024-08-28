using board;

namespace chess {
    class King : Piece {
        public King(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "K";
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
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //ne
            pos.defineValues(position.line - 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //right
            pos.defineValues(position.line, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //se
            pos.defineValues(position.line + 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //down
            pos.defineValues(position.line + 1, position.column);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //sw
            pos.defineValues(position.line + 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            } 
            //left
            pos.defineValues(position.line, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            //nw
            pos.defineValues(position.line - 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
            }
            return mat;    
        }
    }
}