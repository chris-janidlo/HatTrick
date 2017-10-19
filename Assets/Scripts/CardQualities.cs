using UnityEngine;

namespace HatTrick {

// simple container for card suit and rank (note and length)
public class CardQualities {

	public Suit Suit { get; private set; }
	public int Rank { get; private set; }

	public CardQualities (Suit suit, int rank) {
		Suit = suit;
		Rank = rank;
	}

	public override string ToString() {
		return Rank + " of " + Suit;
	}

	public static CardQualities RandomCard (int rankMax, int rankMin=1) {
		int rank = Random.Range(rankMin, rankMax + 1);
		Suit suit = Suit.RandomSuit();
		return new CardQualities(suit, rank);
	}

}

}