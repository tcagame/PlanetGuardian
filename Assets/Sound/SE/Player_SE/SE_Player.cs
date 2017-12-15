using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Player : MonoBehaviour {
    public AudioClip SE_p_recovery;
    public AudioClip SE_p_attack;
    public AudioClip SE_p_damage;
    public AudioClip SE_p_spin;
    AudioSource audioSource_1;
    AudioSource audioSource_2;
    AudioSource audioSource_3;
    AudioSource audioSource_4;

    void Start()
    {
        audioSource_1 = gameObject.GetComponent<AudioSource>();
        audioSource_1.clip = SE_p_recovery;

        audioSource_2 = gameObject.GetComponent<AudioSource>();
        audioSource_2.clip = SE_p_attack;

        audioSource_3 = gameObject.GetComponent<AudioSource>();
        audioSource_3.clip = SE_p_damage;

        audioSource_4 = gameObject.GetComponent<AudioSource>();
        audioSource_4.clip = SE_p_spin;
    }

    void Update()
    {
    }

    public void SE_Player_Recovery( )
    {
        audioSource_1.PlayOneShot(SE_p_recovery);
    }

    public void SE_Player_Attack()
    {
        audioSource_2.PlayOneShot(SE_p_attack);
    }

    public void SE_Player_Damage()
    {
        audioSource_3.PlayOneShot(SE_p_damage);
    }

    public void SE_Player_Spin()
    {
        audioSource_4.PlayOneShot(SE_p_spin);
    }
}
