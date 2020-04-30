using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundBird : MonoBehaviour
{
    public AudioSource randomSound;

    public AudioClip[] audioSources;

    void Update()
    {
        if (PressController.state == PressController.gameState.duringCicle)
        {
            StartCoroutine(RandomSoundness());
        }
    }

    public IEnumerator RandomSoundness()
    {
        if(Input.GetButton("Jump"))
        {
            if(!randomSound.isPlaying)
            {
                randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
                randomSound.Play();
            }
        }
        if(Input.GetButtonUp("Jump"))
        {
            randomSound.Stop();
        }
        yield return new WaitForSeconds(0.25f);
    }
}
