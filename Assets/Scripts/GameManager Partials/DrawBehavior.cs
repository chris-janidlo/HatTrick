using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this partial section deals with drawing mechanics
public partial class GameManager : MonoBehaviour {

	public void DrawCard (DrawPoolType pool) {
		CardQualities card = new CardQualities();
		switch (pool) {
			case DrawPoolType.random:
				card = new CardQualities(Suit.IntToSuit(Random.Range(1,8)), Random.Range(1, GameProperties.TrickLength+1));
				break;
			case DrawPoolType.PlayerOne:
				card = Utilities.Choose(PlayerOneState.DrawPool);
				break;
			case DrawPoolType.PlayerTwo:
				card = Utilities.Choose(PlayerTwoState.DrawPool);
				break;
		}
		DrawAnimator.Singleton.Animate(card);
		CurrentPlayer.Hand.Add(card);
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
