Demo DeathMatch

================ recorded Video added recordedVideo Folder ===== 

-----Asset
	- \Art 
		Materials for players and plane
	- \Prefabs
		Player and Plane Prefab
	- \Scene
		DeatchMatch  (Demo Scene)
	- \Scripts
		* \Config
			- DefaultMatchScriptable that holds Player Count, Kill interval,RespawnTime, MatchDuration, Max kills to win

		* \Core
			- MatchEvents Where all match events added in single class so future events we can add there
			- PlayerData where player entity I have added like id score we can extend as per req.

		* \Match
			- MatchContoller - Where match event invoked like match start And Execute Kill and Schedule Next kill
			- TimerSystem - Where MatchTimer Running if match timer complete it fire matched event.
		
		*\Player
			- PlayerRegistry - Where init player RandomKills
			- PlayerVisualManager - Where I shows in UI which player kills which player and hide in UI. 
		
		*\UI
			-LeaderboardUI where Leaderboard UI added where updating on player kill event also. Shows timer
			- WinnerUI - Where Shows winner Panel with all player kills and Match Winner

		*\Utils
			- FaceCamera. -- Added in all Text so its face camera we can see Properly On UI.
			- ScoreSysten -- Where I add score for player and fire event to show In UI Also invokes matchEnd event when player kills count reaches to 10.




================Scene==============

 Under SYSTEM Object added MatchController, PlayerRegisry,PlayerVisualManger,TimerSystem and ScoreSystem etc,

In canvas there is Leaderboard and WinnerPanel added.
