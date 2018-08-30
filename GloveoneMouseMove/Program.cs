using System;

namespace GloveoneMouseMove
{
	class Program
	{
		static void Main(string[] args)
		{
			MouseMove mouseMove = new MouseMove();
			mouseMove.Initialise();

			Console.WriteLine("Press any key to exit");

			while (!Console.KeyAvailable)
			{
				mouseMove.MoveMouse();
			}
		}
	}
}
