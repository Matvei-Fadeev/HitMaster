using HitMaster.Core.Health;
using UnityEngine;

namespace HitMaster.Core.Weapon {
	[RequireComponent(typeof(BoxCollider))]
	public class DamagingCollision : MonoBehaviour {
		[SerializeField] private int damage = 1;
		
		/// <param name="collision">Объект, которому будет наноситься урон при коллизии</param>
		protected virtual void OnCollisionEnter(Collision collision) {
			var objectHealth = collision.gameObject.GetComponentInParent<HealthComponent>();
			if (objectHealth) {
				objectHealth.Hit(damage);
			}
		}
	}
}