using UnityEngine;
using System.Collections;

namespace Singleton
{
	public class Manager : UnitySingleton<Manager>
	{
		public int count { get; private set; }

		[SerializeField]
		private GameObject prefab;


		private void Start ()
		{
			count = 0;
			if (prefab == null)
				prefab = new GameObject ();
		}

		public void CreateObj ()
		{
			GameObject ins = Instantiate (prefab) as GameObject;
			ins.name = count.ToString ();
			ins.SetActive (true);

			count++;

		}
	}
}