using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_nearEnemy : MonoBehaviour {
    public AudioClip SE_e_nearAttack;
    AudioSource audioSource_1;
    // Use this for initialization
    void Start () {
        audioSource_1 = gameObject.GetComponent<AudioSource>();
        audioSource_1.clip = SE_e_nearAttack;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SE_Enemy_NearAttack()
    {
        audioSource_1.PlayOneShot(SE_e_nearAttack);
    }
}
