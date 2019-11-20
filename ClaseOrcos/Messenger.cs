using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    public LayerMask myLayerMask;
    private RaycastHit hit;
    private bool onGround = false;
    public float moveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.moveBoy();

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, myLayerMask)) {
            if (hit.collider.tag == "Blacksmith") {
                moveSpeed = 0;
            }
            else if (hit.collider != null) {
                Debug.Log("Choco con " + hit.collider.gameObject + " a " + hit.distance + " unidades");
                transform.Rotate(0,90,0);
            }

        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ground") {
            onGround = true;
            moveSpeed = moveSpeed / 2;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Ground") {
            onGround = false;
            moveSpeed = moveSpeed * 2;
        }
       }

    private void moveBoy() {

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


}
