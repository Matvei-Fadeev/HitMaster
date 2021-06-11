namespace HitMaster.Core.Player.Behaviour {
	internal class AimState : PlayerState {
		public override void Start() {
			BehaviourSystem.Player.AnimationStateController.IsAim = true;
			BehaviourSystem.Player.MovementToWaypoints.Stop();
		}
		
		public override void Update() {
			if (!BehaviourSystem.Player.EnemyFinder.HasEnemyInRadius()) {
				BehaviourSystem.Player.AnimationStateController.IsAim = false;
				BehaviourSystem.SetState(new RunningState());
			}
		}
	}
}