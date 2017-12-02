using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

	[SerializeField] private GameObject _callibration = null;
	[SerializeField] private GameObject _game_menu = null;
	[SerializeField] private GameObject _sound_menu = null;
	[SerializeField] private GameObject _count_down = null;

	private string stage_name;
	private bool load_stage = false;

    private GameObject Title_BGM;
	// Use this for initialization
	void Start () {
		load_stage = false;

        Title_BGM = GameObject.Find("BGM_Title(Clone)");
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch ( SceneManager.GetActiveScene().name ) {
		case "initialize":
			DontDestroyOnLoad (_callibration);
			SceneManager.LoadScene ("title");
			break;
		case "title":
			if (Input.GetMouseButton (0)) {
            	SceneManager.LoadScene ("select");
				tapSE ();
			}
			break;
		case "select":
			if (load_stage) {
				Time.timeScale = 0;
            	Destroy(Title_BGM);
                SceneManager.LoadScene ("character");
				SceneManager.LoadScene (stage_name, LoadSceneMode.Additive);
			}
			break;
		case "character":
			bool game_over = true;
			bool stage_clear = true;
			foreach( GameObject obj in FindObjectsOfType( typeof( GameObject ) ) ) {
				if ( obj.tag == "boss" ) {
					stage_clear = false;
				}
				if ( obj.tag == "Player" ) {
					game_over = false;
				}
			}
			if ( stage_clear ) {
				GameObject.Find( "combo" ).GetComponent< combo >( ).save( );
				SceneManager.LoadScene ("clear");
			}
			if ( game_over ) {
				SceneManager.LoadScene ("gameover");
			}
			break;
		case "clear":
		case "gameover":
			if (Input.GetMouseButton (0)) {
            	SceneManager.LoadScene ("title");
				tapSE ();
			}
			break;
		}
	}

	void tapSE( ) {
		GameObject.Find ("sound").GetComponent<sound> ().playSE ("tap");
	}

	public void setStage1( ) {
		stage_name = "stage1";
		load_stage = true;
	}

	public void setStage2( ) {
		stage_name = "stage2";
		load_stage = true;
	}

	public void onGameMenu( ) {
		if (!_count_down) {
			Time.timeScale = 0;
			_game_menu.SetActive (true);
		}
	}

	public void closeMenu( ) {
		Time.timeScale = 1;
		_game_menu.SetActive( false );
		_sound_menu.SetActive( false );
	}

	public void onSoundMenu( ) {
		if (!_count_down) {
			_game_menu.SetActive (false);
			_sound_menu.SetActive (true);
		}
	}

	public void returnGameMenu( ) {
		_game_menu.SetActive( true );
		_sound_menu.SetActive( false );
	}

	public void giveUp( ) {
		Time.timeScale = 1;
		SceneManager.LoadScene("title");
	}
}
