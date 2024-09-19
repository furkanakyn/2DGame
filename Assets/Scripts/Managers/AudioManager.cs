using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource shotAS;
    public AudioSource damageAS;
    public AudioSource bGAS;
    private void PlayShotbGAS()
    {
        bGAS.Play();
    }
 
    public void PlayShotAS()
    {
        shotAS.Play();
    }
    public void PlayDamageAS()
    {
        damageAS.Play();
    }
}
