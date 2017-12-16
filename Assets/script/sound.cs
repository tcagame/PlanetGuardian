using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

	Dictionary<string, int> _BGM_list = null;
	Dictionary<string, int> _se_list = null;
	AudioSource[] audio;

	// Use this for initialization
	void Start () {
		audio = GetComponents<AudioSource>();
		_BGM_list = new Dictionary<string, int> ();

		_se_list = new Dictionary<string, int> ();
		_se_list.Add ("sword_attack", 0);
		_se_list.Add ("shoter_attack", 1);
		_se_list.Add ("gameover", 2);
		_se_list.Add ("player_attack", 3);
		_se_list.Add ("player_damage", 4);
		_se_list.Add ("player_spin", 5);
		_se_list.Add ("recovery", 6);
		_se_list.Add ("beep", 7);
		_se_list.Add ("new_record", 8);
		_se_list.Add ("tap", 9);
	}

	public void playBGM( string str ) {
		var sound = audio [_BGM_list [str]];
		if (sound.isPlaying) {
			sound.Stop ();
		}
		sound.Play ();
	}

	public void playSE( string str ) {
		var sound = audio [_se_list [str]];
		if (!sound.isPlaying) {
			sound.Play ();
		}
	}

	public void stopSE( string str ) {
		audio [_se_list [str]].Stop();
	}
}
