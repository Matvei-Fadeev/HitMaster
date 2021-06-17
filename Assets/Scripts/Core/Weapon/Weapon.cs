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
		public event Action HavingShot;

		[Header("Weapon configuration")]
		[SerializeField] private float shotDelay = 0.5f;

		[Header("Dependent Objects")]
		[SerializeField] private ShootingController _shootingController;
		[SerializeField] private BulletPool bulletPool;

		private float _timeOfShot;

		private void Update() {
			if (_shootingController.HasShotInput() && (Time.time - _timeOfShot) > shotDelay) {
				_timeOfShot = Time.time;
				TryTakeShot();
			}
		}

		private void TryTakeShot() {
			Vector3 bulletSpawnPosition = transform.position;
			Vector3 endPosition = TouchInputHandler.GetTouchedWorldPoint();
			Vector3 bulletDirection = (endPosition - bulletSpawnPosition).normalized;

			bool canShot = _shootingController.CanShot(bulletSpawnPosition, transform.forward, endPosition);
			if (canShot) {
				HavingShot?.Invoke();
				TakeShot(bulletSpawnPosition, bulletDirection);
			}
		}
		
		private void TakeShot(Vector3 bulletSpawnPosition, Vector3 bulletDirection) {
			Bullet bullet = bulletPool.GetBullet(bulletSpawnPosition);
			bullet.Shoot(bulletDirection);
		}
	}
}