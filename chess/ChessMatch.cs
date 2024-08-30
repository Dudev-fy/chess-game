using board;
using System.Collections.Generic;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isGameFinished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch() {
            board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.White;
            isGameFinished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            placePieces();
        }

        private void executeMovement(Position origin, Position destiny) {
            Piece p = board.withdrawPiece(origin);
            p.incrementQtdMovements();
            Piece takenPiece = board.withdrawPiece(destiny);
            board.placePiece(p, destiny);
            if (takenPiece != null) {
                capturedPieces.Add(takenPiece);
            }
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

        public HashSet<Piece> getCapturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> getInGamePieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(getCapturedPieces(color));
            return aux;
        }

        private void placeNewPiece(char column, int line, Piece piece) {
            board.placePiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void placePieces() {
            placeNewPiece('a', 1, new Tower(Color.White, board));
            placeNewPiece('b', 1, new Horse(Color.White, board));
            placeNewPiece('c', 1, new Bishop(Color.White, board));
            placeNewPiece('d', 1, new Queen(Color.White, board));
            placeNewPiece('e', 1, new King(Color.White, board));
            placeNewPiece('f', 1, new Bishop(Color.White, board));
            placeNewPiece('g', 1, new Horse(Color.White, board));
            placeNewPiece('h', 1, new Tower(Color.White, board));
            placeNewPiece('a', 2, new Pawn(Color.White, board));
            placeNewPiece('b', 2, new Pawn(Color.White, board));
            placeNewPiece('c', 2, new Pawn(Color.White, board));
            placeNewPiece('d', 2, new Pawn(Color.White, board));
            placeNewPiece('e', 2, new Pawn(Color.White, board));
            placeNewPiece('f', 2, new Pawn(Color.White, board));
            placeNewPiece('g', 2, new Pawn(Color.White, board));
            placeNewPiece('h', 2, new Pawn(Color.White, board));

            placeNewPiece('a', 8, new Tower(Color.Black, board));
            placeNewPiece('b', 8, new Horse(Color.Black, board));
            placeNewPiece('c', 8, new Bishop(Color.Black, board));
            placeNewPiece('d', 8, new Queen(Color.Black, board));
            placeNewPiece('e', 8, new King(Color.Black, board));
            placeNewPiece('f', 8, new Bishop(Color.Black, board));
            placeNewPiece('g', 8, new Horse(Color.Black, board));
            placeNewPiece('h', 8, new Tower(Color.Black, board));
            placeNewPiece('a', 7, new Pawn(Color.Black, board));
            placeNewPiece('b', 7, new Pawn(Color.Black, board));
            placeNewPiece('c', 7, new Pawn(Color.Black, board));
            placeNewPiece('d', 7, new Pawn(Color.Black, board));
            placeNewPiece('e', 7, new Pawn(Color.Black, board));
            placeNewPiece('f', 7, new Pawn(Color.Black, board));
            placeNewPiece('g', 7, new Pawn(Color.Black, board));
            placeNewPiece('h', 7, new Pawn(Color.Black, board));
        }
    }
}