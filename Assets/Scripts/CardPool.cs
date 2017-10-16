using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour {

	public List<CardQualities> Pool;

	public CardQualities RandomCard () {
		return Pool[Random.Range(0, Pool.Count)];
	}

}
