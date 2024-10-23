using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;


    public void PlayAudio() 
    {
        _audioSource.Play();
    }

    public void PalyAudioIfNotPlaying() 
    {
        if (!_audioSource.isPlaying) PlayAudio();
    }

    public void StopAudio()
    {
        _audioSource.Stop();   
    }

    public void PlayAudioByNum(int num) 
    {
        if (_audioClips.Count > 0) 
        {
            _audioSource.clip = _audioClips[num];
            PlayAudio();
        }
    }
}
