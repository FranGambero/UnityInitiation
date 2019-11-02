using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_Script : MonoBehaviour
{
    public GameObject bianca, alaska, dela, sharon;
    private Vector3 characterPosition, offscreen;
    private int characterId = 1;
    private SpriteRenderer biancaRenderer, alaskaRenderer, delaRenderer, sharonRenderer;
    private readonly string selectedDrag = "Selected drag";

    private void Awake()
    {
        characterPosition = bianca.transform.position;
        offscreen = alaska.transform.position;
        biancaRenderer = bianca.GetComponent<SpriteRenderer>();
        alaskaRenderer = alaska.GetComponent<SpriteRenderer>();
        delaRenderer = dela.GetComponent<SpriteRenderer>();
        sharonRenderer = sharon.GetComponent<SpriteRenderer>();
    }

    public void nextCharacter()
    {
        switch (characterId)
        {
            case 1:
                PlayerPrefs.SetInt(selectedDrag, 2);
                biancaRenderer.enabled = false;
                bianca.transform.position = offscreen;
                alaska.transform.position = characterPosition;
                alaskaRenderer.enabled = true;
                characterId++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedDrag, 3);
                alaskaRenderer.enabled = false;
                alaska.transform.position = offscreen;
                dela.transform.position = characterPosition;
                delaRenderer.enabled = true;
                characterId++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedDrag, 4);
                delaRenderer.enabled = false;
                dela.transform.position = offscreen;
                sharon.transform.position = characterPosition;
                sharonRenderer.enabled = true;
                characterId++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedDrag, 1);
                sharonRenderer.enabled = false;
                sharon.transform.position = offscreen;
                bianca.transform.position = characterPosition;
                biancaRenderer.enabled = true;
                characterId = 1;
                break;
            default:
                break;
        }
        
    }

    public void previousCharacter()
    {
        switch (characterId)
        {
            case 1:
                PlayerPrefs.SetInt(selectedDrag, 4);
                biancaRenderer.enabled = false;
                bianca.transform.position = offscreen;
                sharon.transform.position = characterPosition;
                sharonRenderer.enabled = true;
                characterId = 4;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedDrag, 1);
                alaskaRenderer.enabled = false;
                alaska.transform.position = offscreen;
                bianca.transform.position = characterPosition;
                biancaRenderer.enabled = true;
                characterId--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedDrag, 2);
                delaRenderer.enabled = false;
                dela.transform.position = offscreen;
                alaska.transform.position = characterPosition;
                alaskaRenderer.enabled = true;
                characterId--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedDrag, 3);
                sharonRenderer.enabled = false;
                sharon.transform.position = offscreen;
                dela.transform.position = characterPosition;
                delaRenderer.enabled = true;
                characterId--;
                break;
            default:
                break;

        }
    }

    public void changeScene()
    {
        Debug.Log("Actual character: " + characterId);
        SceneManager.LoadScene(1);
    }
}
