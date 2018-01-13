using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSelectStage : MonoBehaviour {

	[SerializeField] selectStage.STAGE _stage;

	void OnMouseDown( ) {
		GameObject.Find( "window" ).GetComponent<selectStage>( ).setStage(_stage);
	}
}
