using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    private int[] scores;

    private void OnEnable()
    {
        MatchEvents.MatchStarted += ResetScores;
        MatchEvents.PlayerKilled += OnPlayerKilled;
    }

    private void OnDisable()
    {
        MatchEvents.MatchStarted -= ResetScores;
        MatchEvents.PlayerKilled -= OnPlayerKilled;
    }

    private void ResetScores()
    {
        scores = new int[settings.PlayerCount];
    }

    private void OnPlayerKilled(int killerId, int victimId)
    {
        scores[killerId]++;
        MatchEvents.ScoreChanged?.Invoke(killerId, scores[killerId]);

        if (scores[killerId] >= settings.MaxKillsToWin)
        {
            MatchEvents.MatchEnded?.Invoke(killerId);
        }
    }
}