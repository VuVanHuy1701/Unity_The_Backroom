using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController raycastedObj;


    [SerializeField] private Image crosshair = null;

    private bool isCrosshairActive;
    private bool doOnce;

    Ray ray;
    RaycastHit hit;
    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        OpenDoor();
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }

        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
    public void OpenDoor()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    raycastedObj.PlayAnimation();
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }
}
