using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//animates card draws
public class DrawAnimator : MonoBehaviour {

	public static DrawAnimator Singleton;
	public float AnimationLength;
	public bool Animating;
	public GameObject CardPrefab; //prefab for the visual representation of a card
	
	private float animationTime;
	private GameObject currentAnimatingCard;

	void Awake () {
		Singleton = this;
	}

	void Start () {
	}
	
	void Update () {
		if (animationTime > 0)
			animationTime -= Time.deltaTime;
		else if (Animating) {
			Animating = false;
			stopAnimating();
		}
	}

	public void Animate (CardQualities card) {
		animationTime = AnimationLength;
		Animating = true;
		currentAnimatingCard = Instantiate(CardPrefab, parent:transform);
		currentAnimatingCard.GetComponent<CardVisuals>().Initialize(card);
	}

	private void stopAnimating() {
		Destroy(currentAnimatingCard);
	}

}
