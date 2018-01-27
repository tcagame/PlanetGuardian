using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting : MonoBehaviour {

	[SerializeField] GameObject _ranking = null;
	[SerializeField] GameObject _window = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown( ) {
		if (!_window.activeSelf) {
			_window.SetActive(true);
			transform.GetComponent< Collider2D >().isTrigger = true;
			_ranking.GetComponent< Collider2D >().isTrigger = true;
		}
	}
}
