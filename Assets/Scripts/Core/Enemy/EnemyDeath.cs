using HitMaster.Core.Health;
using UnityEngine;

namespace HitMaster.Core.Enemy {
	public class EnemyDeath : MonoBehaviour {
		[SerializeField] private RagdollKinematicController _ragdollKinematicController;
		[SerializeField] private HealthComponent _healthComponent;

		private bool _hasDeath;

		public bool HasDeath => _hasDeath;

		private void OnEnable() {
			_healthComponent.HasDying += OnDying;
		}

		private void OnDisable() {
			_healthComponent.HasDying -= OnDying;
		}

		private void OnDying() {
			_ragdollKinematicController.SetPhysical();
			_hasDeath = true;
		}
	}
}