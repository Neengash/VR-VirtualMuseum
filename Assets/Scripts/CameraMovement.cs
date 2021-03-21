using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    [SerializeField] Vector3 startingPosition;
    [SerializeField, Range(1f, 10f)] float speed = 1f;
    private Vector3 destination;
    private bool move;

    void Start() {
        instance = this;
        transform.position = startingPosition; 
        move = false;
    }

    void Update() {
        if (move) {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, destination) < 0.001f) {
            move = false;
            transform.position = destination;
        }
    }

    public void MoveToPoint(Vector3 newDestination) {
        destination = new Vector3(
            newDestination.x,
            0,
            newDestination.z
        );
        move = true;
    }

}
