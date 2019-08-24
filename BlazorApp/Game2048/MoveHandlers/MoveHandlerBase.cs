using System.Collections.Generic;

namespace Game2048.MoveHandlers
{
    internal abstract class MoveHandlerBase : IMoveHandler
    {
        public GameState Handle(GameState state)
        {
            if (!CanMove(state))
            {
                state.IsMoved = false;
                return state;
            }

            var squares = GameManager.Copy(state.Squares);
            var score = state.Score;
            var length = squares.Length;

            for (int i = 0; i != length; i++)
            {
                var row = new RowObject(length);

                for (int j = length - 1; j >= 0; j--)
                {
                    var item  = this[squares, i, j];
                    if (item == null)
                        continue;

                    item.IsNew = false;
                    item.IsMerged = false;
                    if (row.TryMerge(item, out var mergeScore))
                    {
                        score += mergeScore;
                    }
                }

                for (int j = 0; j != length; j++)
                {
                    this[squares, i, j] = row.Items[j];
                }
            }

            (state.IsStarted, state.IsMoved, state.Squares, state.Score) = (true, true, squares, score);
            return state;
        }

        protected abstract SquareItem this[SquareItem[][] squares, int i, int j] { get; set; }

        private bool CanMove(GameState state)
        {
            var squares = state.Squares;
            var length = squares.Length;
            for (int i = 0; i != length; i++)
            {
                int j = 0;
                while (j < length - 1)
                {
                    var startItem = this[squares, i, j];
                    var endItem = this[squares, i, j + 1];

                    if (startItem == null)
                    {
                        j++;
                        continue;
                    }

                    if (endItem == null)
                    {
                        return true;
                    }

                    if (startItem.Number == endItem.Number)
                    {
                        return true;
                    }

                    j++;
                }
            }

            return false;
        }

        private class RowObject
        {
            private int Length { get; }

            public SquareItem[] Items { get; }

            private int Occupied { get; set; }

            private ICollection<int> MergedTiles { get; }

            private int LastNonOccupiedIndex => Length - Occupied - 1;

            public RowObject(int length)
            {
                Length = length;
                Items = new SquareItem[length];
                Occupied = 0;
                MergedTiles = new List<int>(2);
            }

            public bool TryMerge(SquareItem item, out int score)
            {
                if (CanMerge(item))
                {
                    score = Merge();
                    return true;
                }

                Items[LastNonOccupiedIndex] = item;
                Occupied++;

                score = 0;
                return false;
            }

            private bool CanMerge(SquareItem item)
            {
                if (Occupied <= 0)
                    return false;

                var nextIndex = LastNonOccupiedIndex + 1;

                // already merged items can't be merged again within the same move
                if (MergedTiles.Contains(nextIndex))
                {
                    return false;
                }

                return item.Number == Items[nextIndex].Number;
            }

            private int Merge()
            {
                var nextOccupied = LastNonOccupiedIndex + 1;
                
                var item = Items[nextOccupied];
                item.Number *= 2;
                item.IsMerged = true;
                MergedTiles.Add(nextOccupied);

                return item.Number;
            }
        }
    }
}