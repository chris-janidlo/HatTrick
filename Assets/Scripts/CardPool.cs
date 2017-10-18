using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HatTrick {
		
// used for draw pools and hands
public class CardPool : MonoBehaviour {

	public List<CardQualities> Pool;

	public CardQualities RandomCard () {
		return Pool[Random.Range(0, Pool.Count)];
	}

}

}