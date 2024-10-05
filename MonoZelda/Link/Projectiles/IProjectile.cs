namespace PixelPushers.MonoZelda.Link.Projectiles;

public interface IProjectile
{
	void updateProjectile();

	bool hasFinished();

	bool reachedDistance();
}
