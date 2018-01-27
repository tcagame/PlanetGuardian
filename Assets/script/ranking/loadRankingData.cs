using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class loadRankingData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadData( int stage_num ) {
		comboData combo = new comboData( );
		string PATH = combo.getPath( stage_num );
		byte [] data = File.ReadAllBytes( PATH );

		for ( int i = 0; i < 5; i++ ) {
			string obj_name = "ranking" + (i + 1);
			transform.FindChild( obj_name ).GetComponent< drawNumSprite > ( ).Value = data [i + 2];
		}
	}
}
