using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHighScore : MonoBehaviour {
	[SerializeField]
	private GameObject window;
	[SerializeField]
	private GameObject stages;
	// Use this for initialization
	void Start( ) {

	}

	// Update is called once per frame
	void Update( ) {

	}

	private void OnMouseDown( ) {
		stages.SetActive( true );
		window.SetActive( false );
	}
}
