﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState {

	public GameProperties GameProperties { get; private set; }
	public PlayerState PlayerOne { get; private set; }
	public PlayerState PlayerTwo { get; private set; }
	public Player CurrentPlayerType { get; private set; }
	public PlayerState CurrentPlayer { get {
		if (CurrentPlayerType == Player.one)
			return PlayerOne;
		else
			return PlayerTwo;
	} }

	public GameState (GameProperties gameProperties) {
		GameProperties = gameProperties;
		PlayerOne = new PlayerState();
		PlayerTwo = new PlayerState();
		CurrentPlayerType = Player.one;
	}

	public void SwitchTurn () {
		if (CurrentPlayerType == Player.one)
			CurrentPlayerType = Player.two;
		else
			CurrentPlayerType = Player.one;
	}
	
}

public class PlayerState {
	
	public List<CardQualities> DrawPool { get; set; }
	public List<CardQualities> Hand { get; set; }

	public PlayerState () {
		DrawPool = new List<CardQualities>();
		Hand = new List<CardQualities>();
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