using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    [SerializeField] private TextMeshProUGUI[] playerRows; 
    [SerializeField] private TextMeshProUGUI timerText;

    private void OnEnable()
    {
        MatchEvents.ScoreChanged += UpdatePlayerScore;
        MatchEvents.TimeUpdated += UpdateTimer;
    }

    private void OnDisable()
    {
        MatchEvents.ScoreChanged -= UpdatePlayerScore;
        MatchEvents.TimeUpdated -= UpdateTimer;
    }
    private void UpdatePlayerScore(int playerId, int score)
    {
        playerRows[playerId].text = $"Player {playerId}: {score} Kills";
    }

    private void UpdateTimer(int remainingSeconds)
    {
        int mins = remainingSeconds / 60;
        int secs = remainingSeconds % 60;
        timerText.text = $"{mins:00}:{secs:00}"; 
    }
}