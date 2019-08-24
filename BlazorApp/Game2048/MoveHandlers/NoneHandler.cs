namespace Game2048.MoveHandlers
{
    internal sealed class NoneHandler : IMoveHandler
    {
        public GameState Handle(GameState state)
        {
            state.IsMoved = false;
            return state;
        }
    }
}