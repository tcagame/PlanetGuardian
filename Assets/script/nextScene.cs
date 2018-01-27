using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

	[SerializeField] private GameObject _callibration = null;

	float _time;

	// Use this for initialization
	void Start () {
		_time = 0.0f;
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
				if (_time < 2.0f){
					_time += Time.deltaTime;
					return;
				}
			if (Input.GetMouseButton (0)) {
            	SceneManager.LoadScene ("select");
				tapSE ();
			}
			break;
		case "select":
			//script "selectStage"で行う
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
					//debug
				GameObject.Find( "combo" ).GetComponent< combo >( ).save( 1 );
				SceneManager.LoadScene ("clear");
			}
			if ( game_over ) {
				SceneManager.LoadScene ("gameover");
			}
			break;
		case "clear":
		case "gameover":
			if (Input.GetMouseButton (0)) {
            //	SceneManager.LoadScene ("title");
				tapSE ();
			}
			break;
		}
	}

	void tapSE( ) {
		GameObject.Find ("sound").GetComponent<sound> ().playSE ("tap");
	}
}
