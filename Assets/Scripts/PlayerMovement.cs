using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] AudioSource hitAudio;
    [SerializeField] AudioSource dieAudio;
    [SerializeField] AudioSource moveAudio;
    private Rigidbody2D rb;
    
    public void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                Debug.Log("touched");
                Jump();                          
            }
        }else if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }               
    }
    public void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 10);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Skybox"))){
            GameManager.instance.GameOver();
            Time.timeScale = 0;
            if (collision.gameObject.CompareTag("Ground"))
            {
                Debug.Log("die");
                moveAudio.Stop();
                dieAudio.Play();
            }
            else if (collision.gameObject.CompareTag("Pipes"))
            {
                Debug.Log("hit");
                moveAudio.Stop();
                hitAudio.Play();
            }
        }            
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * speed;
    }
}


