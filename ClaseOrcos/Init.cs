using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    Rigidbody myRb;
    private bool playerColision;
    float radius = 4;
    public LayerMask myLayerMask, damageableLayers;
    private RaycastHit[] hits;

    private bool growing;

    private void Start() {
        
    }

    //private void OnMouseDown() {
    //    growing = true;
    //}

    //private void OnMouseUp() {
    //    growing = false;
    //}

    //private void Update() {
    //    if (growing) {
    //        transform.localScale += Vector3.one * Time.deltaTime;
    //    }
    //}

    //private void Awake() {
    //    enabled = false;
    //}
    //private void Start() {
    //    Explode();
    //}

    //private void Explode() {
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, radius, damageableLayers);
    //    for(int i=0; i < colliders.Length; i++) {
    //        Debug.Log(colliders[i].gameObject + "boom");
    //    }
    //}

    //private void Update() {
    //    //if (Physics.Raycast(transform.position, transform.forward, 2f, myLayerMask)) {
    //    //    Debug.Log("Tengo algo delante, iiiuuuuuu");
    //    //}
    //    hits = Physics.RaycastAll(transform.position, transform.forward, 2f);
    //    for(int i=0; i<hits.Length; i++) {
    //        Debug.Log(hits[i].collider.gameObject);
    //    }

    //    //if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, myLayerMask)) {
    //    //    if(hit.collider != null) {
    //    //     Debug.Log("Tengo " + hit.collider.gameObject + " a " + hit.distance + " unidades");
    //    //    }

    //    //}

    //    Debug.DrawRay(transform.position, transform.forward * 2f, Color.cyan);
    //}

    //private void OnTriggerEnter(Collider other) {
    //    if(other.tag == "Player")
    //        Debug.Log("Soy " + gameObject + " y entro en " + other.gameObject);
    //}

    //private void OnTriggerExit(Collider other) {
    //    if(other.tag == "Player") {
    //        Debug.Log("Sale el " + other.gameObject);
    //    }

    //}

    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.collider.tag == "Player") {
    //        playerColision = true;  
    //        Debug.Log("Entro en " + collision.gameObject); // Player
    //    }   

    //}

    //private void OnCollisionExit(Collision collision) {
    //    if (collision.collider.tag == "Player") {
    //        playerColision = false;
    //        Debug.Log("Salgo de " + collision.gameObject);
    //    }

    //}
    //private void Update() {
    //    if (playerColision) {
    //        Debug.Log("Estoy colisionando locamente");
    //    }
    //}

    //private void Awake() {
    //    myRb = GetComponent<Rigidbody>();
    //}



    //private void OnCollisionStay(Collision collision) {
    //    if (collision.collider.tag == "Player")
    //        Debug.Log("Estoy colisionando con " + collision.gameObject);
    //}
}
