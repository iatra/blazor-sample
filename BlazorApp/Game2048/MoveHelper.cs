using Game2048.MoveHandlers;

namespace Game2048
{
    public static class MoveHelper
    {
        private static readonly IMoveHandler Up = new UpHandler();
        private static readonly IMoveHandler Right = new RightHandler();
        private static readonly IMoveHandler Down = new DownHandler();
        private static readonly IMoveHandler Left = new LeftHandler();

        public static GameState HandleUp(GameState state)
        {
            return Up.Handle(state);
        }
        
        public static GameState HandleLeft(GameState state)
        {
            return Left.Handle(state);
        }
        
        public static GameState HandleDown(GameState state)
        {
            return Down.Handle(state);
        }
        
        public static GameState HandleRight(GameState state)
        {
            return Right.Handle(state);
        }
    }
}
