using UnityEngine;

namespace HitMaster.Core.Player {
	public class InputHandler : MonoBehaviour {
		public Vector2 GetTouchPosition() {
			// TODO Remove
			if (Input.GetButtonDown("Fire1")) {
				return Vector2.one;
			}
			
			if (Input.touchCount > 0) {
				return Input.GetTouch(0).position;
			}
			
			return Vector2.zero;
		}
		
		public bool HasInput() {
			return GetTouchPosition() != Vector2.zero;
		}
	}
}