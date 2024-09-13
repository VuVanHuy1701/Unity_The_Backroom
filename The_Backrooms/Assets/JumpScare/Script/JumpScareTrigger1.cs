using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger1 : MonoBehaviour
{
    public GameObject AnimateObject;
    public GameObject thisTrigger;
    public AudioSource JumpAudio;

    public GameObject AnimateObjectOff;

    void Start()
    {
        AnimateObject.gameObject.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            AnimateObject.gameObject.SetActive(true);
            AnimateObject.GetComponent<Animator>().Play("Jump_1_Smiler");
            thisTrigger.SetActive(false);
            JumpAudio.Play();
            tunoff();
        }
  
    }
    void tunoff()
    {
        AnimateObjectOff.gameObject.SetActive(false);
    }
}
