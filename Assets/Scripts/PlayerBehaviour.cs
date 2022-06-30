using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float movementSpeed;

    public float jumpForce;
    public int maxJumps;

    int hasJump;
    Rigidbody rb;

    AudioSource fuenteAudio;
    public AudioClip jump;
    public AudioClip abajo;

    void Start()
    {
        movementSpeed = 4;

        hasJump = maxJumps;
        rb = GetComponent<Rigidbody>();
        fuenteAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(0, 0, movementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0, 0, movementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && hasJump > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump--;

            fuenteAudio.clip = jump;
            fuenteAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale -= new Vector3(0, 0.5f, 0);
            fuenteAudio.clip = abajo;
            fuenteAudio.Play();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale += new Vector3(0, 0.5f, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Plano")
        {
            hasJump = maxJumps;
        }
    }
}
