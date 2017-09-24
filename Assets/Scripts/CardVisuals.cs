using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardVisuals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Vector2 HilightScale; //size when mousing over in hand
	public Vector2 LolightScale; //size when not mousing over

	private Text placeholder;

	void Awake () {
		placeholder = GetComponentInChildren<Text>();
	}

	public void Initialize (CardQualities quanta) {
		placeholder.text = quanta.Rank + "\n" + quanta.Suit.root + "\n" + quanta.Suit.third + "\n" + quanta.Suit.fifth;
	}

	public void OnPointerEnter (PointerEventData eventData) {
		transform.localScale = HilightScale;
	}

	public void OnPointerExit (PointerEventData eventData) {
		transform.localScale = LolightScale;
	}

}
