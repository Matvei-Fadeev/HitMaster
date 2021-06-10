namespace HitMaster.Core.Player.Behaviour {
	internal class RunningState : PlayerState {
		public override void Start() {
			BehaviourSystem.Player.AnimationStateController.IsRunning = true;

			if (BehaviourSystem.Player.MovementToWaypoints.HasStop()) {
				BehaviourSystem.Player.MovementToWaypoints.Resume();
			}
		}

		public override void Update() {
			if (BehaviourSystem.Player.EnemyFinder.HasEnemyInRadius()) {
				BehaviourSystem.SetState(new AimState());
			}
			else if (BehaviourSystem.Player.MovementToWaypoints.HasFinish()) {
				BehaviourSystem.SetState(new IdleState());
			}
		}
		
		public override void End() {
			BehaviourSystem.Player.AnimationStateController.IsRunning = false;
			BehaviourSystem.Player.MovementToWaypoints.Stop();
		}
	}
}