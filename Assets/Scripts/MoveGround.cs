using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 3f;
    private SpriteRenderer sr; 
    private Vector3 startSize;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startSize = new Vector2(sr.size.x, sr.size.y);        
    }
    private void Update()
    {
        sr.size = new Vector2(sr.size.x + speed * Time.deltaTime, sr.size.y);
        if (sr.size.x > width)
        {
            sr.size = startSize;
        }
    }

    
}
