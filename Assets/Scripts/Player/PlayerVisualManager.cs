using UnityEngine;
using TMPro;

public class PlayerVisualManager : MonoBehaviour
{
    [SerializeField] private MatchSettingsSO settings;
    [SerializeField] private GameObject playerPrefab3D; 
    [SerializeField] private Vector2 spawnArea = new Vector2(20f, 20f);

    [SerializeField]private GameObject[] playerVisuals;

    private void OnEnable()
    {
        MatchEvents.MatchStarted += SetupPlayers;
        MatchEvents.PlayerKilled += HideDeadPlayer;
        MatchEvents.PlayerRespawned += ShowRespawnedPlayer;
    }

    private void OnDisable()
    {
        MatchEvents.MatchStarted -= SetupPlayers;
        MatchEvents.PlayerKilled -= HideDeadPlayer;
        MatchEvents.PlayerRespawned -= ShowRespawnedPlayer;
    }

    private void SetupPlayers()
    {
        playerVisuals = new GameObject[settings.PlayerCount];

        for (int i = 0; i < settings.PlayerCount; i++)
        {
            Vector3 startPos = GetRandomSpawnPosition();
            GameObject newPlayer = Instantiate(playerPrefab3D, startPos, Quaternion.identity, this.transform);
            newPlayer.name = $"Player_{i}";
            
            TextMeshPro floatingText = newPlayer.GetComponentInChildren<TextMeshPro>();
            if (floatingText != null)
            {
                floatingText.text = $"P{i}";
            }

            playerVisuals[i] = newPlayer;
        }
    }

    private void HideDeadPlayer(int killerId, int victimId)
    {
        playerVisuals[victimId].SetActive(false);
        Debug.DrawLine(playerVisuals[killerId].transform.position, playerVisuals[victimId].transform.position, Color.red, 2f);
    }

    private void ShowRespawnedPlayer(int playerId)
    {
        playerVisuals[playerId].transform.position = GetRandomSpawnPosition();
        playerVisuals[playerId].SetActive(true);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f);
        float randomZ = Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f);
        return new Vector3(randomX, 1f, randomZ);
    }
}