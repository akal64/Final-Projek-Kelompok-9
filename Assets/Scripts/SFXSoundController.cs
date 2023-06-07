using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SFXSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSource;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip backSound;

    public void ClickSound() {
        buttonSource.PlayOneShot(clickSound);
    }

    public void BackSound() {
        buttonSource.PlayOneShot(backSound);
    }
}
