using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game2048.Tests
{
    [TestClass]
    public class MoveHandlersTest
    {
        [DataTestMethod]
        [DataRow(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 0, 2 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 0, 2, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 0, 2, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 2, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 0, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 2, 0, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 0, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 0, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 0, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 2, 0, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 2, 0 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 2, 2 }, new[] { 0, 0, 4, 4 })]
        public void RightHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState {Squares = squares};
            AssignRows(state, numbers);
            
            var newState = MoveHelper.Handle("ArrowRight", state);

            AssertRows(newState, expectedAfterMove);
        }

        [DataTestMethod]
        [DataRow(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 0, 2 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 0, 2, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 0, 2, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 0, 2, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 0, 2, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 0, 0, 0 }, new[] { 0, 0, 0, 2 })]
        [DataRow(new[] { 2, 0, 0, 2 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 0, 2, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 0, 2, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 0, 0 }, new[] { 0, 0, 0, 4 })]
        [DataRow(new[] { 2, 2, 0, 2 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 2, 0 }, new[] { 0, 0, 2, 4 })]
        [DataRow(new[] { 2, 2, 2, 2 }, new[] { 0, 0, 4, 4 })]
        public void DownHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignColumns(state, numbers);

            var newState = MoveHelper.Handle("ArrowDown", state);

            AssertColumns(newState, expectedAfterMove);
        }

        [DataTestMethod]
        [DataRow(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 0, 2 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 2, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 2, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 0, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 2, 0, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 2, 0 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 2, 2 }, new[] { 4, 4, 0, 0 })]
        public void LeftHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignRows(state, numbers);

            var newState = MoveHelper.Handle("ArrowLeft", state);

            AssertRows(newState, expectedAfterMove);
        }

        [DataTestMethod]
        [DataRow(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 0, 2 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 2, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 0, 2, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 0, 2, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 0, 2 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 2, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 0, 2, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 0, 0 }, new[] { 4, 0, 0, 0 })]
        [DataRow(new[] { 2, 2, 0, 2 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 2, 0 }, new[] { 4, 2, 0, 0 })]
        [DataRow(new[] { 2, 2, 2, 2 }, new[] { 4, 4, 0, 0 })]
        public void UpHandlerTest(int[] numbers, int[] expectedAfterMove)
        {
            var squares = GameManager.GetSquaresArray(4);
            var state = new GameState { Squares = squares };
            AssignColumns(state, numbers);

            var newState = MoveHelper.Handle("ArrowUp", state);

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
                        Assert.IsNull(row[i]);
                    }
                    else
                    {
                        Assert.AreEqual(expectedNumber, row[i].Number);
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
                        Assert.IsNull(row[j]);
                    }
                    else
                    {
                        Assert.AreEqual(expectedNumber, row[j].Number);
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
