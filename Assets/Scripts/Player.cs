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
    public int heart = 3;
    private int goalScore = 10;
    public List<GameObject> hearts = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;

        rb.gravityScale = 0;

        hearts.Add(GameObject.Find("Heart1"));
        hearts.Add(GameObject.Find("Heart2"));
        hearts.Add(GameObject.Find("Heart3"));

        // antal hjärtan sparat i fil
        if(PlayerPrefs.HasKey("hearts"))
        {
            heart = PlayerPrefs.GetInt("hearts");

            // ta bort hjärtan om det ska vara färre än 3
            if (heart == 1)
            {
                Destroy(hearts[0]);
                hearts.RemoveAt(0); 
                Destroy(hearts[0]);
                hearts.RemoveAt(0);
            }
            if (heart == 2)
            {
                Destroy(hearts[0]);
                hearts.RemoveAt(0);
            }



        }
        else
        {
            // inte sparat i fil
            PlayerPrefs.SetInt("hearts", 3);
        }
        // läs score från pref om det finns.

        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
            // dom man har plus 10
            goalScore = score + 10;
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
        }




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
            // ta bort ett hjärta
            Destroy(hearts[0]);
            hearts.RemoveAt(0);
            heart = heart - 1;
            UnityEngine.Debug.Log("heart " + heart);
            PlayerPrefs.SetInt("hearts", heart);

            UnityEngine.Debug.Log("hearts player prefs " + PlayerPrefs.GetInt("hearts"));
            // finns hjärtan kvar

            UnityEngine.Debug.Log("collision Troll");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // hjärtan slut
            // börja från scen 1
            if (heart == 0)
            {
                heart = 3;
                PlayerPrefs.SetInt("hearts", 3);
                PlayerPrefs.SetInt("score", 0);
                SceneManager.LoadScene("Level1");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Crystal"))
        {
            score = score + 1;
            if (score >= goalScore )
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
                // om level är 1 gå till level 2
                // om level är 2 gå till level 3
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    PlayerPrefs.SetInt("hearts", heart);
                    PlayerPrefs.SetInt("score", score);
                    SceneManager.LoadScene("Level2");
                }

                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    PlayerPrefs.SetInt("hearts", heart);
                    PlayerPrefs.SetInt("score", score);
                    SceneManager.LoadScene("Level3");
                }

                if (SceneManager.GetActiveScene().name == "Level3")
                {
                    PlayerPrefs.SetInt("hearts", heart);
                    PlayerPrefs.SetInt("score", score);
                    SceneManager.LoadScene("Level4");
                }
            }


        }


    }

}
