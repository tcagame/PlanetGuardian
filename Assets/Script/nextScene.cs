using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

	private GameObject _callibration = null;

	private string stage_name;
	private bool load_stage = false;

	private GameObject Title_BGM;
	// Use this for initialization
	void Start( ) {
		load_stage = false;
		if ( SceneManager.GetActiveScene( ).name == "Initialize" ) {
			_callibration = GameObject.Find( "callibration" );
		}
		Title_BGM = GameObject.Find( "BGM_Title(Clone)" );
	}

	// Update is called once per frame
	void Update( ) {
		switch ( SceneManager.GetActiveScene( ).name ) {
		case "Initialize":
			if ( _callibration )
				DontDestroyOnLoad( _callibration );
			SceneManager.LoadScene( "Title" );
			break;
		case "Title":
			if ( Input.GetMouseButton( 0 ) ) {
				SceneManager.LoadScene( "Select" );
				tapSE( );
			}
			break;
		case "Select":
			if ( load_stage ) {
				Time.timeScale = 0;
				Destroy( Title_BGM );
				SceneManager.LoadScene( "Character" );
				SceneManager.LoadScene( stage_name, LoadSceneMode.Additive );
			}
			break;
		case "Character":
			bool game_over = true;
			bool stage_clear = true;
			foreach ( GameObject obj in FindObjectsOfType( typeof( GameObject ) ) ) {
				if ( obj.tag == "boss" ) {
					stage_clear = false;
				}
				if ( obj.tag == "Player" ) {
					game_over = false;
				}
			}
			if ( stage_clear ) {
				GameObject.Find( "Combo" ).GetComponent<combo>( ).save( );
				SceneManager.LoadScene( "Clear" );
			}
			if ( game_over ) {
				SceneManager.LoadScene( "Gameover" );
			}
			break;
		case "Clear":
		case "Gameover":
			if ( Input.GetMouseButton( 0 ) ) {
				SceneManager.LoadScene( "Title" );
				tapSE( );
			}
			break;
		}
	}

	void OnMouseDown( ) {
		tapSE( );
	}

	void tapSE( ) {
		GameObject.Find( "sound" ).GetComponent<sound>( ).playSE( "tap" );
	}

	public void setStage1( ) {
		stage_name = "stage1";
		load_stage = true;
	}

	public void setStage2( ) {
		stage_name = "stage2";
		load_stage = true;
	}
}
