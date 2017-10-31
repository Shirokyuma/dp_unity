using UnityEngine;
using System.Collections;

namespace Singleton
{
	public class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
	{
		private static T _instance = null;

		public static T Instance {
			get {
				if (_instance == null) 
				{
					string objName = typeof (T).ToString ();
					GameObject obj = GameObject.Find (objName);
					if (obj == null)
						obj = GameObject.Find (objName + "(Clone)");

					if(obj == null)
					{
						obj = new GameObject ( objName );
					}

					_instance = obj.GetComponent<T> ();
					if (_instance == null)
						_instance = obj.AddComponent<T> ();

					DontDestroyOnLoad (obj);
				}
				return _instance;
			}
		}

		protected virtual void Awake ()
		{
			CheckInstance ();
		}

		protected bool CheckInstance()
		{
			if (_instance == null) {
				_instance = (T)this;
				return true;
			} else if (Instance == this)
				return true;

			Destroy (Instance);
			return false;
		}

		private void OnApplicationQuit()
		{
			_instance = null;
		}

	}
}