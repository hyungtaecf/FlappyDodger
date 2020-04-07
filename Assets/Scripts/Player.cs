using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 5.5f; //half of the width
        

    private Rigidbody2D rb;

    private AudioSource audio;

    private float collisionVolumeLimiter = 40f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        if (audio == null) audio = gameObject.AddComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition); //Same as going 0 to the left and 1 to the right 
        if (Input.anyKey)
        {
            rb.AddForce(Vector2.up * 50);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = 0.001f;
        rb.gravityScale = 10;
        audio.volume = collisionInfo.relativeVelocity.magnitude/ collisionVolumeLimiter;
        audio.PlayOneShot(Resources.Load<AudioClip>("DM-CGS-43"));
        audio.PlayOneShot(Resources.Load<AudioClip>("death"));
        FindObjectOfType<GameManager>().EndGame();
    }
}
