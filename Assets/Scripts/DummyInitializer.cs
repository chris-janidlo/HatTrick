using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInitializer : MonoBehaviour {

	void Start () {
		GetComponent<GameManager>().Initialize(new GameProperties(true));
		Destroy(this);	
	}

}
