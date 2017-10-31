namespace Observer
{
	/// <summary>
	/// 数字表示Observer.
	/// </summary>
	public class DigitObserver : IObserverEx
	{
		public void Update(NumberGenerator generator){
			UnityEngine.Debug.Log ("DigitObserver:" + generator.getNumber ()  );
		}
	}
}
