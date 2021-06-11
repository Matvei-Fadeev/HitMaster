using UnityEngine;

namespace HitMaster.Input {
	public static class TouchInputHandler {
		private static Camera _camera;
		
		public static Vector2 GetTouchedScreenPosition() {
			if (HasTouch()) {
				return UnityEngine.Input.GetTouch(0).position;
			}

			return Vector2.zero;
		}

		public static bool HasTouch() {
			return UnityEngine.Input.touchCount > 0;
		}
		
		public static Vector3 GetTouchedWorldPoint() {
			if (!_camera) {
				_camera = Camera.main;
			}

			var hitPosition = Vector3.zero;

			Vector2 touchPosition = GetTouchedScreenPosition();
			Ray ray = _camera.ScreenPointToRay(touchPosition);
			if (Physics.Raycast(ray, out var hitInfo, 1000)) {
				hitPosition = hitInfo.point;
			}

			return hitPosition;
		}
	}
}