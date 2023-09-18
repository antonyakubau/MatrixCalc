using System;
namespace MatrixCalc.Model
{
	public class ExceptionHandler
	{
        public delegate void ExceptionDelegate(Exception exception);

        public static ExceptionDelegate ExceptionMessege;

	}
}

