using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSelectStage : MonoBehaviour {

	[SerializeField] selectStage.STAGE _stage = selectStage.STAGE.STAGE_TUTORIAL;
	[SerializeField] GameObject _setting_window = null;

	void OnMouseDown( ) {
		if (!_setting_window.activeSelf){
			GameObject.Find("window").GetComponent<selectStage>().setStage(_stage);
		}
	}
}
