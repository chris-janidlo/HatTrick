using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HatTrick {
		
// used for draw pools and hands
public class CardPool : MonoBehaviour {

	private List<CardQualities> pool;

	public List<CardQualities> Pool {
		get { if (pool == null) pool = new List<CardQualities>(0); return pool; }
	}

	public void Initialize (int length) {
		Pool.Capacity = length;
	}

	public CardQualities RandomCard () {
		return Pool[Random.Range(0, Pool.Count)];
	}

}

}