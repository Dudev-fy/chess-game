using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                Screen.printBoard(match.board);

            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
