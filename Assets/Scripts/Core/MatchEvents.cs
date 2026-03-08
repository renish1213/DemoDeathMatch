using System;

public static class MatchEvents
{
    public static Action MatchStarted;
    public static Action<int> MatchEnded; 
    
    public static Action<int, int> PlayerKilled; 
    public static Action<int> PlayerRespawned;   
    
    public static Action<int, int> ScoreChanged; 
    public static Action<int> TimeUpdated;       
}