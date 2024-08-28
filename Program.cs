using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while (!match.isGameFinished) {

                    try {
                        Console.Clear();
                        Screen.printBoard(match.board);
                        Console.WriteLine();
                        Console.WriteLine("Shift: " + match.shift);
                        Console.WriteLine("Awaiting play: " + match.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool [,] possiblePositions = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.makePlay(origin, destiny);
                    }
                    catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
