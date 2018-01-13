using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toSelectButton : MonoBehaviour {
	void OnMouseDown( ) {
		Destroy( GameObject.Find( "window" ) );
		SceneManager.LoadScene ("select");
		GameObject.Find ("sound").GetComponent<sound> ().playSE ("tap");
	}
}
