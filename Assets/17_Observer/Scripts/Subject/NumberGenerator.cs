using System;
using System.Collections.Generic;

namespace Observer
{
	/// <summary>
	/// 数字を生成する抽象クラス.
	/// </summary>
	public abstract class NumberGenerator
	{
		// 実行するObserver
		private List<IObserverEx> observers = new List<IObserverEx> ();
		// 実行するObserver追加.
		public void addObserver(IObserverEx observer)
		{
			observers.Add (observer);
		}

		public void deleteObservers(IObserverEx observer){
			observers.Remove (observer);
		}
		// Observer実行.
		public void notifyObservers(){
			foreach(IObserverEx observer in observers)
			{
				observer.Update (this);
			}
		}

		// 数字を返す.
		public abstract int getNumber();
		// 実行メソッド.
		public abstract void execute ();
	}
}