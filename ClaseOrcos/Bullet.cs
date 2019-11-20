using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.collider.tag == "Enemy") {
    //        Destroy(collision.gameObject);
    //        Debug.Log("DIE!");
    //    }
    //}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("DIE!");
        }
    }
}
