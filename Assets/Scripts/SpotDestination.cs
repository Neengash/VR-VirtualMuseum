using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotDestination : MonoBehaviour
{
    public void startCameraMovement() {
        CameraMovement.instance.MoveToPoint(transform.position);
    }
}
