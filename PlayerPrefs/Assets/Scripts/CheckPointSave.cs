using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSave : MonoBehaviour
{
    //private void OnEnable()
    //{
    //    EventManager.OnCheckPoint += SavePosition;
    //}
    private void Start()

    {
        if (CustomPlayerPrefs.GetVector3("PlayerPos") != null)
        {
            Debug.Log(CustomPlayerPrefs.GetVector3("PlayerPos"));

            FindObjectOfType<PlayerController>().transform.position = CustomPlayerPrefs.GetVector3("PlayerPos");
        }
    }
    void SavePosition()
    {
        //Debug.Log(CustomPlayerPrefs.GetVector3("PlayerPos"));
        //CustomPlayerPrefs.SetVector3("PlayerPos", transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //EventManager.OnCheckPoint -= SavePosition;
            CustomPlayerPrefs.SetVector3("PlayerPos", transform.position);

        }
    }
}
