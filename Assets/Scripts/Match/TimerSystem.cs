using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    private float remainingTime;
    private int lastBroadcastedSecond;
    private bool isRunning;

    private void OnEnable()
    {
        MatchEvents.MatchStarted += StartTimer;
        MatchEvents.MatchEnded += StopTimer;
    }
    private void OnDisable()
    {
        MatchEvents.MatchStarted -= StartTimer;
        MatchEvents.MatchEnded -= StopTimer;
    }

    private void StartTimer()
    {
        remainingTime = settings.MatchDuration;
        isRunning = true;
    }

    private void StopTimer(int winnerId) => isRunning = false;

    private void Update()
    {
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;
        int currentSeconds = Mathf.CeilToInt(remainingTime);

        if (currentSeconds != lastBroadcastedSecond)
        {
            lastBroadcastedSecond = currentSeconds;
            MatchEvents.TimeUpdated?.Invoke(currentSeconds);
            
            if (remainingTime <= 0)
            {
                MatchEvents.MatchEnded?.Invoke(-1); 
            }
        }
    }
}