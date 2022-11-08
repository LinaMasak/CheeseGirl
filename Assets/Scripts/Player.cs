using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4;
    public TMP_Text scoreDisplay;
    private int score = 0;
    public GameObject door;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;

        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // up
            rb.velocity = Vector2.up * speed;
            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // turn left
            rb.velocity = Vector2.left * speed;
            rb.position = new Vector2(rb.position.x, (float)Math.Round(rb.position.y));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // turn right
            rb.velocity = Vector2.right * speed;
            rb.position = new Vector2(rb.position.x, (float)Math.Round(rb.position.y));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // down
            rb.velocity = Vector2.down * speed;
            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Grass"))
        {
            UnityEngine.Debug.Log("collision grass");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.StartsWith("Troll"))
        {

            UnityEngine.Debug.Log("collision Troll");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Crystal"))
        {
            score = score + 1;
            if (score >= 10 )
            {
                door.GetComponent<Door>().IsOpen = true;
            }
            scoreDisplay.text = "Score: " + score;
            UnityEngine.Debug.Log("collision crystal");
            Destroy(collision.gameObject);

        }
        
        if (collision.gameObject.name.StartsWith("Door"))
        {
            Door door = collision.gameObject.GetComponent<Door>();
            if (door.IsOpen)
            {
                UnityEngine.Debug.Log("next level");
                
                //game.NextLevel();
            }
        }


    }

}
