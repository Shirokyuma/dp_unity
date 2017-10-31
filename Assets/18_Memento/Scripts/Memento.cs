using System.Collections.Generic;

namespace Memento
{
	/// <summary>
	/// セーブデータクラス
	/// </summary>
	public class Memento
	{
		public Memento (int money)
		{
			this.money = money;
		}

		private int money;
		public int Money { get { return money; } }
	}
}