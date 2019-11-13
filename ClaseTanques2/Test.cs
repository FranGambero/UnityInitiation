using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool usePhysics;
    public float speed;
    Rigidbody myRb;

    private void Awake() {
        myRb = GetComponent<Rigidbody>();
    }
    /*void Update() {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.forward * v * speed* Time.deltaTime);
    } */

    private void Update() {
        if(!usePhysics)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        if (usePhysics) {
        Vector3 desp = transform.forward * speed * Time.deltaTime;
        myRb.MovePosition(myRb.position + desp);
        }
        
    }
}
