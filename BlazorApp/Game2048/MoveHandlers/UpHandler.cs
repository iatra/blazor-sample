namespace Game2048.MoveHandlers
{
    internal sealed class UpHandler : MoveHandlerBase
    {
        protected override SquareItem this[SquareItem[][] squares, int i, int j]
        {
            get => squares[squares.Length - j - 1][i];
            set => squares[squares.Length - j - 1][i] = value;
        }
    }
}