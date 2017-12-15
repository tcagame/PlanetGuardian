using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class combo : MonoBehaviour {
	// コンボ切れの時間
	[SerializeField] private int COMBO_TIMEOVER = 15;
 
	private int _combo;
	private int _max_combo;
	private float _time;

	// Use this for initialization
	void Start () {
		_combo = 0;
		_max_combo = 0;
		GetComponent< drawNumSprite >( ).Value = _combo;
		_time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;
		if ( _time > COMBO_TIMEOVER ) {
			updateMaxCombo( );
			_combo = 0;
			_time = 0.0f;
		}
		if ( GetComponent< drawNumSprite >( ).Value != _combo ) {
			GetComponent< drawNumSprite >( ).Value = _combo;
		}
	}

	void updateMaxCombo( ) {
		if ( _combo > _max_combo ) {
			_max_combo = _combo;
		}
	}

	public void addCombo( ) { // エネミーのスクリプトから呼ばれる
		_combo++;
		_time = 0.0f;
	}

	public void expireCombo( ) { // プレイヤーのスクリプトから呼ばれる
		updateMaxCombo( );
		_combo = 0;
		_time = 0.0f;
	}

	public void save( ) {
		updateMaxCombo( );
		string PATH = Application.persistentDataPath + "/combo";
		if ( !File.Exists( PATH ) ) {
			resetBinary( PATH );
		}
		const int MAX_DATA = 7;
		byte [] data = File.ReadAllBytes( PATH );
		if (data.Length != MAX_DATA) {
			resetBinary (PATH);
		}
		data [0] = 0;
		data[ 1 ] = (byte)_max_combo;
		if ( data[ MAX_DATA - 1 ] < data[ 1 ] ) {
			data [0] = 1;
			data[ MAX_DATA - 1 ] = data[ 1 ];
			const int END = 6;
			for ( int i = 0; i < MAX_DATA - 2; i++ ) {
				if ( data[ END - i ] < data[ END - ( i + 1 ) ] ) {
					break;
				}
				byte tmp = data[ END - ( i + 1 ) ];
				data[ END - ( i + 1 ) ] = data[ END - i ];
				data[ END - i ] = tmp;
			}
		}
		File.WriteAllBytes( PATH, data );
	}

	void resetBinary( string path ) {
		byte combo = 0;
		byte new_record = 0;
		byte [] data = { new_record, combo, combo, combo, combo, combo, combo };
		File.WriteAllBytes( path, data );
	}
}
