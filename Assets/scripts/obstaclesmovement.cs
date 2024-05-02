using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesmovement : MonoBehaviour
{
    public float DestroyBound;
    public float MovingSpeed;
    public moveBackwards MoveBackwards;

    private void Start()
    {
        MoveBackwards = FindObjectOfType<moveBackwards>();
    }
    void Update()
    {
        MovingSpeed = MoveBackwards.movingSpeed;
        transform.Translate(Vector3.back * MovingSpeed * Time.deltaTime);
        DestroyOutOFBounds();
    }
    public void DestroyOutOFBounds()
    {
        if (transform.position.z < DestroyBound)
        {
            Destroy(gameObject);
        }
    }
}
