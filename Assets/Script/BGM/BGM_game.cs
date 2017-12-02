using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_game : MonoBehaviour {
    AudioSource audioSource_game;
    AudioSource audioSource_boss;
    
    private float BGM_loopTime = 0.0f;      //ループポイント時間
    public float game_endTime = 91.0f;       //BGMの終了時間
    public float boss_endTime = 79.0f;       //BGMの終了時間

    // Use this for initialization
    void Start () {
        AudioSource[] audioSourses = GetComponents<AudioSource>();
        audioSource_game = audioSourses[0];
        audioSource_boss = audioSourses[1];
    }

    // Update is called once per frame
    void Update () {
        if (audioSource_game.isPlaying)
        {
            if (audioSource_game.time >= game_endTime)
            {
                audioSource_game.time = BGM_loopTime;
            }
        }

        if (audioSource_boss.isPlaying)
        {
            if (audioSource_boss.time >= boss_endTime)
            {
                audioSource_boss.time = BGM_loopTime;
            }
        }

        if ( Input.GetKeyDown(KeyCode.B) )
        {
            GameBGM_Change();
        }
    }

    public void GameBGM_Change()
    {
        audioSource_game.Stop();
        audioSource_boss.Play();
    }
}
