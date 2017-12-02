using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toRanking : MonoBehaviour {
	void OnMouseDown( ) {
		if ( SceneManager.GetActiveScene( ).name == "Ranking" ) {
			SceneManager.LoadScene( "Select" );
		}
		if ( SceneManager.GetActiveScene( ).name == "Select" ) {
			SceneManager.LoadScene( "Ranking" );
		}
	}
}
