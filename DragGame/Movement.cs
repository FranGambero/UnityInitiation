using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private SpriteRenderer mySpriteRenderer;
    private bool flippedX = true;
    public GameObject attack;
    private int steps = 5;
    public Text stepsText;
    public GameObject gameOverPanel;
    private bool alive=true;

    // Start is called before the first frame update
    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        steps = steps + PlayerPrefs.GetInt("Level");
        Debug.Log("Pasos: " + steps);
        if(stepsText)
            stepsText.text = steps + " steps left";
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            this.GetInput();
            if (steps <= 0)
            {
                this.alive = false;
                this.endGame();
            }
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        Transform transformAux = transform;

        if (Input.GetKeyDown(KeyCode.W)){
            direction = Vector2.up;
            updateSteps();
            transform.Translate(0, 0, 1.2f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
            mySpriteRenderer.flipX = true;
            updateSteps();
            transform.Translate(-1.2f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
            mySpriteRenderer.flipX = false;
            updateSteps();
            transform.Translate(1.2f, 0, 0);
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down; 
            updateSteps();           
            transform.Translate(0, 0, -1.2f);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            updateSteps();
            castAttack();
        }
    }

    private void updateSteps()
    {
        steps--;
        if(stepsText)
            stepsText.text = steps + " movimientos restantes";
    }

    private void castAttack()
    {
        Vector3 attackPos = transform.position;

        if (mySpriteRenderer.flipX)
        {
            attackPos = attackPos + new Vector3(-1.2f, 0, 0);
            Destroy(Instantiate(attack, attackPos, Quaternion.identity), 1);
            Destroy(Instantiate(attack, attackPos + new Vector3(-1.2f, 0, 0), Quaternion.identity), 1);
        }
        else
        {
            attackPos = attackPos + new Vector3(1.2f, 0, 0);
            Destroy(Instantiate(attack, attackPos, Quaternion.identity), 1);
            Destroy(Instantiate(attack, attackPos + new Vector3(1.2f, 0, 0), Quaternion.identity), 1);
        }
    }

    private void endGame()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 1;                    
    }

    
}
