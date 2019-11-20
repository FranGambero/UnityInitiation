using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject canon;
    // Start is called before the first frame update
    void Start()
    {
        canon = GameObject.FindGameObjectWithTag("Player");        
        this.checkLookAt();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }

    void checkLookAt() {
        transform.LookAt(canon.transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
