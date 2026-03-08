using UnityEngine;

[CreateAssetMenu(fileName = "MatchSettings", menuName = "Config/MatchSettings")]
public class MatchSettingsSO : ScriptableObject
{
    public int PlayerCount = 10;
    public float MinKillInterval = 1f;
    public float MaxKillInterval = 2f;
    public float RespawnTime = 3f;
    public float MatchDuration = 180f; // 3 minutes
    public int MaxKillsToWin = 10;
}