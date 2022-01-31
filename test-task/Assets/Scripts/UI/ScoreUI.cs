using Player;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI textScore;

   private void Awake()
   {
      PlayerInfo.ScoreUpdated += UpdateScoreUI;
   }

   private void UpdateScoreUI(int score)
   {
      textScore.text = $"Score: {score}";
   }
}
