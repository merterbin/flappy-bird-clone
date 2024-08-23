using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    private AudioSource hitAudio;
    private void Start()
    {
        hitAudio = GetComponent<AudioSource>();
    } 
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hitAudio.Play();
        }
    }
}
