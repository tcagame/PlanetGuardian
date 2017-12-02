using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class callibration : MonoBehaviour {

	// Use this for initialization
	void Start( ) {
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update( ) {
		if ( SceneManager.GetActiveScene( ).name == "select" ) {
			transform.rotation = Input.gyro.attitude;
		}
	}
}
