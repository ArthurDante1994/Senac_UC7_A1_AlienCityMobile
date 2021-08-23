using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontrolle : MonoBehaviour
{
    public AudioSource audioSourcedefundo;
    public AudioSource audioSourceSFX;
    public AudioClip audioClipdefundo;
    public bool LookControlle;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcedefundo.clip = audioClipdefundo;
        audioSourcedefundo.loop = LookControlle;
        audioSourcedefundo.Play();
    }
    public void ToqueSFX(AudioClip clips)
    {
        audioSourceSFX.PlayOneShot(clips);
    }
}
