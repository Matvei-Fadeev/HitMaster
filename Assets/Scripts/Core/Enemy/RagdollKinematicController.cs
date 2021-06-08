using UnityEngine;

namespace HitMaster.Core.Enemy {
	public class RagdollKinematicController : MonoBehaviour {
		[SerializeField] private Animator _animator;
		[SerializeField] private Rigidbody[] _rigidbodies;

		private void Awake() {
			SetRigidbodyKinematic(true);
		}

		[ContextMenu("SetPhysical")]
		public void SetPhysical() {
			_animator.enabled = false;
			SetRigidbodyKinematic(false);
		}

		private void SetRigidbodyKinematic(bool isKinematic) {
			foreach (var currentRigidbody in _rigidbodies) {
				currentRigidbody.isKinematic = isKinematic;
			}
		}
	}
}