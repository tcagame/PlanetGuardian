using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class drawResult : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		comboData combo = new comboData( );
		selectStage stage = GameObject.Find("stage_info").GetComponent<selectStage>();
		string PATH = combo.getPath( stage.getStageNum( ) );
		byte [ ] datas = File.ReadAllBytes( PATH );
		bool new_record = datas [0] == 1;
		if (new_record) {
			GameObject.Find ("new_record").SetActive (true);
			GameObject.Find ("sound").GetComponent<sound> ().playSE ("new_record");
		}
		transform.FindChild( "this_game_result" ).GetComponent< drawNumSprite > ( ).Value = datas[ 1 ];
		for ( int i = 0; i < 5; i++ ) {
			Transform child = transform.FindChild( "ranking" );
			string obj_name = "ranking" + i;
			child.FindChild( obj_name ).GetComponent< drawNumSprite > ( ).Value = datas[ i + 2 ];
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
