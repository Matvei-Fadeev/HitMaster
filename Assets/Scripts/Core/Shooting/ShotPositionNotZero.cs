using UnityEngine;

namespace HitMaster.Core.Shooting {
	class ShotPositionNotZero : ShotHandler {
		public override bool Handle(ShootingData data) {
			if (data.endPosition == Vector3.zero) {
				return false;
			}

			return base.Handle(data);
		}
	}
}