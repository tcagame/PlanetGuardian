using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {
	
	enum ACTION {
		WAIT,
		ATTACK,
		DEAD,
		MAX_ACTION
	};

	[SerializeField] private int MAX_HP = 10;
	[SerializeField] private int WAIT_TIME = 3;
	[SerializeField] private int MAX_ATTACK = 3;
	[SerializeField] private int POWER = 3;

	[SerializeField] private GameObject _attack_effect = null;
	[SerializeField] private GameObject _you_win = null;
    [SerializeField] private Slider _hp_bar = null;
    private GameObject _player = null;

	private int ATTACK_RANGE = 7;
	private int _hp;
	private int _attack_count;
	private float _attack_time;
	private float _wait_time;
	private ACTION _action;
    // Use this for initialization
    void Start () {
        _player = GameObject.Find( "player" );
		Instantiate( _hp_bar );
		_hp = MAX_HP;
		_attack_count = 0;
		_attack_time = 0;
		_wait_time = 0;
		_action = ACTION.WAIT;
	}
	
	// Update is called once per frame
	void Update () {
		_hp_bar.value = _hp;
		switch ( _action ) {
		case ACTION.WAIT:
			actionWait( );
			break;
		case ACTION.ATTACK:
			actionAttack( );
			break;
		case ACTION.DEAD:
			break;
		}
	}

	void actionWait( ) {
		_wait_time += Time.deltaTime;
		if ( _wait_time > WAIT_TIME ) {
			_wait_time = 0;
			_action = ACTION.ATTACK;
			GetComponent< Animator > ().SetBool( "attack", true );
			Instantiate( _attack_effect, transform.position, Quaternion.identity );
		}
	}

	void actionAttack( ) {
		_attack_time += Time.deltaTime;
		if ( _attack_time > GetComponent< Animator > ().GetCurrentAnimatorStateInfo(0).length * ( _attack_count + 1 ) ) {
			Vector2 diff = _player.transform.position - transform.position;
			if ( diff.magnitude < ATTACK_RANGE ) {
				_player.GetComponent< player > ().damage( POWER );
			}
			_attack_count++;
		}
		if ( !( _attack_count < MAX_ATTACK ) ) {
			_attack_count = 0;
			_attack_time = 0;
			_action = ACTION.WAIT;
			GetComponent< Animator > ().SetBool( "attack", false );
		}
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.collider.tag == "Player") {
			_hp--;
			col.collider.GetComponent< player > ().attack ();
			if ( _hp <= 0 ) {
				cleanEnemy ();
				_action = ACTION.DEAD;
				GetComponent<Collider2D> ( ).isTrigger = true;
				Instantiate( _you_win );
				Destroy( gameObject, 3.0f );
			}
        }
    }

	void cleanEnemy( ) {
		GameObject[] en_mys = GameObject.FindGameObjectsWithTag("enemy");
		foreach ( GameObject en_my in en_mys ) {
			//if ( obj.tag == "Enemy" ) {
				Destroy (en_my);
			//}
		}
	}
}
