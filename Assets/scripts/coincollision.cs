using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollision : MonoBehaviour
{
   


    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        /*CoinsCollector.Coinamount += 1;
        SoundScript.Playsound("CoinSound");*/
    }
}
