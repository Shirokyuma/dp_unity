using System;
using UnityEngine.UI;

namespace Observer
{
	public class TextObserver : IObserverEx
	{
		private Text numText;

		public TextObserver(Text text)
		{
			this.numText = text;
		}

		public void Update(NumberGenerator generator)
		{
			this.numText.text = generator.getNumber ().ToString ();
		}
	}
}
