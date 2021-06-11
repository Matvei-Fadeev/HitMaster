using System;
using HitMaster.Core.Shooting;
using HitMaster.Input;
using UnityEngine;

namespace HitMaster.Core.Weapon {
	/// <summary>
	/// Объекты данного класса отвечают за стрельбу пулями.
	/// Берут из очереди пули, и выстреливает в нужном направлении.
	/// </summary>
	public class Weapon : MonoBehaviour {
		public event Action HasShot; 
		
		[Header("Weapon configuration")]
		[SerializeField] private float shotDelay = 0.5f;

		[Header("Dependent Objects")]
		[SerializeField] private ShootingController _shootingController;
		[SerializeField] private BulletPool bulletPool;

		private float _timeOfShot;

		private void Update() {
			if (TouchInputHandler.HasTouch()) {
				TakeShot();
			}
		}

		private void TakeShot() {
			if ((Time.time - _timeOfShot) > shotDelay) {
				_timeOfShot = Time.time;
				
				var bulletSpawnPosition = transform.position;
				var endPosition = TouchInputHandler.GetTouchedWorldPoint();
				var bulletDirection = endPosition - bulletSpawnPosition;

				var canShot = _shootingController.CanShot(bulletSpawnPosition, transform.forward, endPosition);

				if (canShot) {
					HasShot?.Invoke();
					var bullet = bulletPool.GetBullet(bulletSpawnPosition);
					bullet.Shoot(bulletDirection);
				}
			}
		}
	}
}