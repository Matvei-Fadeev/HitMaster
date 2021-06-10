using System.Collections;

namespace HitMaster.Core.Player.Behaviour {
	public abstract class PlayerState {
		private PlayerBehaviourSystem _system;

		public PlayerBehaviourSystem BehaviourSystem {
			get => _system;
			set => _system = value;
		}

		public virtual void Start() {
			return;
		}

		public virtual void End() {
			return;
		}

		public virtual void Update() {
			return;
		}
	}
}