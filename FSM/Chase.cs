using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {
    public AudioClip chaseSound;

    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;

    private void Awake() {
        this.enabled = false;
        this.anim = GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            navMeshAgent.isStopped = true;
            anim.SetBool("IsWalking", false);
            GameManager.instance.GameOver();
        }
    }

    public void startState(Transform targetT) {
        enabled = true;
        anim.SetBool("IsWalking", true);
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(targetT.position);

        GameManager.instance.UpdateEnemiesChasing(+1);

        audioSource.PlayOneShot(chaseSound);
    }

    public void updateState(Transform targetT) {
        navMeshAgent.SetDestination(targetT.position);
    }

    public void stopState() {
        enabled = false;
        GameManager.instance.UpdateEnemiesChasing(-1);
    }
}
