using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelTank : MonoBehaviour
{
    public bool isEnemy = false;
    public float moveSpeed, checkDistance;
    public GameObject playerTank;
    private Rigidbody myRb;
    private bool doMove;

    private void Awake() {
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isEnemy) {
            transform.LookAt(playerTank.transform);
            doMove = Vector3.Distance(transform.position, playerTank.transform.position) > checkDistance;
            /*
            if (Vector3.Distance(transform.position, playerTank.transform.position) > checkDistance) {
                //It's far, will go to the player
                doMove = true;
            } else {
                doMove = false;
            }                   */
        } else {
            if (Vector3.Distance(transform.position, playerTank.transform.position) < checkDistance) {
               transform.forward = (transform.position - playerTank.transform.position).normalized;
               doMove = true;
            } else {
                doMove = false;
            }
            
        }

        /*if (!isEnemy) {
            transform.Rotate(Vector3.up * 180  * Time.deltaTime);
            transform.Translate(playerTank.transform.position * 5 * Time.deltaTime);
        } */
    }

    private void FixedUpdate() {
        if (doMove) {
        Vector3 desp = transform.forward * moveSpeed * Time.deltaTime;
        myRb.MovePosition(myRb.position + desp);
        }
        
    }
}
