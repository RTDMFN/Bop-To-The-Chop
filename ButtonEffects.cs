using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class ButtonEffects : MonoBehaviour
{
    public AudioClip enterClip;
    // public AudioClip exitClip;
    public AudioClip clickClip;

    public AudioSource audioSource;

    public void OnButtonEnter(BaseEventData eventData){
        audioSource.clip = enterClip;
        audioSource.Play();
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    public void OnButtonExit(BaseEventData eventData){
        // audioSource.clip = exitClip;
        // audioSource.Play();
        transform.localScale = Vector3.one;
    }

    public void OnButtonClick(BaseEventData eventData){
        audioSource.clip = clickClip;
        audioSource.Play();
    }
}
