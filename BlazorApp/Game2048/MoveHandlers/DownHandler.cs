namespace Game2048.MoveHandlers
{
    internal sealed class DownHandler : MoveHandlerBase
    {
        protected override SquareItem this[SquareItem[][] squares, int i, int j]
        {
            get => squares[j][i];
            set => squares[j][i] = value;
        }
    }
}