using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {
	void OnMouseDown( ) {
		GameObject.Find( "window" ).GetComponent<selectStage>( ).startGame( );
	}
}
