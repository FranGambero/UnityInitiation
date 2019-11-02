using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainCharacter : MonoBehaviour
{
    public Sprite bianca, alaska, dela, sharon;
    private SpriteRenderer mySprite;
    private readonly string selectedDrag = "Selected drag";


    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int getCharacter = PlayerPrefs.GetInt(selectedDrag);
        Debug.Log(getCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = bianca;
                break;
            case 2:
                mySprite.sprite = alaska;
                break;
            case 3:
                mySprite.sprite = dela;
                break;
            case 4:
                mySprite.sprite = sharon;
                break;
            default:
                break;
        }
                                
    }

}
