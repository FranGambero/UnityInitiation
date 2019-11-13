using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTank : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletDuration = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletDuration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
