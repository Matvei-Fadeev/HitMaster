using UnityEngine;

namespace HitMaster.Input {
	public static class TouchInputHandler {
		public static Vector2 GetTouchPosition() {
			if (HasTouch()) {
				return UnityEngine.Input.GetTouch(0).position;
			}

			return Vector2.zero;
		}

		public static bool HasTouch() {
			return UnityEngine.Input.touchCount > 0;
		}
	}
}