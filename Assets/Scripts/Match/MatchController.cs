using UnityEngine;

public class MatchController : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    [SerializeField] private PlayerRegistry playerRegistry; 
    
    private bool isMatchRunning;
    private float nextActionTime;

    private void OnEnable() => MatchEvents.MatchEnded += StopMatch;
    private void OnDisable() => MatchEvents.MatchEnded -= StopMatch;

    private void Start()
    {
        MatchEvents.MatchStarted?.Invoke();
        isMatchRunning = true;
        ScheduleNextKill();
    }

    private void StopMatch(int winnerId)
    {
        isMatchRunning = false;
    }

    private void Update()
    {
        if (!isMatchRunning) return;

        if (Time.time >= nextActionTime)
        {
            ExecuteRandomKill();
            ScheduleNextKill();
        }
    }

    private void ScheduleNextKill()
    {
        nextActionTime = Time.time + Random.Range(settings.MinKillInterval, settings.MaxKillInterval);
    }

    private void ExecuteRandomKill()
    {
        if (playerRegistry.GetRandomAlivePlayer(out int killerId) && 
            playerRegistry.GetRandomAlivePlayer(out int victimId))
        {
            if (killerId != victimId)
            {
                playerRegistry.KillPlayer(victimId);
                MatchEvents.PlayerKilled?.Invoke(killerId, victimId);
            }
        }
    }
}