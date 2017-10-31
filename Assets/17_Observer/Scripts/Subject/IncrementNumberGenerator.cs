using System;
namespace Observer
{
	public class IncrementNumberGenerator : NumberGenerator
	{
		private int number = 0;

		public override int getNumber ()
		{
			return number;
		}

		public override void execute ()
		{
			++number;
			notifyObservers ();
		}
	}
}
