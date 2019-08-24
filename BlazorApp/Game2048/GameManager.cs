using System;
using System.Collections.Generic;
using System.Linq;

namespace Game2048
{
    public static class GameManager
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public static GameState GetNewGame(int size)
        {
            var squares = GetSquaresArray(size);
            squares = GenerateNewSquare(squares);
            squares = GenerateNewSquare(squares);
            return new GameState
            {
                IsMoved = false,
                IsStarted = false,
                Score = 0,
                Squares = squares
            };
        }

        public static SquareItem[][] GenerateNewSquare(SquareItem[][] squares)
        {
            var emptyCount = GetEmptySquaresCount(squares);
            if (emptyCount == 0)
                return squares;

            var nextPosition = GetRandomInt(0, emptyCount - 1);
            var nextNumber = GetRandomInt(0, 9) == 9 ? 4 : 2; // 10% chance for 4 to appear

            for (int i = 0; i != squares.Length; i++)
            {
                var row = squares[i];
                for (int j = 0; j != row.Length; j++)
                {
                    if (row[j] != null)
                    {
                        continue;
                    }

                    if (nextPosition == 0)
                    {
                        squares[i][j] = new SquareItem(nextNumber);
                        return squares;
                    }

                    nextPosition--;
                }
            }

            throw new Exception("Never get here. Mean it.");
        }

        public static SquareItem[][] Copy(SquareItem[][] squares)
        {
            return squares.Select(row => row.Select(SquareItem.Copy).ToArray()).ToArray();
        }

        public static SquareItem[][] GetSquaresArray(int size)
        {
            return Enumerable.Range(0, size)
                .Select(i => Enumerable.Range(0, size)
                    .Select(j => (SquareItem)null)
                    .ToArray())
                .ToArray();
        }

        private static int GetEmptySquaresCount(IReadOnlyCollection<SquareItem[]> squares)
        {
            return squares.Sum(r => r.Count(square => square == null));
        }

        private static int GetRandomInt(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
