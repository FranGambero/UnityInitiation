using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainCharacter : MonoBehaviour
{
    //public Sprite bianca, alaska, dela, sharon;
    //private SpriteRenderer mySprite;
    public GameObject myCharacter;
    public GameObject biancaPre, alaskaPre, delaPre, sharonPre;
    private readonly string selectedDrag = "Selected drag";        

    private void Awake()
    {
        //mySprite = this.GetComponent<SpriteRenderer>();

        /*biancaPre = this.GetComponent<GameObject>();
        alaskaPre = this.GetComponent<GameObject>();
        delaPre =   this.GetComponent<GameObject>();
        sharonPre = this.GetComponent<GameObject>();  */
    }

    void Start()
    {
        int getCharacter = PlayerPrefs.GetInt(selectedDrag);
        //Debug.Log("Tienes: " + getCharacter);

        switch (getCharacter)
        {
            case 1:
                biancaPre.SetActive(true);                                         
                break;
            case 2:
                alaskaPre.SetActive(true);
                break;
            case 3:
                delaPre.SetActive(true);
                break;
            case 4:
                sharonPre.SetActive(true);
                break;
            default:
                break;
        }
                                   
                                
    }

}
