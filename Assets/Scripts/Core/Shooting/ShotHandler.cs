namespace HitMaster.Core.Shooting {
	abstract class ShotHandler : IHandler {
		private IHandler _nextHandler;

		public IHandler SetNext(IHandler handler) {
			_nextHandler = handler;
			return handler;
		}

		public virtual bool Handle(ShootingData data) {
			if (_nextHandler != null) {
				return _nextHandler.Handle(data);
			}

			return true;
		}
	}
}