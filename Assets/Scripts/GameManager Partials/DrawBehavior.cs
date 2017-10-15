using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this partial section deals with drawing mechanics
public partial class GameManager : MonoBehaviour {

	public const int KeyMinBound = int.MinValue;
	public const int KeyMaxBound = int.MaxValue;

	public void DrawCard (DrawPoolType pool) {
		int key;
		CardQualities card = new CardQualities();
		switch (pool) {
			case DrawPoolType.random:
				key = generateKey();
				card = new CardQualities(Suit.IntToSuit(Random.Range(1,8)), Random.Range(1, GameProperties.TrickLength+1));
				break;
			case DrawPoolType.PlayerOne:
				key = randomKeyFromPool(Player.one);
				card = PlayerOneState.DrawPool[key];
				break;
			case DrawPoolType.PlayerTwo:
				key = randomKeyFromPool(Player.two);
				card = PlayerOneState.DrawPool[key];
				break;
		}
		DrawAnimator.Singleton.Animate(card);
		CurrentPlayerState.Hand.Add(card);
	}

	public void DrawRandom () {
		DrawCard(DrawPoolType.random);
	}

	public void DrawFromOne () {
		DrawCard(DrawPoolType.PlayerOne);
	}

	public void DrawFromTwo () {
		DrawCard(DrawPoolType.PlayerTwo);
	}

	//TODO: key system is a bandaid for the fact that the card animator needs to know what card it's animating. would like a less couple system than that
	//TODO: currently just a random int, would like something more elegant that can't theoretically run infinitely
	private int generateKey () {
		int choice = Random.Range(KeyMinBound, KeyMaxBound);
		while (keyIsNotUnique(choice))
			choice = Random.Range(KeyMinBound, KeyMaxBound);
		return choice;
	}

	private bool keyIsNotUnique (int key) {
		return (
			PlayerOneState.Hand.ContainsKey(key) || PlayerOneState.DrawPool.ContainsKey(key) ||
			PlayerTwoState.Hand.ContainsKey(key) || PlayerTwoState.DrawPool.ContainsKey(key)
		);
	}

	private int randomKeyFromPool (Player pool) {
		return Utilities.Choose<int>(new List<int>(getPlayerState(pool).DrawPool.Keys));
	}

}

//TODO: ugly as hell to have this AND Player
public enum DrawPoolType {
	random, PlayerOne, PlayerTwo
}
