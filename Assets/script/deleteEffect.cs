using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteEffect : MonoBehaviour {

	[SerializeField] private int _draw_num = 1;
	private float _time = 0.0f;
	private GameObject _obj = null;

	// Use this for initialization
	void Start () {
		_time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;
		if ( _obj ) {
			transform.position = _obj.transform.position;
		}

		if (_time > GetComponent< Animator> ().GetCurrentAnimatorStateInfo (0).length * _draw_num) {
			Destroy( gameObject );
		}
	}

	public void setSearchObject( GameObject gameobject ) {
		_obj = gameobject;
	}
}
