using System;
namespace MatrixCalc.Model
{
	public class EventHandlerDemo
	{
		public delegate void Handler();

		public static event Handler handler;

		public static void Update()
		{
			if (handler != null)
			{
				handler();
			}
		}
    }
}

