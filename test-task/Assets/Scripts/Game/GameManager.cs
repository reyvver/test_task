using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(GameEnd))]
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            EndGame();
        }
        
        public static void StartGame()
        {
            GameState.ChangeState(GameState.GameStatus.GameStarted);
        }

        public static void EndGame()
        {
            GameState.ChangeState(GameState.GameStatus.GameFinished);
        }
    }
}
