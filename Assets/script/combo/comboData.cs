using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class comboData : MonoBehaviour {

	const int STAGE_NUM = 2;
	public int MAX_DATA { get{ return 7; } }

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().name == "initialize"){
			initialization();
		}
	}

	void initialization( ) {
		string PATH = Application.persistentDataPath + "/combo/stage";
		for (int i = 0; i < STAGE_NUM; i++){
			string file = PATH + i.ToString();
			if ( File.Exists( file ) ) {
				create( file );
			}
		}
	}
			
	void create( string path ) {
		// new_record_flag this_game rank1 rank2 rank3 rank4 rank5
		byte[] datas = { 0, 0, 0, 0, 0, 0, 0 };
		File.WriteAllBytes(path, datas);
	}

	public string getPath( int stage_num ) {
		if (stage_num >= STAGE_NUM) {
			return "";
		}
		string PATH = Application.persistentDataPath + "/combo/stage" + stage_num.ToString();
		return PATH;
	}
}
