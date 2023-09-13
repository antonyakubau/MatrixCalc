using System;
namespace MatrixCalc.Model
{
	public class EventUpdateMainMatrix
	{
		public delegate void Handler();

		public static event Handler UpdateMatrix;

		public static void Update()
		{
			if (UpdateMatrix != null)
			{
                UpdateMatrix();
			}
		}
    }
}

