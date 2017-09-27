using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//class that handles rendered cards and their interaction with input
public class CardVisuals : MonoBehaviour, 
	IPointerEnterHandler, IPointerExitHandler,
	IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Vector2 HilightScale; //size when mousing over in hand
	public Vector2 LolightScale; //size when not mousing over

	private Text placeholder;
	private Vector2 posCache;

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

	public void OnBeginDrag (PointerEventData eventData) {
		posCache = transform.position;
	}

	public void OnDrag (PointerEventData eventData) {
		transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData) {
		transform.position = posCache;
	}
}
