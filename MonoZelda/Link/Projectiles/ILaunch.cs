namespace PixelPushers.MonoZelda.Link.Projectiles;

public interface ILaunch
{
	
	void Launch();

	bool hasFinished();

	bool reachedDistance();
}
