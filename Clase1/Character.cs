using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string nombre;
    public Razas miRaza;
    public enum Razas{
        Humano, Elfo, Enano, Orco
    }

    // Start is called before the first frame update
    void Start(){
        //Debug.Log(this.getDescription());
        
    }

    public string getDescription(){
        return (nombre + " el " + miRaza);
    }

}
