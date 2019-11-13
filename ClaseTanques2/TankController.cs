using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public string moveAxis, rotateAxis;
    public float moveSpeed, rotateSpeed;
    Rigidbody myRb;

    private void Awake() {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //To rotate the player, the keys are specified for each controller in the unity project settings
        float h = Input.GetAxisRaw(rotateAxis);
        transform.Rotate(Vector3.up * rotateSpeed * h * Time.deltaTime);

    }

    private void FixedUpdate() {
        //To move the tank to the front or to the back, getting the axis from project settings
        float v = Input.GetAxis(moveAxis);
        Vector3 desp = transform.forward * moveSpeed * v * Time.deltaTime;
        myRb.MovePosition(myRb.position + desp);
    }
}
