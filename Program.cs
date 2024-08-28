using System;
using board;

namespace chess {
    class Program {
        static void Main(string[] args) {
            try {
                Board board = new Board(8, 8);

                board.placePiece(new Tower(Color.Black, board), new Position(0, 0));
                board.placePiece(new Tower(Color.Black, board), new Position(1, 9));
                board.placePiece(new King(Color.Black, board), new Position(0, 2));

                Screen.printBoard(board);

            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
