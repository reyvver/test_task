using Player;
using UnityEngine;

namespace Game
{
    public class GameEnd : MonoBehaviour
    {
        private const float MaxTimeWithoutInteraction = 15f;
        private bool _isGameActive;
        private float _time;

        private void Awake()
        {
            GameState.GameStatusChanged += OnGameStatusChanged;
        }

        private void Update()
        {
            if (!_isGameActive) return;

            if (Input.GetMouseButtonDown(0))
            {
                _time = 0;
            }

            _time += Time.deltaTime;
            
            if (_time >= MaxTimeWithoutInteraction)
                StopGame();
        }
        
        private void OnGameStatusChanged(GameState.GameStatus status)
        {
            switch (status)
            {
                case GameState.GameStatus.GameStarted:
                {
                    StartCheck();
                    break;
                }
                case GameState.GameStatus.GameFinished:
                {
                    StopCheck();
                    break;
                }
            }
        }

        private void StartCheck()
        {
            _isGameActive = true;
            _time = 0;
        }
        
        private void StopCheck()
        {
            _isGameActive = false;
        }

        private void StopGame()
        {
            PlayerInfo.SetScore(0);
            GameManager.EndGame();
        }
    }
}