using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class WinnerPanelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] playerRows; 
    [SerializeField] private TextMeshProUGUI winnerText; 
    [SerializeField] private int[] scores;

    private void Start() {
        UnityEngine.Debug.Log($"Start Called");
        MatchEvents.ScoreChanged += UpdatePlayerScore;
        MatchEvents.MatchEnded += MatchEnded;
        MatchEvents.MatchStarted += MatchStart;

    }

    private void OnDestroy() {
        MatchEvents.MatchStarted -= MatchStart;
        MatchEvents.ScoreChanged -= UpdatePlayerScore;
        MatchEvents.MatchEnded -= MatchEnded;

    }

    void MatchStart()
    {
        this.gameObject.SetActive(false);
    }
     private void UpdatePlayerScore(int playerId, int score)
    {
        playerRows[playerId].text = $"Player {playerId}: {score} Kills";
    }

    void MatchEnded(int winnerId)
    {
        this.gameObject.SetActive(true);
        winnerText.text = $"Winner: {(winnerId == -1 ? "Time out" : $"Player {winnerId}")}";
    }
}
