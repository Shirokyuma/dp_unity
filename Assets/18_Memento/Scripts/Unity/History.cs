using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

namespace Memento
{
	public class History : MonoBehaviour
	{
		[SerializeField]
		private Text indexText;
		[SerializeField]
		private Text moneyText;

		[SerializeField]
		private Button btn;

		public void Initialize( int index, Memento m, UnityAction<int> clickEvent )
		{
			indexText.text = index.ToString ();
			moneyText.text = m.Money.ToString ();

			btn.OnClickAsObservable ().Subscribe (_ => clickEvent (index)).AddTo (this);
		}
	}
}