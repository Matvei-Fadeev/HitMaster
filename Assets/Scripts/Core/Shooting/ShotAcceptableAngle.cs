using UnityEngine;

namespace HitMaster.Core.Shooting {
	class ShotAcceptableAngle : ShotHandler {
		private float maxAcceptableAngle = 80;

		public override bool Handle(ShootingData data) {
			var directionToShot = data.endPosition - data.startPosition;
			var angle = Vector3.Angle(directionToShot, data.lookingDirection);
			if (angle > maxAcceptableAngle) {
				return false;
			}

			return base.Handle(data);
		}
	}
}