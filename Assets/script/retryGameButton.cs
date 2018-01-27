using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryGameButton : MonoBehaviour {
	void OnMouseDown( ) {
		selectStage stage = GameObject.Find( "stage_info" ).GetComponent<selectStage>( );
		Time.timeScale = 0;
		SceneManager.LoadScene( "character" );
		SceneManager.LoadScene( stage.playStage(), LoadSceneMode.Additive );
	}
}
