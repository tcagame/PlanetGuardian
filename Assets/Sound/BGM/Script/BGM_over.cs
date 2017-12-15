using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_over : MonoBehaviour {
    AudioSource audioSource_over;
    private float over_loopTime = 0.0f;      //ループポイント時間
    public float over_endTime = 87.0f;       //BGMの終了時間
    // Use this for initialization
    void Start () {
        audioSource_over = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (audioSource_over.isPlaying)
        {
            if (audioSource_over.time >= over_endTime)
            {
                audioSource_over.time = over_loopTime;
            }
        }
    }
}
