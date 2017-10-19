using UnityEngine;

namespace HatTrick {

// simple container for card suit and rank (note and length)
[System.Serializable]
public class CardQualities {

	public Suit Suit;
	public int Rank;

	public CardQualities (Suit suit, int rank) {
		Suit = suit;
		Rank = rank;
	}

	public override string ToString() {
		return Rank + " of " + Suit;
	}

	public static CardQualities RandomCard (int rankMin, int rankMax) {
		int rank = Random.Range(rankMin, rankMax + 1);
		Suit suit = Suit.RandomSuit();
		return new CardQualities(suit, rank);
	}

}

}