using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Memento
{
	/// <summary>
	/// ゲーム実行クラス.
	/// </summary>
	public class Gamer
	{
		private System.Random random = new System.Random ();

		public Gamer (int money)
		{
			this.Money 	= money;
			this.CurDice 	= 0;
		}

		public int Money { get; private set; }

		public int CurDice { get; private set; }

		public ReactiveProperty<int> DiceResult { get; private set; }

		/// <summary>
		/// 賭け実行.
		/// </summary>
		/// <returns>The bet.</returns>
		/// <param name="money">Money.</param>
		public void Bet (int money)
		{
			this.CurDice = random.Next (6) + 1;

			if(this.CurDice %2 == 0)
			{
				// 偶数なので増える.
				this.Money += money;
			} 
			else 
			{
				// 奇数なので減る.
				this.Money -= money;
			}
		}

		public Memento createMemento ()
		{
			Memento m = new Memento (this.Money);
			return m;
		}
		public void restoreMemeont(Memento memento)
		{
			this.Money = memento.Money;
		}

	}
}