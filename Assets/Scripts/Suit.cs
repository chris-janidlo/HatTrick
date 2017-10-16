using System;
//defines suits and their associations with colors

public enum SuitColor {
	yellow,
	blue,
	green,
	orange,
	white,
	red,
	black
}

//Suit is almost like an enum: there are only 7 possible values accessible from the outside, which are the properties at the end of the definition
//it isn't an enum, however, in that each value is a struct with three publically accessible values
public struct Suit {
	public SuitColor root { get; private set; } //color of the chord where this note is the root
	public SuitColor third { get; private set; } //color of the chord where this note is the third
	public SuitColor fifth { get; private set; } //color of the chord where this note is the fifth

	private Suit (SuitColor _root, SuitColor _third, SuitColor _fifth) {
		root = _root;
		third = _third;
		fifth = _fifth;
	}

	public static Suit IntToSuit (int noteNumber) {
		switch (noteNumber) {
			case 1:
				return Suit.C;
			case 2:
				return Suit.D;
			case 3:
				return Suit.E;
			case 4:
				return Suit.F;
			case 5:
				return Suit.G;
			case 6:
				return Suit.A;
			case 7:
				return Suit.B;
			default:
				throw new ArgumentException();
		}
	}

	public static Suit C { get {
		return new Suit(SuitColor.yellow, SuitColor.red, SuitColor.orange);
	} }
	public static Suit D { get {
		return new Suit(SuitColor.blue, SuitColor.black, SuitColor.white);
	} }
	public static Suit E { get {
		return new Suit(SuitColor.green, SuitColor.yellow, SuitColor.red);
	} }
	public static Suit F { get {
		return new Suit(SuitColor.orange, SuitColor.blue, SuitColor.black);
	} }
	public static Suit G { get {
		return new Suit(SuitColor.white, SuitColor.green, SuitColor.yellow);
	} }
	public static Suit A { get {
		return new Suit(SuitColor.red, SuitColor.orange, SuitColor.blue);
	} }
	public static Suit B { get {
		return new Suit(SuitColor.black, SuitColor.white, SuitColor.green);
	} }

	public override string ToString () {
		return root.ToString() + ", " + third.ToString() + ", " + fifth.ToString();
	}
	
}
