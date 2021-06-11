using HitMaster.Core.Enemy;
using UnityEngine;

namespace HitMaster.Core.Player {
	public class Player : MonoBehaviour {
		[SerializeField] private PlayerAnimationStateController _playerAnimationStateController;
		[SerializeField] private EnemyFinder _enemyFinder;
		[SerializeField] private MovementToWaypoints _movementToWaypoints;
		[SerializeField] private Weapon.Weapon _weapon;
		
		public EnemyFinder EnemyFinder => _enemyFinder;
		public PlayerAnimationStateController AnimationStateController => _playerAnimationStateController;
		public MovementToWaypoints MovementToWaypoints => _movementToWaypoints;
		public Weapon.Weapon Weapon => _weapon;
	}
}