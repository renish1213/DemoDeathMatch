using UnityEngine;

public class PlayerRegistry : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    
    private PlayerData[] players;
    private float[] respawnTimes;

    private void OnEnable() => MatchEvents.MatchStarted += InitializePlayers;
    private void OnDisable() => MatchEvents.MatchStarted -= InitializePlayers;

    private void InitializePlayers()
    {
        players = new PlayerData[settings.PlayerCount];
        respawnTimes = new float[settings.PlayerCount];

        for (int i = 0; i < settings.PlayerCount; i++)
        {
            players[i] = new PlayerData { Id = i, IsAlive = true };
        }
    }

    private void Update()
    {
        if (players == null) return;

        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].IsAlive && Time.time >= respawnTimes[i])
            {
                players[i].IsAlive = true;
                MatchEvents.PlayerRespawned?.Invoke(i);
            }
        }
    }

    public void KillPlayer(int victimId)
    {
        players[victimId].IsAlive = false;
        respawnTimes[victimId] = Time.time + settings.RespawnTime;
    }

    public bool GetRandomAlivePlayer(out int playerId)
    {
        playerId = -1;
        int aliveCount = 0;
        int[] aliveIds = new int[settings.PlayerCount]; 

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].IsAlive) aliveIds[aliveCount++] = players[i].Id;
        }

        if (aliveCount == 0) return false;

        playerId = aliveIds[Random.Range(0, aliveCount)];
        return true;
    }
}