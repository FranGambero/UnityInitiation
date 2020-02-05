using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour {
    public enum State {
        Patrol, Alert, Chasing
    }

    public State state;

    [Header("States")]
    public Patrol patrol;
    public Alert alert;
    public Chase chase;

    [Header("Senses")]
    public float hearingDistance;
    public float viewDistance;
    public float angleView;
    public float heightView;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;

    [Header("Time")]
    public float alertTime;
    private float alertTimer;
    public float chaseTime;
    private float chaseTimer;

    [Header("Light")]
    public Light stateLight;
    public List<Color> colorStateList;

    public Collider[] collidersDetected;
    private Transform playerDetected;

    private void Start() {
        setState(State.Patrol);
        patrol.startState();
    }

    private void Update() {
        this.checkState();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, hearingDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 dir = Quaternion.Euler(0, angleView / 2, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dir * viewDistance); //10f es la distancia

        dir = Quaternion.Euler(0, -angleView / 2, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dir * viewDistance); //10f es la distancia
    }

    private void setState(State newState) {
        state = newState;
        stateLight.color = colorStateList[(int)state];
    }

    private void checkState() {
        switch (this.state) {
            case State.Patrol:
                playerDetected = checkSight();
                if (playerDetected) {
                    patrol.stopState();
                    chase.startState(playerDetected);
                    setState(State.Chasing);
                    chaseTimer = chaseTime;
                    break;
                }

                playerDetected = checkHear();
                if (playerDetected) {
                    patrol.stopState();
                    alert.startState(playerDetected);
                    setState(State.Alert);
                    alertTimer = alertTime;
                }
                break;
            case State.Alert:
                playerDetected = checkSight();
                if (playerDetected) {
                    alert.stopState();
                    chase.startState(playerDetected);
                    setState(State.Chasing);
                    chaseTimer = chaseTime;
                    break;
                }

                playerDetected = checkHear();
                if (playerDetected) {
                    alert.updateState(playerDetected);
                    alertTimer = alertTime;
                } else {
                    alertTimer -= Time.deltaTime;
                    patrol.startState();
                    setState(State.Patrol);
                }
                break;

            case State.Chasing:
                playerDetected = checkSight();
                if (playerDetected) {
                    chaseTimer = chaseTime;
                    chase.updateState(playerDetected);
                } else {
                    playerDetected = checkHear();
                    if (playerDetected) {
                        chaseTimer = chaseTime;
                        chase.updateState(playerDetected);
                    }   else {          //Ni veo ni oigo
                        chaseTimer -= Time.deltaTime;
                        if(chaseTimer < 0) {
                            chase.stopState();
                            alert.startState(null);
                            setState(State.Alert);
                            alertTimer = alertTime;
                        }
                    }
                         
                }
                break;
        }
    }

    private Transform checkHear() {
        collidersDetected = Physics.OverlapSphere(transform.position, hearingDistance, playerLayer);
        if (collidersDetected.Length > 0 && collidersDetected[0].GetComponent<PlayerController>().IsWalking()) {
            return collidersDetected[0].transform;
        } else {
            return null;
        }
    }

    private Transform checkSight() {
             collidersDetected = Physics.OverlapSphere(transform.position, hearingDistance, playerLayer);
        if(collidersDetected.Length > 0) {
            Vector3 playerDir = collidersDetected[0].transform.position - transform.position;
            if(Quaternion.Angle(transform.rotation, Quaternion.LookRotation(playerDir)) < angleView / 2) {  // Si esta en rango
                      if(!Physics.Raycast(transform.position + Vector3.up * heightView, playerDir, viewDistance, obstacleLayer)) {
                    return collidersDetected[0].transform;
                }
            }
            Debug.DrawRay(transform.position + Vector3.up * heightView, playerDir, Color.magenta);
        }
        return null;
    }

}
