using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RigidBody2D;

    public GameObject GameWonCanvas;

    public GameObject GamePauseCanvas;

    private bool isGameWon = false;

    private bool isGamePaused = false;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon || isGamePaused)
        {
            RigidBody2D.velocity = new Vector2(0f, 0f);
            return;
        }
        if (Input.GetAxis("Cancel") > 0)
        {
            RigidBody2D.velocity = new Vector2(0f, 0f);
            GamePauseCanvas.SetActive(true);
            isGamePaused = true;
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
            Debug.Log("Level Coimplete");
            GameWonCanvas.SetActive(true);
            isGameWon = true;
        }


    }
}
