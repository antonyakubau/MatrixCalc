using System;
namespace MatrixCalc.Model
{
	public class ExceptionManager
	{
        public delegate void ExceptionDelegate(Exception exception);

        public static ExceptionDelegate ExceptionMessege;

	}
}

