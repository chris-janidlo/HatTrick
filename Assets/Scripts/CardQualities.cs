//simple container for card suit and rank (note and length)
public struct CardQualities {

	public Suit Suit;
	public int Rank;

	public CardQualities (Suit suit, int rank) {
		Suit = suit;
		Rank = rank;
	}

	public override string ToString() {
		return Rank + " of " + Suit;
	}

}
