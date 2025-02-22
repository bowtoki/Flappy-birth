using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip hitBird;
    public AudioClip birdFlap;
    public AudioClip birdDie;
    public AudioClip audioPoint;
    public AudioClip swooshing;
    public static AudioManager instance;

    private void Awake()
    {
        instance=this;
    }
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
