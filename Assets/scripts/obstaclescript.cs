using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        Time.timeScale = 0f;
        FindObjectOfType<GameManager>().endgame();

    }

}
