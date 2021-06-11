namespace HitMaster.Core.Shooting {
	public interface IHandler {
		IHandler SetNext(IHandler handler);

		bool Handle(ShootingData data);
	}
}