using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Memento
{
	public class Main : MonoBehaviour
	{
		[SerializeField]
		private Text moneyText;
		[SerializeField]
		private GameObject historyPrefabs;
		[SerializeField]
		private Transform scrollContent;

		[SerializeField]
		private Text diceValueText;
		[SerializeField]
		private Text rewardValueText;

		[SerializeField]
		private Button diceBtn;
		[SerializeField]
		private Button saveBtn;

		private Gamer player;
		private List<Memento> saveDataList;

		private const int INIT_MONEY = 500;
		[SerializeField]
		private int BET_MONEY = 100;

		private void Start ()
		{
			// プレイヤーの初期化 所持金100からスタート.
			player = new Gamer (INIT_MONEY);
			// 初期のセーブデータを保存.
			saveDataList = new List<Memento> ();
			AddSaveData (player.createMemento ());

			#region UI更新
			// 現在の所持金を更新.
			player.ObserveEveryValueChanged (_ => _.Money).Select (m => m.ToString ()).SubscribeToText (moneyText).AddTo (this);
			// ダイス目を更新.
			player.ObserveEveryValueChanged (_ => _.CurDice).Skip (1).Subscribe (d => {
				diceValueText.text = d.ToString ();
				rewardValueText.text = (d % 2 == 0) ? "勝ち" : "負け" ;
			}).AddTo (this);

			diceBtn.OnClickAsObservable ().ThrottleFirst (TimeSpan.FromSeconds (1)).Where (_ => player.Money >= BET_MONEY).Subscribe (_ => {
				player.Bet (BET_MONEY);
			}).AddTo (this);
			saveBtn.OnClickAsObservable ().ThrottleFirst (TimeSpan.FromSeconds (2)).Subscribe (_ => {
				AddSaveData (player.createMemento ());
			}).AddTo (this);
   			#endregion
		}

		private void AddSaveData( Memento m )
		{
			saveDataList.Add (m);

			GameObject obj = Instantiate (historyPrefabs, scrollContent, false) as GameObject;
			obj.SetActive (true);

			obj.GetComponent<RectTransform> ().SetAsFirstSibling ();
			obj.GetComponent<History> ().Initialize (saveDataList.IndexOf (m), m, RestoreSaveData);
		}

		private void RestoreSaveData(int index)
		{
			player.restoreMemeont ( saveDataList[index] );
		}
	}
}
