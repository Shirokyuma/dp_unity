using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Observer
{
	public class Main : MonoBehaviour
	{
		[SerializeField]
		private Text incText;
		[SerializeField]
		private Button incBtn;

		void Start()
		{
			NumberGenerator generator = new RandomNumberGenerator ();
			IObserverEx digitObserver = new DigitObserver ();
			IObserverEx graphObserver = new GraphObserver ();
			generator.addObserver (digitObserver);
			generator.addObserver (graphObserver);

			generator.execute ();


			NumberGenerator generator_2 = new IncrementNumberGenerator ();
			//IObserverEx textObserver = new TextObserver (incText);
			//generator_2.addObserver (textObserver);
			generator_2.ObserveEveryValueChanged (_ => _.getNumber ()).Select (inc => inc.ToString ()).SubscribeToText (incText).AddTo (this);
			incBtn.OnClickAsObservable ().Subscribe (_ => generator_2.execute ()).AddTo (this);
		}
	}
}
