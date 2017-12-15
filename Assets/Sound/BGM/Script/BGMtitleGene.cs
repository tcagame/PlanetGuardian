using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMtitleGene : MonoBehaviour {
    public GameObject BGM_title;

    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;
    // Use this for initialization
    void Start () {
        Instantiate(BGM_title);
        mixer.SetFloat("BGM_Volume", 0);
        mixer.SetFloat("SE_Volume", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public float BGMVolum
    {
        set { mixer.SetFloat("BGM_Volume", 0); }
    }

    public float SEVolum
    {
        set { mixer.SetFloat("SE_Volume", 0); }
    }*/
}
