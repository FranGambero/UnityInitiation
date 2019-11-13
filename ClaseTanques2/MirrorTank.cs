using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTank : MonoBehaviour
{
    //public GameObject playerTank;
    public float moveSpeed;
    public bool mirror;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * (mirror ? -1 : 1);
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0 || v != 0) {
            //Partiendo de mi posicion le sumo un valor absoluto para mirar a esa direccion
            Vector3 lookPos = transform.position + new Vector3(h, 0, v);
            transform.LookAt(lookPos);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
