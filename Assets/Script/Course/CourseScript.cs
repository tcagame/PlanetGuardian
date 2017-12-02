using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseScript : MonoBehaviour {

	//最大移動時間
	[SerializeField]
	float MovingTime = 2.0f;

	float HealHp = 70.0f;

	public Dialogue dialogue;

	GameObject Player;

	private DialogueScript dialpgue_s;
	float WaitTime = 0;

	bool Moveing = true;
	public bool MoveFlag { get{ return Moveing; } }
	public bool MoveingTime = false;
	public bool HealFlag = false;
	public bool HealTime = false;
	public bool AttackFlag = false;
	public bool AttackTime = false;
	public bool EndFlag = false;

	void Start () {
		this.Player = GameObject.FindWithTag( "Player" );
		Player.GetComponent<PlayerController>().CourseFlag = true;
		dialpgue_s = FindObjectOfType<DialogueScript>();
		dialpgue_s.StartDialogue (dialogue);
	}

	void Update ( ) {

		if ( MoveingTime == true ) {
			MoveTimeUP( );
		}

		if( HealTime == true ) {
			HealHpTimeUP();
		}

		if ( AttackTime == true ) {
			EnemyTimeUP();
		}

	}

	//MOVEチュートリアル
	void MoveCourse( ) {    
		HealFlag = true;
		Moveing = false;
		dialpgue_s.StartDialogue(dialogue);
		return;
	}

	void MoveTimeUP( ) {

		WaitTime += Time.deltaTime;

		if( WaitTime >= MovingTime ) {
			MoveCourse();
			WaitTime = 0;
			MoveingTime = false;
			Player.transform.position = new Vector2 ( 0, -3.0f );
			Player.GetComponent<PlayerController>( ).Speed = new Vector2( 0f, 0f );
		}

	}

	//HPチュートリアル
	void HpCourse( ) {
		HealFlag = false;
		AttackFlag = true;
		HealTime = false;
		dialpgue_s.StartDialogue (dialogue);
		Player.transform.position = new Vector2 ( 0, -3.0f );
		return;
	}

	void HealHpTimeUP( ) {
		if ( Player.GetComponent<PlayerController>().Hp >= HealHp ) {
			HpCourse();
		}
	}
	//敵チュートリアル
	void EnemyCourse( ) {
		EndFlag = true;
		AttackFlag = false;
		AttackTime = false;
		dialpgue_s.StartDialogue(dialogue);
		Player.transform.position = new Vector2 ( 0, -3.0f );
		return;
	}

	void EnemyTimeUP() {
		if (Player.GetComponent<PlayerController>().CourseFlag == false) {
			EnemyCourse();
		}
	}
}