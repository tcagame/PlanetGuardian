using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryGameButton : MonoBehaviour {
	void OnMouseDown( ) {
		GameObject select = GameObject.Find( "window" );
		select.GetComponent<selectStage>( ).retry( );
	}
}
