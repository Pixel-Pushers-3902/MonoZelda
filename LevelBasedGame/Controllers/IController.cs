using System;

public interface IController
{
	Boolean Quit { get; set; }

	Boolean Update();
}
