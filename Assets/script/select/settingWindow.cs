using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingWindow : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void close( ) {
		gameObject.SetActive(false);
	}

	public void openSoundMenu( ) {
		transform.GetChild(1).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(true);
	}

	public void closeSoundMenu( ) {
		transform.GetChild(1).gameObject.SetActive(true);
		transform.GetChild(2).gameObject.SetActive(false);
	}
}
