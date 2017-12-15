using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_select : MonoBehaviour {

	[SerializeField] private GameObject window;
	[SerializeField] private GameObject stages;

	[SerializeField] private int stage_num = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown( ) {
		if (stage_num > 0) {
			stages.SetActive (false);
			window.SetActive (true);
			window.GetComponent< loadRankingData >().loadData (stage_num);
		}
	}
}
