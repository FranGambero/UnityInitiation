using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamTank : MonoBehaviour
{
    public enum TankTeam {
        Green, Blue
    }

    public TankTeam team;
    public float moveSpeed;
    private Rigidbody myRb;
    private bool canMove;

    private void Awake() {
        myRb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (team == TankTeam.Green) {
            canMove = Input.GetMouseButton(0);
        } else {
            canMove = Input.GetMouseButton(1);
        }
    }

    private void FixedUpdate() {
        if (canMove) {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 desp = (new Vector3(h, 0, v)).normalized * moveSpeed * Time.deltaTime;
            myRb.MovePosition(myRb.position + desp);
        }
        
    }
}
