using System.Text;
namespace Observer
{
	/// <summary>
	/// グラフObserver.
	/// </summary>
	public class GraphObserver : IObserverEx
	{
		public void Update(NumberGenerator generator)
		{
			StringBuilder sb = new StringBuilder ();

			for (int i = 0; i < generator.getNumber (); i++)
				sb.Append ("*");

			UnityEngine.Debug.Log ("GraphObserver:" + sb);
		}
	}
}
