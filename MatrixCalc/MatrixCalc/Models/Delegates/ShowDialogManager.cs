using System;
namespace MatrixCalc.Models
{
	public class ShowDialogManager
	{
        public delegate void ShowUpdateDelegate();
        public static ShowUpdateDelegate ShowMatrixUpdated;

        public delegate void ShowMessegeDelegate(int sum, int min, int max, int everage);
        public static ShowMessegeDelegate ShowMatrixMessege;

    }
}

