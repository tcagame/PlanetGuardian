using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeWindow : MonoBehaviour {
	void OnMouseDown( ) {
		GameObject.Find( "window" ).GetComponent<selectStage>().close( );
	}
}
