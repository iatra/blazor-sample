namespace Game2048.MoveHandlers
{
    internal sealed class LeftHandler : MoveHandlerBase
    {
        protected override SquareItem this[SquareItem[][] squares, int i, int j]
        {
            get => squares[i][squares.Length - j - 1];
            set => squares[i][squares.Length - j - 1] = value;
        }
    }
}