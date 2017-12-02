using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectStage : MonoBehaviour {

	[SerializeField]
	bool stage1 = false;
	[SerializeField]
	bool stage2 = false;

	void Start( ) {

	}

	// Update is called once per frame
	void Update( ) {

	}

	void OnMouseDown( ) {
		//GameObject.Find ("Sound").GetComponent<sound> ().playSE ("tap");
		nextScene next = GameObject.Find( "Master" ).GetComponent<nextScene>( );
		if ( stage1 ) {
			next.setStage1( );
		}

		if ( stage2 ) {
			next.setStage2( );
		}
	}
}
