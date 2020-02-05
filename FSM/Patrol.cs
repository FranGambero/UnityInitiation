using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    public List<Transform> patrolPointList;
    private int currentPatronIndex;
    private Vector3 targetPos;
    private Quaternion targetRot;

    private NavMeshAgent navMeshAgent;
    private Animator anim;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        if (patrolPointList != null && hasPatrol()) {
            for (int i = 0; i < patrolPointList.Count; i++) {
                if (i == patrolPointList.Count - 1) {     // Si es el ultimo
                    Gizmos.DrawLine(getPatrolPos(i) + Vector3.up * .5f, getPatrolPos(0));
                }   else {
                    Gizmos.DrawLine(getPatrolPos(i) + Vector3.up * .5f, getPatrolPos(i + 1));
                }
            }
        }
    }

    private void Awake() {

        this.enabled = false;

        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (hasPatrol()) {
            targetPos = patrolPointList[0].position;
        } else {
            targetPos = transform.position;
            targetRot = transform.rotation;
        }
    }

    private void Update() {
        this.checkPatrol();
    }

    private bool hasPatrol() {
        return patrolPointList.Count > 0;
    }

    private Vector3 getPatrolPos(int patrolIndex) {
        return patrolPointList[patrolIndex].position;
    }

    [ContextMenu("Test State")]
    public void startState() {
        this.enabled = true;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(targetPos);
    }

    public void stopState() {
        this.enabled = false;
    }

    private void checkPatrol() {
        if (Vector3.Distance(targetPos, transform.position) < navMeshAgent.stoppingDistance) {
            if (hasPatrol()) {
                // Actualizar punto de ruta
                updatePatrolIndex();
            } else {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * navMeshAgent.angularSpeed);
                anim.SetBool("IsWalking", false);
            }
        }      else {
            anim.SetBool("IsWalking", true);
        }
    }

    private void updatePatrolIndex() {
        //currentPatronIndex++;
        //if (currentPatronIndex == patrolPointList.Count)
        //    currentPatronIndex = 0;
        currentPatronIndex = (currentPatronIndex + 1) % patrolPointList.Count;
        targetPos = getPatrolPos(currentPatronIndex);
        navMeshAgent.SetDestination(targetPos);
    }

}
