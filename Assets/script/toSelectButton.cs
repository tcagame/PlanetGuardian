using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toSelectButton : MonoBehaviour {
	void OnMouseDown( ) {
		Destroy( GameObject.Find( "stage_info" ) );
		SceneManager.LoadScene ("title");
	}
}
