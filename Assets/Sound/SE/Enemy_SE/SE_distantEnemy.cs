using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_distantEnemy : MonoBehaviour {
    public AudioClip SE_e_distantAttack;
    AudioSource audioSource_1;

    // Use this for initialization
    void Start () {
        audioSource_1 = gameObject.GetComponent<AudioSource>();
        audioSource_1.clip = SE_e_distantAttack;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SE_Enemy_DistantAttack()
    {
        audioSource_1.PlayOneShot(SE_e_distantAttack);
    }
}
