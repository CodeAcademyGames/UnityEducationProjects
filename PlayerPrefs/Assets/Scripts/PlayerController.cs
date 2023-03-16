using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Colorable"))
    //    {
    //        collision.transform.GetComponent<Renderer>().material.color = Color.green;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            EventManager.CoinCollectedEventStart();
        }
        if (other.CompareTag("Finish"))
        {
            EventManager.ArivveFinishEventStart();
        }
        //if (other.CompareTag("CheckPoint"))
        //{
        //    Debug.Log("PLayerOnTrigger");
        //    EventManager.CheckPointEventStart();
        //}
    }
}
