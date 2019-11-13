using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerMouse : MonoBehaviour
{
    public float moveSpeed, rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime);
    }
}
