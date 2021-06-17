using System.Collections.Generic;
using UnityEngine;

namespace HitMaster.Core.Weapon {
	/// <summary>
	/// Хранятся неактивные пули, чтобы при необходимости активировать, а не создавать новые. 
	/// После использования пули возвращаются в очередь.
	/// </summary>
	public class BulletPool : MonoBehaviour {
		[SerializeField] private Bullet bulletPrefab;
		[Tooltip("Amount of prespawned bullet")]
		[SerializeField] private int bulletsAmount = 10;

		private readonly Queue<Bullet> _bulletsPool = new Queue<Bullet>();

		private void Awake() {
			FillPool();
		}

		/// <summary>
		/// Взять пулю из очереди
		/// </summary>
		/// <param name="position">Позиция на которую будем возвращать объект</param>
		/// <returns>Объект пуля</returns>
		public Bullet GetBullet(Vector3 position) {
			Bullet bullet;
			if (_bulletsPool.Count == 0) {
				bulletsAmount++;
				bullet = CreateBullet();
			}
			else {
				bullet = _bulletsPool.Dequeue();
			}

			bullet.gameObject.SetActive(true);
			bullet.transform.position = position;
			return bullet;
		}

		/// <summary>
		/// Вернуть объект в очередь
		/// </summary>
		/// <param name="bullet">Пуля которую будем возвращать</param>
		public void ReturnBullet(Bullet bullet) {
			bullet.gameObject.SetActive(false);
			bullet.transform.SetParent(transform);
			bullet.transform.position = transform.position;
			if (_bulletsPool.Equals(null)) {
				Destroy(gameObject);
			}
			_bulletsPool.Enqueue(bullet);
		}

		private void FillPool() {
			for (int i = 0; i < bulletsAmount; i++) {
				_bulletsPool.Enqueue(CreateBullet());
			}
		}

		private Bullet CreateBullet() {
			var bullet = Instantiate(bulletPrefab, transform);
			bullet.transform.SetParent(transform);
			bullet.gameObject.SetActive(false);
			return bullet;
		}
	}
}