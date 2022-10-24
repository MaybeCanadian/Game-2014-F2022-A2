using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicControllerScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip BGStart;
    [SerializeField]
    private AudioClip BGLoop;
    [SerializeField]
    private AudioSource BGSource;

    private void Start()
    {
        BGSource = GetComponent<AudioSource>();
        BGSource.clip = BGStart;
        BGSource.Play();

        StartCoroutine("WaitForLoop");

    }

    private IEnumerator WaitForLoop()
    {
        while(BGSource.isPlaying)
        {
            yield return null;
        }

        BGSource.clip = BGLoop;
        BGSource.loop = true;
        BGSource.Play();
        yield break;
    }

}
