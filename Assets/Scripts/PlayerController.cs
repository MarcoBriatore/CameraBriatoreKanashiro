using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private float speed = 10;
    private float rotationSpeed = 720;
    private AudioManager audioManager;

    private void Awake()
    {

        audioManager = FindObjectOfType<AudioManager>(); ;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager.Play("Ready");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Movement(horizontal, vertical);
        Animation(horizontal, vertical);
    }

    void Movement(float horizontal, float vertical)
    {
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(speed * movementDirection.normalized * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Animation(float horizontal, float vertical)
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            audioManager.Play("Go");
            animator.SetBool("Idle", false);
        }
    }
    
}
