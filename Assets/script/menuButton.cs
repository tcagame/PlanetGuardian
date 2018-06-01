using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour {

	private Button _button;
	private GameObject _window;
	private GameObject _game_menu;
	private GameObject _sound_menu;

	void Awake () {
		_button = GetComponent<Button> ();
		GameObject canvas = GameObject.Find ("Canvas");
		_window = canvas.transform.Find ("window").gameObject;
		_game_menu = canvas.transform.Find ("GameMenu").gameObject;
		_sound_menu = canvas.transform.Find ("SoundMenu").gameObject;
	}
		
	void Start () {
		_button.onClick.AddListener (openMenu);
	}

	void openMenu( ) {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			_window.SetActive (true);
			_game_menu.SetActive (true);
		}
	}

	public void closeMenu( ) {
		Time.timeScale = 1;
		_window.SetActive( false );
		_game_menu.SetActive( false );
		_sound_menu.SetActive( false );
	}

	public void onSoundMenu( ) {
		_game_menu.SetActive (false);
		_sound_menu.SetActive (true);
	}

	public void onGameMenu( ) {
		_game_menu.SetActive( true );
		_sound_menu.SetActive( false );
	}

	public void giveUp( ) {
		Time.timeScale = 1;
		SceneManager.LoadScene("title");
	}
}
