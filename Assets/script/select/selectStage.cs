using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectStage : MonoBehaviour {

	public enum STAGE {
		STAGE_TUTORIAL,
		STAGE_1,
		STAGE_2,
		MAX_STAGE,
	};
	STAGE _stage;
	string[ ] STAGE_NAME = {
		"Course",
		"stage1",
		"stage2"
	};

	GameObject a;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void close( ) {
		for ( int i = 0; i < transform.childCount; i++ ) {
			transform.GetChild( i ).gameObject.SetActive( false );
		}
	}

	public void setStage( STAGE stage ) {
		if ( transform.GetChild( 0 ).gameObject.activeSelf == false ) {
			_stage = stage;
			transform.GetChild( 0 ).gameObject.SetActive( true );
			transform.FindChild( STAGE_NAME[ ( int )_stage ] ).gameObject.SetActive( true );
		}
	}

	public void startGame( ) {
		Time.timeScale = 0;
		Destroy( GameObject.Find("BGM_Title(Clone)") );
		if (_stage == STAGE.STAGE_TUTORIAL) {
			SceneManager.LoadScene ("Course");
		} else {
			SceneManager.LoadScene ("character");
			SceneManager.LoadScene (STAGE_NAME [(int)_stage], LoadSceneMode.Additive);
		}
		transform.DetachChildren( );
		DontDestroyOnLoad( this );
		gameObject.name = "stage_info";
	}

	public string playStage( ) {
		return STAGE_NAME[(int)_stage];
	}
}
