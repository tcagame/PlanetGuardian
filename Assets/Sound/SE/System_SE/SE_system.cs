using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SE_system : MonoBehaviour {
    private AudioSource SE_s_lanking;
    private AudioSource SE_s_tap;
    
    // Use this for initialization
    void Start()
    {
        AudioSource[] audioSourses = GetComponents<AudioSource>();
        SE_s_lanking = audioSourses[0];
        SE_s_tap = audioSourses[1];
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown ()
    {
        SE_s_tap.Play();
    }
}
