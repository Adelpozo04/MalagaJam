using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesContainer : MonoBehaviour
{
    public static SpritesContainer Instance;

    public Sprite leftClick;
    public Sprite rightClick;
    public Sprite middleClick;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;    
        else Destroy(gameObject);

    }
    
}
