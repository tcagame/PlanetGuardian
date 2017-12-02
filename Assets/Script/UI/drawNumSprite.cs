using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawNumSprite : MonoBehaviour {
	// スプライト表示用オブジェクト(プレハブ)
	[SerializeField]
	private GameObject showSprite = null;

	// 数字スプライト
	[SerializeField]
	private Sprite _0 = null;
	[SerializeField]
	private Sprite _1 = null;
	[SerializeField]
	private Sprite _2 = null;
	[SerializeField]
	private Sprite _3 = null;
	[SerializeField]
	private Sprite _4 = null;
	[SerializeField]
	private Sprite _5 = null;
	[SerializeField]
	private Sprite _6 = null;
	[SerializeField]
	private Sprite _7 = null;
	[SerializeField]
	private Sprite _8 = null;
	[SerializeField]
	private Sprite _9 = null;
	// hit表示のためにずらす距離
	[SerializeField]
	private float _offset = 3;
	// 数字の表示間隔
	[SerializeField]
	private float _width = 1.6f;
	// レイヤーの指定
	[SerializeField]
	private int _layer = 0;

	private int showValue = 0;  // 表示する値

	private GameObject[ ] numSpriteGird;         // 表示用スプライトオブジェクトの配列
	private Dictionary<char, Sprite> dicSprite; // スプライトディクショナリ

	// スプライトディクショナリを初期化する
	void Awake( ) {
		dicSprite = new Dictionary<char, Sprite>( ) {
			{ '0', _0 },
			{ '1', _1 },
			{ '2', _2 },
			{ '3', _3 },
			{ '4', _4 },
			{ '5', _5 },
			{ '6', _6 },
			{ '7', _7 },
			{ '8', _8 },
			{ '9', _9 },
		};
	}

	// 表示する値
	public int Value {
		get {
			return showValue;
		}
		set {
			showValue = value;

			// 表示文字列取得
			string strValue = value.ToString( );

			// 現在表示中のオブジェクト削除
			if ( numSpriteGird != null ) {
				foreach ( var numSprite in numSpriteGird ) {
					GameObject.Destroy( numSprite );
				}
			}

			// 表示桁数分だけオブジェクト作成
			numSpriteGird = new GameObject[ strValue.Length ];
			for ( int i = 0; i < numSpriteGird.Length; i++ ) {
				// オブジェクト作成
				float offset = -( ( float )i * _width + _offset );
				numSpriteGird[ i ] = Instantiate(
					showSprite,
					transform.position + new Vector3( offset, 0 ),
					Quaternion.identity ) as GameObject;

				// 一番左の数値を取得
				int num = numSpriteGird.Length - i - 1;
				// 表示する数値指定
				numSpriteGird[ i ].GetComponent<SpriteRenderer>( ).sprite = dicSprite[ strValue[ num ] ];

				// 表示する画像のレイヤーを指定
				numSpriteGird[ i ].GetComponent<SpriteRenderer>( ).sortingOrder = _layer;

				// 自身の子階層に移動
				numSpriteGird[ i ].transform.parent = transform;
			}
		}
	}
}
