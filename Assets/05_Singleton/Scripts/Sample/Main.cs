using UnityEngine;
using System.Collections;

using UniRx;

namespace Singleton
{
	public class Main : MonoBehaviour
	{
		// Use this for initialization
		void Start ()
		{
			Manager manager = Manager.Instance;
			Observable.Interval (System.TimeSpan.FromSeconds (1f)).Take (10).Subscribe ( _ => manager.CreateObj () ).AddTo (this.gameObject);
		}

	}
}