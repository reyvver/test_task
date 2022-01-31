using System;

namespace Player
{
    public static class PlayerInfo
    { 
        public static event Action<int> ScoreUpdated;
        private static int _currentScore;

        public static void UpdateScore(int newPoints)
        {
            _currentScore += newPoints;
            
            if (_currentScore < 0)
                _currentScore = 0;
            
            ScoreUpdated?.Invoke(_currentScore);
        }

        public static void SetScore(int newScore)
        {
            _currentScore = 0;
            ScoreUpdated?.Invoke(_currentScore);
        }
    }
}
