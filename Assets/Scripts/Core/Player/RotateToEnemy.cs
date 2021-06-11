using DG.Tweening;
using HitMaster.Core.Enemy;
using UnityEngine;

namespace HitMaster.Core.Player {
	public class RotateToEnemy : MonoBehaviour {
		[SerializeField] private EnemyFinder enemyFinder;
		[SerializeField] private Vector3 offsetFromEnemy;
		[SerializeField] private float rotationDuration;
		
		private Transform _closestEnemy;	

		private void FixedUpdate() {
			if (enemyFinder.HasEnemyInRadius()) {
				if (!_closestEnemy || _closestEnemy.GetHashCode() != enemyFinder.ClosestEnemy.GetHashCode()) {
					_closestEnemy = enemyFinder.ClosestEnemy;
					transform.DOLookAt(_closestEnemy.position + offsetFromEnemy, rotationDuration);
				}
			}
		}
	}
}