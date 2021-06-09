using UnityEngine;
using UnityEngine.AI;

namespace HitMaster.Core.Player {
	public class MovementToWaypoints : MonoBehaviour {
		[SerializeField] private Transform[] points;

		private NavMeshAgent _navMeshAgent;
		private int _currentPoint;

		private void Awake() {
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		[ContextMenu(nameof(GoToNextPoint))]
		private void GoToNextPoint() {
			if (_currentPoint < points.Length) {
				GoToPoint(points[_currentPoint].position);
				_currentPoint++;
			}
			else {
				Debug.LogWarning("Object at the last point");
			}
		}

		private void GoToPoint(Vector3 point) {
			_navMeshAgent.SetDestination(point);
		}
	}
}