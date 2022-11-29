using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
 {
    public GameObject wallprefab;
    public GameObject sandprefab;
    public GameObject grassprefab;
    public GameObject crystalprefab;
    public GameObject trollprefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 25; x++)
        {
            Instantiate(wallprefab, new Vector2(x, 0), Quaternion.identity);
            Instantiate(wallprefab, new Vector2(x, 10), Quaternion.identity);
        }
        for(int y = 0; y < 10; y++)
        {
            Instantiate(wallprefab, new Vector2(0, y), Quaternion.identity);
            Instantiate(wallprefab, new Vector2(24, y), Quaternion.identity);
        }
        for(int y = 1; y < 10; y++)
        {
            for(int x = 1; x < 24; x++)
            {
                Instantiate(sandprefab, new Vector2(x, y), Quaternion.identity);

            }
        }
        for(int y = 1; y < 10; y++)
        {
            for (int x = 1; x < 24; x++)
            {
                Instantiate(grassprefab, new Vector2(x, y), Quaternion.identity);

            }
        }

        for (int i = 0; i < 10; i++)
        {
            float x = UnityEngine.Random.Range(2, 24);
            float y = UnityEngine.Random.Range(2, 10);
            Instantiate(crystalprefab, new Vector2(x, y), Quaternion.identity);
        }
        
        if (SceneManager.GetActiveScene().name=="Level2")
        {
            for (int i = 0; i < 2; i++)
            {
                float x = UnityEngine.Random.Range(2, 24);
                float y = UnityEngine.Random.Range(2, 10);
                Instantiate(trollprefab, new Vector2(x, y), Quaternion.identity);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            for (int i = 0; i < 5; i++)
            {
                float x = UnityEngine.Random.Range(2, 24);
                float y = UnityEngine.Random.Range(2, 10);
                Instantiate(trollprefab, new Vector2(x, y), Quaternion.identity);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            for (int i = 0; i < 8; i++)
            {
                float x = UnityEngine.Random.Range(2, 24);
                float y = UnityEngine.Random.Range(2, 10);
                Instantiate(trollprefab, new Vector2(x, y), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }


}
