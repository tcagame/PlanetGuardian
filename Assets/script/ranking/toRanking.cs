using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toRanking : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown( ) {
		if (SceneManager.GetActiveScene ().name == "ranking") {
			SceneManager.LoadScene ("select");
		}
		if (SceneManager.GetActiveScene ().name == "select") {
			SceneManager.LoadScene ("ranking");
		}
	}
}
