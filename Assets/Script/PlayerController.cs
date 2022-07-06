using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RigidBody2D;

    public GameObject GameWonCanvas;

    public GameObject GameOverCanvas;

    public GameObject GameLostCanvas;

    public GameObject GamePauseCanvas;

    private bool isGameWon = false;

    private bool isGameLost = false;

    private bool isGamePaused = false;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon || isGamePaused || isGameLost)
        {

            return;
        }
        if (Input.GetAxis("Cancel") > 0)
        {
            //RigidBody2D.velocity = new Vector2(0f, 0f);
            //Debug.Log("toggle pause pressed Escape");

            TogglePauseMenu(true);
            return;
        }
       
        if (Input.GetAxis("Jump") > 0)
        {
            RigidBody2D.velocity = new Vector2(0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            RigidBody2D.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            RigidBody2D.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            RigidBody2D.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            RigidBody2D.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            RigidBody2D.velocity = new Vector2(0f, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            //Debug.Log("Level Coimplete");
            GameWonCanvas.SetActive(true);
            isGameWon = true;
            RigidBody2D.velocity = new Vector2(0f, 0f);
        }
        else if (other.tag == "Enemy" || other.tag == "Obstacles")
        {
            GameLostCanvas.SetActive(true);
            isGameLost = true;
            RigidBody2D.velocity = new Vector2(0f, 0f);
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        //GameLostCanvas.SetActive(false);
        isGameWon = false;
        isGameLost = false;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameLostCanvas.SetActive(false);
        //isGameWon = false;
        isGameLost = false;
    }
    public void GameWon()
    {
        int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (NextLevel < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameWonCanvas.SetActive(false);
            isGameWon = false;
        }
        else
        {
            GameOverCanvas.SetActive(false);
        }

        //isGameLost = false;
    }

    public void GameOver()
    {

    }

    public void TogglePauseMenu(bool isPaused)
    {
        //Debug.Log("Level Pause"+isPaused);
        isGamePaused = isPaused;
        GamePauseCanvas.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
            Input.ResetInputAxes();
        }

        //isGamePaused = true;
    }
}
