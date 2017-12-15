using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plyaer : MonoBehaviour {

	private bool _move_key = true;
	[SerializeField] private float MAX_SPEED = 15f;
	[SerializeField] private double MIN_SPEED_RATIO = 0.35;
	[SerializeField] private int MAX_HP = 150;
	[SerializeField] private Slider HpBar = null; //HPGUI Controller
	[SerializeField] private Text _text = null; // debug message text

	[SerializeField] private GameObject _damage = null;
	[SerializeField] private GameObject _hit = null;
	[SerializeField] private GameObject _recovery = null;
	[SerializeField] private GameObject _sound = null;

	private Rigidbody2D _rb;
	private Vector2 _vec;
	private GameObject _offset = null;
	private float _hp;
	private float _time;

    // Use this for initialization
    void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_hp = MAX_HP;
		_time = 0.0f;
		_text.text = "";
		HpBar.maxValue = MAX_HP;
		_offset = GameObject.Find ("callibration");
		if (_offset) {
			_move_key = false;
		}
		Input.gyro.enabled = true;

//        AudioSource[] audioSourses = GetComponents<AudioSource>();
//        SE_PlayerSpin = audioSourses[0];
  //      SE_PlayerDamage = audioSourses[1];
    //    SE_PlayerAttack = audioSourses[2];
      //  SE_PlayerRecovery = audioSourses[3];
        //SE_PlayerGameover = audioSourses[4];

    }

    // Update is called once per frame
    void Update () {
		if (Time.timeScale == 0) {
			//SE_PlayerSpin.Play ();
			_sound.GetComponent<sound> ().playSE ("player_spin");
		}
		updateMove ();
		updateHp ();
	}

	void updateMove( ) {
		_vec = new Vector2 (0, 0);
		if (_move_key) {
			moveKey ();
		} else {
			moveGyro ();
		}
		adjustVec ();
		_rb.velocity = _vec;
	}

	void moveGyro( ) {
		Vector3 offset = _offset.transform.rotation.eulerAngles;
		Vector3 input_rot = Input.gyro.attitude.eulerAngles;

		if (offset.x > 180) {
			offset.x -= 360;
		}
		if (offset.y > 180) {
			offset.y -= 360;
		}
		if (input_rot.x > 180) {
			input_rot.x -= 360;
		}
		if (input_rot.y > 180) {
			input_rot.y -= 360;
		}

		Vector3 diff = input_rot - offset;
		_vec = new Vector2 (diff.y, -diff.x);
	}

	void moveKey( ) {
		// up
		if (Input.GetKey( KeyCode.UpArrow)) {
			_vec = new Vector2 (0.0f, MAX_SPEED) + _vec;
		}
		// down
		if (Input.GetKey (KeyCode.DownArrow)) {
			_vec = new Vector2 (0.0f, -MAX_SPEED) + _vec;
		}
		// left
		if (Input.GetKey (KeyCode.LeftArrow)) {
			_vec = new Vector2 (-MAX_SPEED, 0.0f) + _vec;
		}
		// right
		if (Input.GetKey (KeyCode.RightArrow)) {
			_vec = new Vector2 (MAX_SPEED, 0.0f) + _vec;
		}
	}

	void adjustVec( ) {
		double speed = MAX_SPEED * ( _hp / MAX_HP );
		double MIN_SPEED = ( double )MAX_SPEED * MIN_SPEED_RATIO;
		if (speed < MIN_SPEED) {
			speed = MIN_SPEED;
		}
		if (_vec.magnitude > speed) {
			_vec = _vec.normalized * ( float )speed;
		}
	}

	void updateHp( ) {
		_time += Time.deltaTime;
		if (_time > 1) {
			_hp--;
			_time--;
		}
		HpBar.value = _hp;
		if (_hp <= 0) {
			Destroy( gameObject, 5f );
            //SE_PlayerGameover.Play();
			_sound.GetComponent<sound> ().playSE( "gameover" );
		}
	}
		
	public void damage( int damage ) {
        //SE_PlayerDamage.Play();
		_sound.GetComponent<sound> ().playSE( "player_damage" );

		_hp -= damage;
		GameObject.Find( "combo" ).GetComponent<combo> ().expireCombo();
		setEffect( Instantiate( _damage, transform.position, Quaternion.identity ) );
	}

	public void recovery( int recovery ) {
        //SE_PlayerRecovery.Play();
		_sound.GetComponent<sound> ().playSE( "recovery" );
		_hp += recovery;
        if ( _hp > MAX_HP ) {
            _hp = MAX_HP;
        }
		setEffect( Instantiate( _recovery, transform.position, Quaternion.identity ) );
	}

	public void attack( ) {
        //SE_PlayerAttack.Play();
		_sound.GetComponent<sound> ().playSE( "player_attack" );

		GameObject.Find( "combo" ).GetComponent<combo> ().addCombo();
		setEffect( Instantiate( _hit, transform.position + new Vector3( 0, 3, 0 ), Quaternion.identity ) );
	}

	void setEffect( GameObject obj ) {
		obj.GetComponent< deleteEffect > ().setSearchObject( gameObject );
	}

    public void Spin_Stop()
    {
		_sound.GetComponent<sound> ().stopSE( "player_spin" );
        //SE_PlayerSpin.Stop();
    }

    public void Spin_Play()
    {
       // SE_PlayerSpin.Play();
		_sound.GetComponent<sound> ().playSE( "player_spin" );
    }
}
