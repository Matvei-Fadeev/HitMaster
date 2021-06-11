namespace HitMaster.Core.Player.Behaviour {
	internal class IdleState : PlayerState {
		public override void Start() {
			BehaviourSystem.Player.MovementToWaypoints.Stop();
		}

		public override void Update() {
			if (BehaviourSystem.Player.EnemyFinder.HasEnemyInRadius()) {
				BehaviourSystem.SetState(new AimState());
			}
			else if (!BehaviourSystem.Player.MovementToWaypoints.HasStop()) {
				BehaviourSystem.SetState(new RunningState());
			}
		}
	}
}