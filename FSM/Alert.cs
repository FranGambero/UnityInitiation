using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alert : MonoBehaviour
{
    public AudioClip alertSound;
    private Quaternion targetRot;
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;

    private void Awake() {
        this.enabled = false;
        this.anim = GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRot, navMeshAgent.angularSpeed * Time.deltaTime);
    }

    public void startState(Transform targetT) {
        updateTargetRot(targetT);

        this.enabled = true;
        anim.SetBool("IsWalking", false);
        navMeshAgent.enabled = false;
        audioSource.PlayOneShot(alertSound);
    }

    public void updateState(Transform targetT) {
        updateTargetRot(targetT);
    }

    public void stopState() {
        this.enabled = false;
    }

    private void updateTargetRot(Transform targetT) {
        if (targetT) {
            targetRot = Quaternion.LookRotation(targetT.position - transform.position);
        }     else {
            targetRot = transform.rotation;
        }
    }
}
