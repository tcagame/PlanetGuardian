using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_title : MonoBehaviour {
    public bool DontDestroyEnabled;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        DontDestroyEnabled = true;

        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
