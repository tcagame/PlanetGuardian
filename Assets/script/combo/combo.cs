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
		plyaer player = GameObject.Find( "player" ).GetComponent<plyaer>();
		if ( !player.isDead( ) ) {
			_combo++;
			_time = 0.0f;
		}
	}

	public void expireCombo( ) { // プレイヤーのスクリプトから呼ばれる
		updateMaxCombo( );
		_combo = 0;
		_time = 0.0f;
	}

	public void save( int stage_num ) {
		updateMaxCombo( );
		comboData mgr = new comboData( );
		string PATH = mgr.getPath( stage_num );
		if ( !File.Exists( PATH ) ) {
			Debug.Log("not found combo data file\nPATH:" + PATH);
			return;
		}
		byte [] data = File.ReadAllBytes( PATH );
		if (data.Length != mgr.MAX_DATA) {
			Debug.Log("not found combo data file");
			return;
		}
		data [0] = 0;
		data[ 1 ] = (byte)_max_combo;
		if ( data[ mgr.MAX_DATA - 1 ] < data[ 1 ] ) {
			data [0] = 1;
			data[ mgr.MAX_DATA - 1 ] = data[ 1 ];
			for ( int i = 0; i < mgr.MAX_DATA - 2; i++ ) {
				int back_idx = mgr.MAX_DATA - i - 1;
				int front_idx = mgr.MAX_DATA - (i + 1) - 1;
				if ( data[ back_idx ] < data[ front_idx ] ) {
					break;
				}
				byte tmp = data[ front_idx ];
				data[ front_idx ] = data[ back_idx ];
				data[ back_idx ] = tmp;
			}
		}
		File.WriteAllBytes( PATH, data );
	}
}
