using System;
namespace MatrixCalc.Model
{
	public class ExceptionManager
	{
        public delegate void ExceptionDelegate(Exception exception);

        public static event ExceptionDelegate ExceptionMessege;

		public static void ShowExceptionMessege(Exception exception)
        {
            ExceptionMessege?.Invoke(exception);
        }
    }
}

