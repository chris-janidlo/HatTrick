using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this partial section deals with drawing mechanics
public partial class GameManager : MonoBehaviour {

	public void DrawCard (Player owner, DrawPoolType pool) {
		CardQualities card = new CardQualities();
		switch (pool) {
			case DrawPoolType.random:
				card = new CardQualities(Suit.IntToSuit(Random.Range(1,8)), Random.Range(1, GameState.GameProperties.TrickLength+1));
				break;
			case DrawPoolType.PlayerOne:
				card = Utilities.Choose(GameState.PlayerOne.DrawPool);
				break;
			case DrawPoolType.PlayerTwo:
				card = Utilities.Choose(GameState.PlayerTwo.DrawPool);
				break;
		}
		DrawAnimator.Singleton.Animate(card, owner);
		if (owner == Player.one)
			GameState.PlayerOne.Hand.Add(card);
		else
			GameState.PlayerTwo.Hand.Add(card);
	}

	public void DrawCard (DrawPoolType pool) {
		DrawCard(GameState.CurrentPlayer, pool);
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

}

public enum DrawPoolType {
	random, PlayerOne, PlayerTwo
}
