using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this partial section deals (har har) with high-level state and initialization
public partial class GameManager : MonoBehaviour {

	public static GameManager Singleton;
	public GameState GameState;

	void Awake () {
		Singleton = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Initialize (GameProperties gameProperties) {
		GameState = new GameState(gameProperties);
	}

}
