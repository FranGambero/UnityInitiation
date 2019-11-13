using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerKeys : MonoBehaviour
{
    public KeyCode upKey, downKey, rightKey, leftKey;
    public float moveSpeed, rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey)) {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(downKey)) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(rightKey)) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(leftKey)) {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
    }
}
