using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ParalaxBackground : MonoBehaviour
{ 
private float _startingPos,
            _lengthOfSprite;
public float AmountOfParallax; 
public Camera MainCamera;



private void Start()
{
    _startingPos = transform.position.x;

    _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
}



private void Update()
{
    Vector3 Position = MainCamera.transform.position;
    float Temp = Position.x * (1 - AmountOfParallax);
    float Distance = Position.x * AmountOfParallax;
    Vector3 NewPosition = new Vector3(_startingPos + Distance, transform.position.y, transform.position.z);
    transform.position = NewPosition;

   
}
}
