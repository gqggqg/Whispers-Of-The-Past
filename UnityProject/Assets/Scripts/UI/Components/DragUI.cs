using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI {

    [RequireComponent(typeof(RectTransform))]
    public class DragUI : MonoBehaviour, IDragHandler {

        private RectTransform _transform;

        private void Start() {
            _transform = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData) {
            _transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
        }
    }
}
