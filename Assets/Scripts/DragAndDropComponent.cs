using UnityEngine;
using UnityEngine.EventSystems;

namespace HatTrick {


// put this on an object to enable mouse dragging and dropping
public class DragAndDropComponent : MonoBehaviour, 
	IPointerEnterHandler, IPointerExitHandler,
	IBeginDragHandler, IDragHandler, IEndDragHandler {

	// make these static. assuming, of course, that only one mouse pointer exists, this shouldn't cause conflicts, and acts singleton-y
	public static bool Dragging { get; private set; }
	public static bool MouseIsOver { get; private set; }
	public static PointerEventData LastPointerEvent {
		get {
			var tmp = _lastPointerEvent;
			if (_lastPointerEvent != null)
				_lastPointerEvent = null;
			return tmp;
		}
	}

	private Vector2 posCache;
	private static PointerEventData _lastPointerEvent;

	public void OnPointerEnter (PointerEventData eventData) {
		MouseIsOver = true;
	}

	public void OnPointerExit (PointerEventData eventData) {
		MouseIsOver = false;
	}

	public void OnBeginDrag (PointerEventData eventData) {
		posCache = transform.position;
		Dragging = true;
	}

	public void OnDrag (PointerEventData eventData) {
		transform.position = eventData.position;
	}

	// TODO: make this animated instead of instantaneous
	public void OnEndDrag (PointerEventData eventData) {
		transform.position = posCache;
		Dragging = false;
	}

}

}