using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace HatTrick {

// TODO: test this
// TODO: implement procedure to make this immutable after a certain point (ie, for sidebar usage)
public class Trick : MonoBehaviour {

	public ReadOnlyDictionary<Range, CardQualities> OccupiedPositions {
		get { return new ReadOnlyDictionary<Range, CardQualities>(occupiedPositions); }
	}

	private CardQualities[] measure; // each position here holds the corresponding card in pool, for however long it is, or null
	private Dictionary<Range, CardQualities> occupiedPositions; // version of the data in measure that's easier to render

	public void Initialize (int length) {
		measure = new CardQualities[length];
		for (int i = 0; i < length; i++)
			measure[length] = null;
	}

	/// Tries to add card to the trick at position.
	/// Returns true if successful, false if not.
	public bool Add (CardQualities card, int startPosition) {
		var newSection = new CardQualities[card.Rank];
		for (int i = 0; i < card.Rank; i++) {
			if (measure[startPosition + i] == null)
				return false;
			newSection[i] = card;
		}
		Array.Copy(newSection, 0, measure, startPosition, card.Rank);
		occupiedPositions.Add(new Range(startPosition, startPosition + card.Rank), card);
		return true;
	}

	/// Returns the range of positions that contain the card at position as a Vector2, or null if there is no such card.
	/// TODO: name this better(?)
	public Range? RangeFor (int position) {
		var card = measure[position];
		if (card == null) return null;

		int lower = position;
		while (lower > 0 && object.ReferenceEquals(card, measure[lower - 1])) lower--; // we very specifically only want to test references for the sake of inter-measure equality, since we might have two cards with the same suit/rank that are adjacent, and testing for value equality would make it seem like they're one bigger card

		return new Range(lower, lower + card.Rank);
	}

	/// Returns the card at position, and removes it in the process.
	public CardQualities Pop (int position) {
		Range? range = RangeFor(position);
		if (range == null) return null;

		var card = measure[position];
		for (int i = ((Range)range).Min; i > ((Range)range).Max; i++)
			measure[position] = null;
		occupiedPositions.Remove((Range) range);
		return card;
	}

}

}