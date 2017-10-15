using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this partial section deals (har har) with high-level state and initialization
public partial class GameManager : MonoBehaviour {

	public static GameManager Singleton;
	public GameProperties GameProperties { get; private set; }
	public PlayerState PlayerOneState { get; private set; }
	public PlayerState PlayerTwoState { get; private set; }
	public Player CurrentPlayerType { get; private set; }
	public PlayerState CurrentPlayerState { get {
		if (CurrentPlayerType == Player.one)
			return PlayerOneState;
		else
			return PlayerTwoState;
	} }

	public void SwitchTurn () {
		if (CurrentPlayerType == Player.one)
			CurrentPlayerType = Player.two;
		else
			CurrentPlayerType = Player.one;
	}

	void Awake () {
		Singleton = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Initialize (GameProperties gameProperties) {
		GameProperties = gameProperties;
		PlayerOneState = new PlayerState();
		PlayerTwoState = new PlayerState();
		CurrentPlayerType = Player.one;
	}

	PlayerState getPlayerState (Player player) {
		if (player == Player.one) return PlayerOneState;
		else return PlayerTwoState;
	}

}

public class PlayerState {
	
	public Dictionary<int, CardQualities> DrawPool { get; set; }
	public Dictionary<int, CardQualities> Hand { get; set; }

	public PlayerState () {
		DrawPool = new Dictionary<int, CardQualities>();
		Hand = new Dictionary<int, CardQualities>();
	}

}

public struct GameProperties {
	public bool SinglePlayer;
	public int HandSize;
	public int TrickLength;
	public int TricksToWin;

	//note that if you call the parameterless version, which cannot be hidden, everything will go to system default
	public GameProperties (bool singlePlayer, int handSize = 12, int trickLength = 8, int tricksToWin = 8) {
		SinglePlayer = singlePlayer;
		HandSize = handSize;
		TrickLength = trickLength;
		TricksToWin = tricksToWin;
	}
}

//every player there can be
public enum Player {
	one, two
}
