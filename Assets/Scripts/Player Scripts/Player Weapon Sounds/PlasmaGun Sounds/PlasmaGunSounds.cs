using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaGunSounds : MonoBehaviour
{
    public AudioClip plasmaGunSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound ()
    {
        audioSource.PlayOneShot(plasmaGunSound);
    }
    
}
