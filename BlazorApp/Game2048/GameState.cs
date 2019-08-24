namespace Game2048
{
    public class GameState
    {
        public SquareItem[][] Squares { get; set; }

        public bool IsMoved { get; set; }

        public bool IsStarted { get; set; }

        public int Score { get; set; }

        //public int Rewinds { get; set; }

        //public stack must be here!!! History { get; set; }
    }
}
