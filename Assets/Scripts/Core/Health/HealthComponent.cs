using System;
using UnityEngine;

namespace HitMaster.Core.Health {
	public class HealthComponent : MonoBehaviour {
		public event Action HasDying;
		public event Action<int> HasChangeHP;

		[SerializeField] private int health;

		public int Health {
			get => health;
			set {
				health = value < 0 ? 0 : value;
				HasChangeHP?.Invoke(health);
				if (health == 0) {
					Dying();
				}
			}
		}

		private void Dying() {
			HasDying?.Invoke();
		}

		public void Hit(int damage) {
			Health -= damage;
		}
	}
}