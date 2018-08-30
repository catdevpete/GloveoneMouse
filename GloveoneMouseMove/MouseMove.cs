using System;
using System.Windows;
using System.Threading;
using NDAPIWrapperSpace;

namespace GloveoneMouseMove
{
	public class MouseMove
	{
		Win32.POINT p;
		NDAPI nd;
		int[] devices;

		int height;
		int width;

		public void Initialise()
		{
			p = new Win32.POINT();
			p.x = 0;
			p.y = 0;

			height = Convert.ToInt32(SystemParameters.PrimaryScreenHeight) * 2;
			width = Convert.ToInt32(SystemParameters.PrimaryScreenWidth) * 2;

			//instance of library
			nd = new NDAPI();

			//variable to get result value
			int res = 0;

			//connect with service NDSvc
			res = nd.connectToServer();

			if (res == (int)Error.ND_ERROR_SERVICE_UNAVAILABLE)
			{
				Console.WriteLine("Error: Service Unavailable");
			}
			else
			{
				int numDevices = nd.getNumberOfDevices();

				devices = new int[numDevices];
				nd.getDevicesId(devices);
			}
		}

		public void MoveMouse()
		{
			vector3d_t vector = new vector3d_t();

			nd.getPalmAcceleration(ref vector, devices[0]);


			if (Math.Abs(vector.x) <= 0.15)
				vector.x = 0;

			if (Math.Abs(vector.z) <= 0.15)
				vector.z = 0;


			if (vector.x >= 0.2 && vector.x <= 0.4)
				vector.x -= (float)0.2;

			if (vector.x <= -0.2 && vector.x >= -0.4)
				vector.x += (float)0.2;

			if (vector.z >= 0.2 && vector.x <= 0.4)
				vector.z -= (float)0.2;

			if (vector.z <= -0.2 && vector.x >= -0.4)
				vector.z += (float)0.2;


			if (vector.x >= 0.75 || vector.x <= -0.75)
				vector.x *= (float)3;

			if (vector.z >= 0.75 || vector.z <= -0.75)
				vector.z *= (float)4;


			p.x += (int)Math.Round(vector.x * 10);
			p.y -= (int)Math.Round(vector.z * 10);

			if (p.x < 0)
				p.x = 0;

			if (p.y < 0)
				p.y = 0;

			if (p.x > width)
				p.x = width;

			if (p.y > height)
				p.y = height;

			Win32.SetCursorPos(p.x, p.y);

			Thread.Sleep(5);
		}
	}
}
