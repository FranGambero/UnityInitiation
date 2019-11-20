using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public KeyCode upKey, downKey, rightKey, leftKey;
    public float moveSpeed, rotateSpeed;
    private bool onArea = false;
    public GameObject orc;

    // Update is called once per frame
    void Update() {
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

        if (onArea && Input.GetKeyDown(KeyCode.Space)) {
            castOrk();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Summon Area") {
            onArea = true;
            // Can cast orcos
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Summon Area") {
            onArea = false;
        }
    }

    private void castOrk() {
        Vector3 nextPosCast = transform.forward * Random.Range(5,9);
        Instantiate(orc, nextPosCast, Quaternion.identity).transform.LookAt(transform);
    }
}
