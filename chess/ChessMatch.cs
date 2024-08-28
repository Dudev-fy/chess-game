using board;
using System;

namespace chess {
    class ChessMatch {
        public Board board { get; set; }
        private int shift;
        private Color currentPlayer;
        public bool isGameFinished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.White;
            isGameFinished = false;
            placePieces();
        }

        public void executeMovement(Position origin, Position destiny) {
            Piece p = board.withdrawPiece(origin);
            p.incrementQtdMovements();
            Piece takenPiece = board.withdrawPiece(destiny);
            board.placePiece(p, destiny);
        }

        private void placePieces() {
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(Color.Black, board), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Tower(Color.White, board), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(Color.White, board), new ChessPosition('d', 8).toPosition());
        }
    }
}