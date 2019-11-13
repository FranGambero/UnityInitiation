using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletStart;
    public float shootTime;
    private float shootTimer;
    private bool clickPressed;

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if(Input.GetMouseButton(0) && !clickPressed) {
            clickPressed = true;

            if(shootTimer <= 0) {
                Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
                shootTimer = shootTime;
            }
        } 
        else if(!Input.GetMouseButton(0) && clickPressed) {
            clickPressed = false;
        }
    }
}
