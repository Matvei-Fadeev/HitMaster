using UnityEngine;
using UnityEngine.AI;

namespace HitMaster.Core.Player {
	public class MovementToWaypoints : MonoBehaviour {
		[SerializeField] private Transform point;

		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Start() {
			GoToPoint(point.position);
			Stop();
		}

		public bool HasFinish() {
			if (HasStop()) {
				return _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete;
			}
			return false;
		}

		[ContextMenu(nameof(Resume))]
		public void Resume() {
			if (_navMeshAgent.isStopped) {
				_navMeshAgent.isStopped = false;
			}
			else if (!HasFinish()) {
				GoToPoint(point.position);
			}
		}

		[ContextMenu(nameof(Stop))]
		public void Stop() {
			_navMeshAgent.isStopped = true;
		}

		public bool HasStop() {
			return _navMeshAgent.isStopped;
		}

		private void GoToPoint(Vector3 position) {
			_navMeshAgent.SetDestination(position);
		}
	}
}