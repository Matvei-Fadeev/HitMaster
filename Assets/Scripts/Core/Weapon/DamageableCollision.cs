using HitMaster.Core.Health;
using UnityEngine;

namespace HitMaster.Core.Weapon {
	public class DamageableCollision : MonoBehaviour {
		[SerializeField] private int damage = 1;
		
		protected virtual void OnCollisionEnter(Collision collision) {
			var objectHealth = collision.gameObject.GetComponentInParent<HealthComponent>();
			if (objectHealth) {
				objectHealth.Hit(damage);
			}
		}
	}
}