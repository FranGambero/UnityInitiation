using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{

    public GameObject miObjeto;
    public List<GameObject> listaInstancias;
    public int quantity;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(miObjeto, Vector3.zero, Quaternion.identity);   
        this.createInstances(quantity);
        this.destruction();
    }

    void createInstances(int quantity = 1)
    {
        Vector3 position = new Vector3();
        for (int i=0; i<quantity; i++)
        {
            position.Set(0, i, 0);
            //Instantiate(miObjeto, position, Quaternion.identity);
            GameObject obj = Instantiate(miObjeto, position, Quaternion.identity);

            listaInstancias.Add(obj);
        }
        Debug.Log("numero de cosos: " + listaInstancias.Count);
    }

    void destruction()
    {
        //yield return new WaitForSeconds(5);
        Destroy(listaInstancias[listaInstancias.Count - 1], 2);
    }
}
