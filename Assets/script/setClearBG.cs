using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setClearBG : MonoBehaviour {

	[SerializeField] GameObject[] _back;

	// Use this for initialization
	void Start () {
		selectStage stage = GameObject.Find("stage_info").GetComponent<selectStage>();
		_back[stage.getStageNum()].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
