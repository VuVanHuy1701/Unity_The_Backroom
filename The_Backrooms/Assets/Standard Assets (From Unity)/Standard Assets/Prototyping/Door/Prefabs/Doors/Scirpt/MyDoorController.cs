using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    public GameObject doorAnim;

    private bool doorOpen = false;

    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0;

    private Animator door;
    private void Awake()
    {
         door = doorAnim.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            door.Play("OpenDoor", 0, 0.0f);
            doorOpen = true;

            doorOpenAudioSource.PlayDelayed(openDelay);
        }
        else
        {
            door.Play("CloseDoor", 0, 0.0f);
            doorOpen = false;

            doorCloseAudioSource.PlayDelayed(closeDelay);
        }
    }
    
}
