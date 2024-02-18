using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource musicPlayer;
    public AudioClip backgroundMusic;

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        PlaySound(backgroundMusic, musicPlayer);
    }

    public static void PlaySound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    void GameOver()
    {
        musicPlayer.Stop();
    }
}
