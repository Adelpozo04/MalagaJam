using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float _startingPos; //This is starting position of the sprites.
    private float _lengthOfSprite;    //This is the length of the sprites.
    [SerializeField] public float amountOfParallax;  //This is amount of parallax scroll. 
    [SerializeField] public Camera mainCamera;   //Reference of the camera.
    
    private void Start()
    {
        //Getting the starting X position of sprite.
        _startingPos = transform.position.y;    
        //Getting the length of the sprites.
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    
    // Update is called once per frame
    private void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float temp = position.y * (1 - amountOfParallax);
        float distance = position.y * amountOfParallax;

        Vector3 newPosition = new Vector3(transform.position.x, _startingPos + distance, transform.position.z);

        transform.position = newPosition;
        
        if (temp > _startingPos + (_lengthOfSprite / 2))
        {
            _startingPos += _lengthOfSprite;
        }
        else if (temp < _startingPos - (_lengthOfSprite / 2))
        {
            _startingPos -= _lengthOfSprite;
        }
    }
}
