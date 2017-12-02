using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOption : MonoBehaviour {

	[SerializeField]
	GameObject _window = null;
	[SerializeField]
	GameObject _game_menu = null;
	[SerializeField]
	GameObject _sound_menu = null;

	public void onGameMenu( ) {
		print( "drawMenu" );
		if ( Time.timeScale == 1 ) {
			Time.timeScale = 0;
			_window.SetActive( true );
			_game_menu.SetActive( true );
		}
	}

	public void closeMenu( ) {
		Time.timeScale = 1;
		_window.SetActive( false );
		_game_menu.SetActive( false );
		_sound_menu.SetActive( false );
	}

	public void onSoundMenu( ) {
		if ( Time.timeScale == 1 ) {
			_game_menu.SetActive( false );
			_sound_menu.SetActive( true );
		}
	}

	public void returnGameMenu( ) {
		_game_menu.SetActive( true );
		_sound_menu.SetActive( false );
	}

	public void giveUp( ) {
		closeMenu( );
		SceneManager.LoadScene( "title" );
	}
}
