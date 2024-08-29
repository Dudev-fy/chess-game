using board;
using System;
using System.Collections.Generic;
using chess;

namespace chess_console {
    class Screen {
        public static void printMatch(ChessMatch match) {
            Screen.printBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Shift: " + match.shift);
            Console.WriteLine("Awaiting play: " + match.currentPlayer);
        }

        public static void printCapturedPieces(ChessMatch match) {
            Console.WriteLine("Captured pieces:");
            Console.Write("Whites: ");
            printCollection(match.getCapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Blacks: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printCollection(match.getCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printCollection(HashSet<Piece> collection) {
            Console.Write("[");
            foreach (Piece x in collection) {
                Console.Write(x + " ");
            }
            Console.Write("]");

        }
        public static void printBoard(Board board) {
            for (int i=0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j < board.columns; j++) {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i=0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j < board.columns; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void printPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}