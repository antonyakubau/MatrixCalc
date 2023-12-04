using System;
namespace MatrixCalc.Model
{
	public class ExceptionManager
	{
        public delegate void ExceptionMessegeEventHandler(Exception exception);

        public static event ExceptionMessegeEventHandler ExceptionMessege;

		public static void ShowExceptionMessege(Exception exception)
        {
            ExceptionMessege?.Invoke(exception);
        }
    }
}

