using System;
using UnityEngine;
using HatTrick;

class TrickTest : MonoBehaviour {

	void Start () {
		Trick trick = GameObjectFactory.NewTrick(8);
		trick.Add(new CardQualities(new Suit(SuitName.C), 4), 0);
		trick.Add(new CardQualities(new Suit(SuitName.C), 2), 4);
		trick.Add(new CardQualities(new Suit(SuitName.B), 2), 6);
	}

}