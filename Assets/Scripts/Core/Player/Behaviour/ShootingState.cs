using HitMaster.Input;

namespace HitMaster.Core.Player.Behaviour {
	internal class ShootingState : PlayerState {
		public override void Start() {
			BehaviourSystem.Player.AnimationStateController.Shooting();
		}

		public override void Update() {
			if (!TouchInputHandler.HasTouch()) {
				BehaviourSystem.SetState(new AimState());
			}
		}
	}
}