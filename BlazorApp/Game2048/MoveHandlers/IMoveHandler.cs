namespace Game2048.MoveHandlers
{
    public interface IMoveHandler
    {
        GameState Handle(GameState state);
    }
}