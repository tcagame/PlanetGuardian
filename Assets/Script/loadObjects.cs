using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadObjects : MonoBehaviour {

	[SerializeField]
	private string loadName = null;

	// Use this for initialization
	void Start( ) {
		if ( loadName.Length > 0 ) {
			DeserializedLevelsLoader load = new DeserializedLevelsLoader( );
			load.generateItems( loadName );
		}
	}

	// Update is called once per frame
	void Update( ) {

	}
}
