using UnityEngine;

namespace HitMaster.Core.Player.Behaviour {
	public class PlayerBehaviourSystem : MonoBehaviour {
		[SerializeField] private Player player;
		private PlayerState _currentPlayerState;
		
		public Player Player => player;

		private void Start() {
			SetState(new IdleState());
		}

		private void Update() {
			_currentPlayerState.Update();
		}

		public void SetState(PlayerState playerState) {
			if (_currentPlayerState != null) {
				_currentPlayerState.End();
			}
			_currentPlayerState = playerState;
			playerState.BehaviourSystem = this;
			playerState.Start();
		}
	}
}