using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);

    }
    public void Click()
    {
        myFx.PlayOneShot(clickFx);
    }
}

