using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Singleton;
	public GameProperties GameProperties;

	private List<CardQualities> PlayerOnePool;
	private List<CardQualities> PlayerTwoPool;

	void Awake () {
		Singleton = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Initialize (GameProperties gameProperties) {
		GameProperties = gameProperties;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private CardQualities drawRandom () {
		return new CardQualities(Suit.IntToSuit(Random.Range(1,8)), Random.Range(1, GameProperties.TrickLength+1));
	}

	private CardQualities drawPlayerOne () {
		return Utilities.Choose(PlayerOnePool);
	}

	private CardQualities drawPlayerTwo () {
		return Utilities.Choose(PlayerTwoPool);
	}

}

public struct GameProperties {
	public bool SinglePlayer;
	public int HandSize;
	public int TrickLength;
	public int TricksToWin;

	public GameProperties (bool singlePlayer = true, int handSize = 12, int trickLength = 8, int tricksToWin = 8) {
		SinglePlayer = singlePlayer;
		HandSize = handSize;
		TrickLength = trickLength;
		TricksToWin = tricksToWin;
	}
}
