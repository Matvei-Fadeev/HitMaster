using HitMaster.Input;
using UnityEngine;

namespace HitMaster.Core.Shooting {
	/// <summary>
	/// Using the chain of responsobility pattern to check the shot
	/// </summary>
	public class ShootingController : MonoBehaviour {
		private ShootingData _shootingData;

		private ShotHandler _shotHandler;

		private void Start() {
			ShotPositionNotZero shotPositionNotZero = new ShotPositionNotZero();
			ShotAcceptableAngle shotAcceptableAngle = new ShotAcceptableAngle();

			_shotHandler = shotPositionNotZero;
			_shotHandler.SetNext(shotAcceptableAngle);
		}

		public bool CanShot(Vector3 startPosition, Vector3 lookingDirection, Vector3 endPosition) {
			_shootingData.startPosition = startPosition;
			_shootingData.lookingDirection = lookingDirection;
			_shootingData.endPosition = endPosition;

			var canShooting = _shotHandler.Handle(_shootingData);
			return canShooting;
		}

		// The simplest check for shooting
		public bool HasShotInput() {
			return TouchInputHandler.HasTouch();
		}
	}
}