using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private int desiredLane = 1;
    public float laneDistance = 2;
    public float jumpforce;
    private Rigidbody playerrb;
    private bool Isgrounded;
    private bool Isrolling;
    public Animator playerAnim;
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Isgrounded = true;
    }

    void Update()
    {
        rolling();
        Jump();

        if (swipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (swipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,40*Time.deltaTime);
    }

    public void Jump()
    {
        if (swipeManager.swipeUp && Isgrounded && !Isrolling)
        {
            playerrb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            playerAnim.SetTrigger("jump");
            Isgrounded = false;
        }

    }

    public void rolling()
    {
        if (swipeManager.swipeDown && Isgrounded)
    {
        if (!Isrolling)
        {
            playerAnim.SetTrigger("roll");
            Isrolling = true;
        }

        }
        else if (swipeManager.swipeDown && !Isgrounded)
        {
            playerrb.velocity = new Vector3(playerrb.velocity.x, -jumpforce, playerrb.velocity.z);
            playerAnim.SetTrigger("roll");
            Isrolling = false;
        }
        else
    {
        Isrolling = false;
    }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Isgrounded = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            // Call GameManager to increment coin count
            GameManager.instance.IncrementCoinCount();
            // Destroy the coin
            Destroy(other.gameObject);
        }
    }
}
