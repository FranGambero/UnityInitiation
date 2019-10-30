using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Ej2
    public float miSalud;
    public bool miInmortalidad = false;
    private float saludInicial = 100;
    private Character miCaracter;

    void Awake()
    {
        miCaracter = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(miCaracter.getDescription());

        if(miCaracter.miRaza.ToString() == "Humano")
        {
            receiveDamage(25);

        }else if(miCaracter.miRaza.ToString() == "Enano")
        {
            receiveDamage(10, 4);
        }
        else{
            togglemiInmortalidad(true);
            receiveDamage(25);
        }

        Debug.Log(getCurrentHealth());
    }

    void togglemiInmortalidad()
    {
        miInmortalidad = !miInmortalidad;
    }

    void togglemiInmortalidad(bool inmortalParam)
    {
        miInmortalidad = inmortalParam;
    }

    void receiveDamage(int damage, int quantity = 1)
    {
        if(!miInmortalidad)
            miSalud = miSalud - damage*quantity;
    }

    string getCurrentHealth()
    {
        return "My health: " + (miSalud/saludInicial)*100 + "%";
    }

}
