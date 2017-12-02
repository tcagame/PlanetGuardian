using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class drawResult : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		string PATH = Application.persistentDataPath + "/combo";
		byte [ ] data = File.ReadAllBytes( PATH );
		bool new_record = data [0] == 1;
		if (new_record) {
			GameObject.Find ("new_record").SetActive (true);
			GameObject.Find ("sound").GetComponent<sound> ().playSE ("new_record");
		}
		transform.FindChild( "this_game_result" ).GetComponent< drawNumSprite > ( ).Value = data[ 1 ];
		for ( int i = 0; i < 5; i++ ) {
			Transform child = transform.FindChild( "ranking" );
			string obj_name = "ranking" + i;
			child.FindChild( obj_name ).GetComponent< drawNumSprite > ( ).Value = data[ i + 2 ];
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
