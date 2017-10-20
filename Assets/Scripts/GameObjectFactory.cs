using UnityEngine;

namespace HatTrick {

public static class GameObjectFactory {
	
	// resource strings
	private const string trickName = "Trick";

	// storage backers (don't use these!)
	private static GameObject _trickObject;

	// lazy-initialized GameObject containers
	private static GameObject trickObject {
		get {
			if (_trickObject == null) _trickObject = (GameObject) Resources.Load(trickName);
			return _trickObject;
		}
	}

	public static GameObject NewTrick (int length) {
		GameObject newTrick = GameObject.Instantiate(trickObject);
		newTrick.GetComponent<Trick>().Initialize(length);
		return newTrick;
	}

}

}