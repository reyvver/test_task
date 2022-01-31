using System;

namespace Game
{
    public static class GameState
    {
        public enum GameStatus
        {
            GameStarted,
            GameFinished
        }

        public static Action<GameStatus> GameStatusChanged;

        public static void ChangeState(GameStatus status)
        {
            GameStatusChanged?.Invoke(status);
        }
    }
}