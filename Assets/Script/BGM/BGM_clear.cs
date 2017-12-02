using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_clear : MonoBehaviour {
    AudioSource audioSource_clear;
    public float clear_loopTime = 7.0f;      //ループポイント時間
    public float clear_endTime = 73.0f;       //BGMの終了時間
    // Use this for initialization
    void Start()
    {
        audioSource_clear = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource_clear.isPlaying)
        {
            if (audioSource_clear.time >= clear_endTime)
            {
                audioSource_clear.time = clear_loopTime;
            }
        }
    }
}
