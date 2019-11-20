using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject orc;
    public Transform[] spawnPositions;

    private void Start() {
        InvokeRepeating(nameof(spawnOrk), 1f, 1f);
    }

    private void spawnOrk() {
               Instantiate(orc, spawnPositions[Random.Range(0, spawnPositions.Length)].position, Quaternion.identity);
    }
}
