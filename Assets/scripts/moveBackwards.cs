using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackwards : MonoBehaviour
{
    [SerializeField] public float movingSpeed;
    [SerializeField] private float increasedSpeed;
    [SerializeField] private float _resetPosition;
    public Vector3 ResetPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < _resetPosition)
        {
            transform.position = ResetPosition;
        }
        movingSpeed += increasedSpeed * Time.deltaTime;
        transform.Translate(Vector3.back * movingSpeed * Time.deltaTime);
    }
}
