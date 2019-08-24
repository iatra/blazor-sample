using System.Collections.Generic;
using Game2048.MoveHandlers;

namespace Game2048
{
    public static class MoveHelper
    {
        private static readonly IMoveHandler Default = new NoneHandler();
        private static readonly IDictionary<string, IMoveHandler> Handlers = new Dictionary<string, IMoveHandler>
        {
            ["ArrowLeft"] = new LeftHandler(),
            ["ArrowUp"] = new UpHandler(),
            ["ArrowRight"] = new RightHandler(),
            ["ArrowDown"] = new DownHandler()
        };

        public static GameState Handle(string keyCode, GameState state)
        {
            return Handlers.TryGetValue(keyCode, out var handler)
                ? handler.Handle(state)
                : Default.Handle(state);
        }
    }
}
