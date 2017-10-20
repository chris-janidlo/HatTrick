using UnityEngine;
//defines suits and their associations with colors

namespace HatTrick {

public enum SuitName {
	C, D, E, F, G, A, B
}

public enum SuitColor {
	yellow, blue, green, orange, white, red, black
}

public class Suit {

	public SuitName Label { get; private set; }

	/// color of the chord where this note is the root
	public SuitColor Root {
		get { return (SuitColor) ((int) Label); }
	}
	/// color of the chord where this note is the third
	public SuitColor Third {
		get { return (SuitColor) ((((int) Label) - 2) % 7); }
	}
	/// color of the chord where this note is the fifth
	public SuitColor Fifth {
		get { return (SuitColor) ((((int) Label) - 4) % 7); }
	}

	public Suit (SuitName label) {
		Label = label;
	}

	public static Suit RandomSuit () {
		return new Suit((SuitName) Random.Range(0, 7));
	}

	public override string ToString () {
		return Label.ToString();
	}

	/// Returns whether this shares a color with other.
	public bool HarmonizesWith (Suit other) {
		return  Root == other.Root || Root == other.Third || Root == other.Fifth ||
				Third == other.Root || Third == other.Third || Third == other.Fifth ||
				Fifth == other.Root || Fifth == other.Third || Fifth == other.Fifth;
		// note: does redundant checks (third with third and fifth with fifth after already checking root with root, and probably others). doubt this will be performance critical, so it stays for now
	}

}

}