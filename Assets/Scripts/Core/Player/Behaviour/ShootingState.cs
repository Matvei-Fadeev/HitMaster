namespace HitMaster.Core.Player.Behaviour {
	internal class ShootingState : PlayerState {
		public override void Start() {
			BehaviourSystem.Player.AnimationStateController.Shooting();
		}

		public override void Update() {
			if (!BehaviourSystem.Player.InputHandler.HasInput()) {
				BehaviourSystem.SetState(new AimState());
			}
		}
	}
}