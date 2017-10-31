﻿using System;

namespace Observer
{
	/// <summary>
	/// ランダムな数字を返す.
	/// </summary>
	public class RandomNumberGenerator : NumberGenerator
	{
		public Random random = new Random ();
		private int number;

		public override int getNumber (){
			return number;
		}
		public override void execute(){
			for (int i = 0; i < 20; i++){
				number = random.Next (50);
				notifyObservers ();
			}
		}
	}
}
