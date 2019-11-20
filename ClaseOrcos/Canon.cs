using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public KeyCode rightKey, leftKey;
    public float rotateSpeed, shootSpeed;
    public GameObject bullet;
    public Transform bulletStart;
    public float shootTime = 0.5f;
    private float shootTimer;

    // Update is called once per frame
    void Update() {

        shootTimer -= Time.deltaTime;

        if (Input.GetKey(rightKey)) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(leftKey)) {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0)) {
            this.shootFire();
        }
    }

    private void shootFire() {
        if (shootTimer <= 0) {
            Destroy(Instantiate(bullet, bulletStart.position, bulletStart.rotation), 3f);
            shootTimer = shootTime;
        }
        
    }
}