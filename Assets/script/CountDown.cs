using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {
	// カウントダウン時間
	const int FPS = 30;
	int _count_down = 4 * FPS;

	// スプライト表示用オブジェクト(プレハブ)
	[SerializeField] private GameObject showSprite = null;

	// 数字スプライト
	[SerializeField] private Sprite _0 = null;
	[SerializeField] private Sprite _1 = null;
	[SerializeField] private Sprite _2 = null;
	[SerializeField] private Sprite _3 = null;
	// hit表示のためにずらす距離
	[SerializeField] private float _offset = 3;
	// 数字の表示間隔
	[SerializeField] private float _width = 1.6f;

	private int showValue = 0;  // 表示する値

	private GameObject[] numSpriteGird;         // 表示用スプライトオブジェクトの配列
	private Dictionary<char, Sprite> dicSprite; // スプライトディクショナリ

	// スプライトディクショナリを初期化する
	void Awake() {
		dicSprite = new Dictionary<char, Sprite> () {
			{ '0', _0 },
			{ '1', _1 },
			{ '2', _2 },
			{ '3', _3 }
		};
	}

	// 表示する値
	int Value {
		get {
			return showValue;
		}
		set {
			showValue = value;

			// 表示文字列取得
			string strValue = value.ToString();

			// 現在表示中のオブジェクト削除
			if ( numSpriteGird != null ) {
				foreach ( var numSprite in numSpriteGird ) {
					GameObject.Destroy(numSprite);
				}
			}

			// 表示桁数分だけオブジェクト作成
			numSpriteGird = new GameObject[strValue.Length];
			for ( int i = 0; i < numSpriteGird.Length; i++ ) {
				// オブジェクト作成
				float offset = -( (float)i * _width + _offset);
				numSpriteGird[i] = Instantiate(
					showSprite,
					transform.position + new Vector3( offset, 0),
					Quaternion.identity) as GameObject;

				// 一番左の数値を取得
				int num = numSpriteGird.Length - i - 1;
				// 表示する数値指定
				numSpriteGird[i].GetComponent<SpriteRenderer>().sprite = dicSprite[strValue[num]];

				// 自身の子階層に移動
				numSpriteGird[i].transform.parent = transform;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_count_down--;
		if (_count_down / FPS < 0) {
			Time.timeScale = 1.0f;
			Destroy (gameObject);
		}

		if ( ( _count_down / FPS ) != Value) {
			Value =_count_down / FPS;
		}
	}
}
