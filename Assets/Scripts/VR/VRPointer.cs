using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPointer : MonoBehaviour
{
    [SerializeField]
    private float pointerDistance = 5;
    private VRObject gazedObject = null;

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pointerDistance)) {
            if (gazedObject?.gameObject != hit.transform.gameObject) {
                gazedObject?.OnPointerExit();
                gazedObject = hit.transform.gameObject.GetComponent<VRObject>();
                gazedObject?.OnPointerEnter();
            }
        } else {
            gazedObject?.OnPointerExit();
            gazedObject = null;
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetButtonDown("Submit")) {
            gazedObject?.OnPointerClick();
        }
        
    }
}
