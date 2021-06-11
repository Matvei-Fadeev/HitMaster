using UnityEngine;

namespace HitMaster.Core.Enemy {
	public class EnemyFinder : MonoBehaviour {
		[Header("Enemies")]
		[SerializeField] private EnemyDeath[] enemies;

		[Header("Configuration")]
		[SerializeField] private float radius = 10f;
		[SerializeField] private float delayBetweenChecks = 0.5f;

		private bool _hasEnemyAtLastCheck;
		private float _timeSinceLastCheck;
		private Transform _closestEnemy;

		public Transform ClosestEnemy => _closestEnemy;

		private void OnDrawGizmos() {
			Gizmos.color = Color.magenta;
			Gizmos.DrawWireSphere(transform.position, radius);
		}

		public bool HasEnemyInRadius() {
			_timeSinceLastCheck += Time.deltaTime;
			if (_timeSinceLastCheck > delayBetweenChecks) {
				_hasEnemyAtLastCheck = CheckForEnemy();
				_timeSinceLastCheck = 0f;
			}

			return _hasEnemyAtLastCheck;
		}

		private bool CheckForEnemy() {
			var selfPosition = transform.position;
			var sqrtRadius = radius * radius;
			var enemiesCount = enemies.Length;
			for (int i = 0; i < enemiesCount; i++) {
				if (enemies[i]) {
					var checkByPosition = (enemies[i].transform.position - selfPosition).sqrMagnitude < sqrtRadius;
					if (checkByPosition && !enemies[i].HasDeath) {
						_closestEnemy = enemies[i].transform;
						return true;
					}
				}
			}

			return false;
		}

		[ContextMenu(nameof(SetEnemies))]
		private void SetEnemies() {
			enemies = FindObjectsOfType<EnemyDeath>();
		}
	}
}