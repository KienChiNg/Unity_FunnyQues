using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float soundVolume;
    public AudioSource musicSound;
    public AudioSource soundSound;
    public AudioClip[] backgroundMusic;
    public AudioClip correctSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
