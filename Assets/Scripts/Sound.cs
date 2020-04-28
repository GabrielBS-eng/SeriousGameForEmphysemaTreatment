using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource[] AudioData;
    public AudioSource firstAudioData;
    public AudioSource secondAudioData;

    // Start is called before the first frame update
    void Start()
    {
        AudioData = GetComponents<AudioSource>();
        firstAudioData = AudioData[0];
        secondAudioData = AudioData[1];

        double playTime = AudioSettings.dspTime;
        //firstAudioData.PlayDelayed((float)playTime);
        firstAudioData.Play();
        playTime = (double)firstAudioData.clip.length;
        secondAudioData.PlayDelayed((float)playTime);
    }

    // Update is called once per frame
    void Update()
    {
       // firstAudioData.clip = Resources.Load<AudioClip>(secondAudioData);
       // if(!firstAudioData.isPlaying)
       // {
       //     firstAudioData.clip = secondAudioData;
       //     firstAudioData.Play();
       // }
    }
}
