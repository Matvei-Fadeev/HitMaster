using System.Collections;
using UnityEngine;

namespace HitMaster.Core.Weapon {
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(BoxCollider))]
	public class Bullet : DamageableCollision {
		[SerializeField] private float speed = 10f;
		[SerializeField] private float maxLifetime = 2f;
		[SerializeField] private float invulnerableTime = 0.1f;

		private BulletPool _bulletPool;
		private Rigidbody _rigidbody;
		private Collider _collider;
		private WaitForSeconds _invulnerableDelay;

		private void Awake() {
			_bulletPool = GetComponentInParent<BulletPool>();
			_rigidbody = GetComponent<Rigidbody>();
			_collider = GetComponent<Collider>();
			_invulnerableDelay = new WaitForSeconds(invulnerableTime);
		}

		protected override void OnCollisionEnter(Collision collision) {
			base.OnCollisionEnter(collision);
			ReturnToPool();
		}

		/// <summary>
		/// Привести пулю в движение
		/// </summary>
		/// <param name="direction">Направление в котором полетит пуля</param>
		public void Shoot(Vector3 direction) {
			transform.SetParent(null);
			_rigidbody.velocity = direction * speed;
			StartCoroutine(MakeTemporarilyInvulnerable());
			Invoke(nameof(ReturnToPool), maxLifetime);
		}

		private void ReturnToPool() {
			if (_bulletPool) {
				_bulletPool.ReturnBullet(this);
			}
			else {
				Destroy(gameObject);
			}
		}

		private IEnumerator MakeTemporarilyInvulnerable() {
			_collider.enabled = false;
			yield return _invulnerableDelay;
			_collider.enabled = true;
		}
	}
}