using UnityEngine;

namespace HitMaster.Core.Enemy {
	public class RagdollKinematicController : MonoBehaviour {
		[SerializeField] private Animator animator;
		[SerializeField] private Rigidbody[] rigidbodies;

		private void Awake() {
			SetRigidbodyKinematic(true);
		}

		public void SetPhysical() {
			animator.enabled = false;
			SetRigidbodyKinematic(false);
		}

		private void SetRigidbodyKinematic(bool isKinematic) {
			foreach (var currentRigidbody in rigidbodies) {
				currentRigidbody.isKinematic = isKinematic;
			}
		}
	}
}