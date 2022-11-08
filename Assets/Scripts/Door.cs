using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;
    private bool isOpen = false;
    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
        set
        {
            isOpen = value;
            GetComponent<SpriteRenderer>().sprite = openSprite;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
        IsOpen = true;
    }
}
