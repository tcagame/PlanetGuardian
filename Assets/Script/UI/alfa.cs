using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alfa : MonoBehaviour {

	[SerializeField]
	float SPEED = 0.02f;
	SpriteRenderer _sprite = null;
	float _alfa;
	float _add;

	// Use this for initialization
	void Start( ) {
		_sprite = gameObject.GetComponent<SpriteRenderer>( );
		_alfa = 0.8f;
		_add = -SPEED;
	}

	// Update is called once per frame
	void Update( ) {
		_alfa += _add;
		if ( _alfa > 0.9 || _alfa < 0.1 ) {
			_add *= -1;
		}
		_sprite.color = new Color( 1, 1, 1, _alfa );
	}
}
