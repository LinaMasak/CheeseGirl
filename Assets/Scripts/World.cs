using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
 {
    public GameObject wallprefab;
    public GameObject sandprefab;
    public GameObject grassprefab;
    public GameObject crystalprefab;

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
            float x = Random.Range(1, 24);
            float y = Random.Range(1, 10);
            Instantiate(crystalprefab, new Vector2(x, y), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }


}
