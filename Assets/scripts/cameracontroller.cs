using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        float positionX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref currentVelocity.x, smoothTime);
        Vector3 newNonJmpFollowPosition = new Vector3(positionX, transform.position.y, target.position.z + offset.z);
        transform.position = newNonJmpFollowPosition;
    }
   
}
