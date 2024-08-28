using board;
using System;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isGameFinished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.White;
            isGameFinished = false;
            placePieces();
        }

        private void executeMovement(Position origin, Position destiny) {
            Piece p = board.withdrawPiece(origin);
            p.incrementQtdMovements();
            Piece takenPiece = board.withdrawPiece(destiny);
            board.placePiece(p, destiny);
        }

        public void makePlay(Position origin, Position destiny) {
            executeMovement(origin, destiny);
            shift++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("There is no piece on the selected position");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("Origin piece chosen is not yours");
            }
            if (!board.piece(pos).isTherePossibleMovements()) {
                throw new BoardException("There is no possible movements for chosen piece");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) {
            if (!board.piece(origin).canBeMovedTo(destiny)) {
                throw new BoardException("Invalid destiny position");
            }
        }

        private void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            }
            else {
                currentPlayer = Color.White;
            } 
        }

        private void placePieces() {
            board.placePiece(new Tower(Color.White, board), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Tower(Color.White, board), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(Color.White, board), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Tower(Color.Black, board), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Tower(Color.Black, board), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(Color.Black, board), new ChessPosition('d', 8).toPosition());
        }
    }
}