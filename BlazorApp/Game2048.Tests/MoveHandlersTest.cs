using System;
using Xunit;

namespace Game2048.Tests
{
    public class MoveHandlersTest
    {
        [Theory]
        [InlineData(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 0, 2 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 0, 2, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 0, 2, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 2, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 0, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 2, 0, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 0, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 0, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 0, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 2, 0, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 2, 0 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 2, 2 }, new[] { 0, 0, 4, 4 })]
        public void RightHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState {Squares = squares};
            AssignRows(state, numbers);
            
            var newState = MoveHelper.HandleRight(state);

            AssertRows(newState, expectedAfterMove);
        }

        [Theory]
        [InlineData(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 0, 2 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 0, 2, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 0, 2, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 0, 2, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 0, 2, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 0, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [InlineData(new[] { 2, 0, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 0, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 0, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 0, 0 }, new[] { 0, 0, 0, 4 })]
        [InlineData(new[] { 2, 2, 0, 2 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 2, 0 }, new[] { 0, 0, 2, 4 })]
        [InlineData(new[] { 2, 2, 2, 2 }, new[] { 0, 0, 4, 4 })]
        public void DownHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignColumns(state, numbers);

            var newState = MoveHelper.HandleDown(state);

            AssertColumns(newState, expectedAfterMove);
        }

        [Theory]
        [InlineData(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 0, 2 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 2, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 2, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 0, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 2, 0, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 2, 0 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 2, 2 }, new[] { 4, 4, 0, 0 })]
        public void LeftHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignRows(state, numbers);

            var newState = MoveHelper.HandleLeft(state);

            AssertRows(newState, expectedAfterMove);
        }

        [Theory]
        [InlineData(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 0, 2 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 2, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 0, 2, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 0, 2, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 0, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 0, 0 }, new[] { 4, 0, 0, 0 })]
        [InlineData(new[] { 2, 2, 0, 2 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 2, 0 }, new[] { 4, 2, 0, 0 })]
        [InlineData(new[] { 2, 2, 2, 2 }, new[] { 4, 4, 0, 0 })]
        public void UpHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignColumns(state, numbers);

            var newState = MoveHelper.HandleUp(state);

            AssertColumns(newState, expectedAfterMove);
        }

        private static void AssertRows(GameState state, int[] expectedNumbers)
        {
            foreach (var row in state.Squares)
            {
                for (var i = 0; i < expectedNumbers.Length; i++)
                {
                    var expectedNumber = expectedNumbers[i];
                    if (expectedNumber == 0)
                    {
                        Assert.Null(row[i]);
                    }
                    else
                    {
                        Assert.Equal(expectedNumber, row[i].Number);
                    }
                }
            }
        }

        private static void AssertColumns(GameState state, int[] expectedNumbers)
        {
            for (var i = 0; i < state.Squares.Length; i++)
            {
                var row = state.Squares[i];
                var expectedNumber = expectedNumbers[i];
                for (var j = 0; j < expectedNumbers.Length; j++)
                {
                    if (expectedNumber == 0)
                    {
                        Assert.Null(row[j]);
                    }
                    else
                    {
                        Assert.Equal(expectedNumber, row[j].Number);
                    }
                }
            }
        }

        private static GameState AssignColumns(GameState state, int[] numbers)
        {
            for (var i = 0; i < state.Squares.Length; i++)
            {
                var row = state.Squares[i];
                var number = numbers[i];
                for (var j = 0; j < numbers.Length; j++)
                {
                    if (number != 0)
                    {
                        row[j] = new SquareItem(number);
                    }
                }
            }

            return state;
        }

        private static GameState AssignRows(GameState state, int[] numbers)
        {
            foreach (var row in state.Squares)
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                    var number = numbers[i];
                    if (number != 0)
                    {
                        row[i] = new SquareItem(number);
                    }
                }
            }

            return state;
        }
    }
}
