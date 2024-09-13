using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public GameObject AnimateObject;
    public GameObject thisTrigger;
    public AudioSource JumpAudio;


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
        }

    }

    void Update()
    {
       
        AnimateObject.gameObject.SetActive(false);
    }

}
