using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//animates card draws
public class DrawAnimator : MonoBehaviour {

	public static DrawAnimator Singleton;
	public float AnimationLength;
	
	private Text placeholder;
	private float animationTime;
	private bool animating;

	void Awake () {
		Singleton = this;
	}

	void Start () {
		placeholder = GetComponentInChildren<Text>();
	}
	
	void Update () {
		if (animationTime > 0)
			animationTime -= Time.deltaTime;
		else if (animating) {
			animating = false;
			placeholder.text = "";
		}
	}

	public void Animate (CardQualities card, Player owner) {
		animationTime = AnimationLength;
		animating = true;
		placeholder.text = card.ToString();
	}

}
