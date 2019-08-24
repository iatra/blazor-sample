namespace Game2048.MoveHandlers
{
    internal sealed class RightHandler : MoveHandlerBase
    {
        protected override SquareItem this[SquareItem[][] squares, int i, int j]
        {
            get => squares[i][j];
            set => squares[i][j] = value;
        }
    }
}