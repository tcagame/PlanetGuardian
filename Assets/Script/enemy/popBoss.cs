using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class popBoss : MonoBehaviour {

	[SerializeField]
	GameObject _boss = null;
	[SerializeField]
	GameObject _boss_mob_sword_pop = null;
	[SerializeField]
	GameObject _boss_mob_shooter_pop = null;
	[SerializeField]
	int POP_DOWN_ENEMY_NUM = 50;
	int _down_enemy_num = 0;

	private AudioSource se_beep;
	private AudioSource BGM_game;
	private AudioSource BGM_boss;
	private player player_sc;
	private int bossPop = 0;

	private float BGM_startTime = 0.0f;      //再生位置
	public float game_loopTime = 91.0f;       //BGMのループポイント
	public float boss_loopTime = 79.0f;       //BGMのループポイント

	// Use this for initialization
	void Start( ) {
		AudioSource[ ] audioSourses = GetComponents<AudioSource>( );
		se_beep = audioSourses[ 0 ];
		BGM_game = audioSourses[ 1 ];
		BGM_boss = audioSourses[ 2 ];

		player_sc = GameObject.Find( "player" ).GetComponent<player>( );
	}

	// Update is called once per frame
	void Update( ) {
		//ゲームBGMループ設定
		if ( BGM_game.isPlaying ) {
			if ( BGM_game.time >= game_loopTime ) {
				BGM_game.time = BGM_startTime;
			}
		}

		//BossBGMループ設定
		if ( BGM_boss.isPlaying ) {
			if ( BGM_boss.time >= boss_loopTime ) {
				BGM_boss.time = BGM_startTime;
			}
		}

		bool pop = true;
		if ( _down_enemy_num < POP_DOWN_ENEMY_NUM ) {
			pop = false;
		}
		if ( !pop ) {
			foreach ( GameObject obj in FindObjectsOfType( typeof( GameObject ) ) ) {
				if ( obj.tag == "enemy" ) {
					pop = false;
					break;
				}
			}
		}
		if ( pop ) {
			BGM_game.Stop( );
			player_sc.Spin_Stop( );
			//Time.timeScale = 0;
			se_beep.Play( );
			if ( se_beep.isPlaying ) {
				bossPop = 1;
			}

			if ( bossPop == 1 ) {
				BGM_boss.Play( );
				Instantiate( _boss, transform.position, Quaternion.identity );
				Instantiate( _boss_mob_sword_pop, transform.position + new Vector3( 5, 2, 0 ), Quaternion.identity );
				Instantiate( _boss_mob_shooter_pop, transform.position + new Vector3( -5, 1, 0 ), Quaternion.identity );
				bossPop = 2;
				Destroy( gameObject );
			}
		}

		if ( bossPop == 1 ) {
			BGM_boss.Play( );
		}
	}

	public void hate( ) {
		_down_enemy_num++;
	}
}
