using System;

namespace PixelPushers.MonoZelda.Projectiles;

public interface IProjectile
{
	// To-do add parameters like player position, type of item ....
	void LaunchProjectile();
}
