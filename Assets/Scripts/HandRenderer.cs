using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//renders one player's hand
//if it is that player's turn, it renders it at the bottom; otherwise it renders at the top
//data for where to render each of these are stored as part of the renderer prefab:
//	FriendlyPlayer's hand is within the area set by the RectTransform of the "Friendly Hand" child
//	likewise for the enemy player and "Enemy Hand"
public class HandRenderer : MonoBehaviour {

	public Player FriendlyPlayer; //the player this renderer draws at the bottom of the screen
	public GameObject CardPrefab; //prefab for the visual representation of a card

	private RectTransform friendlyArea;
	private RectTransform enemyArea;
	private List<GameObject> currentPlayerHandDrawing;
	private List<GameObject> currentEnemyHandDrawing;
	private bool needsToUpdate;

	void Start () {
		friendlyArea = transform.Find("Friendly Hand").GetComponent<RectTransform>();
		enemyArea = transform.Find("Enemy Hand").GetComponent<RectTransform>();
		currentPlayerHandDrawing = new List<GameObject>();
		currentEnemyHandDrawing = new List<GameObject>();
	}

	void Initialize (Player friendlyPlayer) {
		FriendlyPlayer = friendlyPlayer;
	}
	
	void Update () {
		if (DrawAnimator.Singleton.Animating)
			needsToUpdate = true;
		else if (needsToUpdate)
			redrawCurrentHand();
	}

	//visually refreshes the hand of the current player
	private void redrawCurrentHand () {
		if (GameManager.Singleton.CurrentPlayerType == FriendlyPlayer)
			redrawPlayer();
		else
			redrawOpponent();
	}

	private void redrawPlayer() {
		//delete the old hand
		foreach (var card in currentPlayerHandDrawing)
			Destroy(card);
		currentPlayerHandDrawing = new List<GameObject>();

		var hand = GameManager.Singleton.CurrentPlayer.Hand;
		
		//make the new hand
		for (int i = 0; i < hand.Count; i++ ) {
			var tempCard = Instantiate(CardPrefab, parent:friendlyArea);
			tempCard.GetComponent<CardVisuals>().Initialize(hand[i]);
			currentPlayerHandDrawing.Add(tempCard);
		}

		needsToUpdate = false;

	}

	private void redrawOpponent() {

	}

}
