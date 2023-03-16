using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnCollectedCoin;
    public static event Action OnArrivedFinish;
    //public static event Action OnCheckPoint;
    public static void CoinCollectedEventStart()
    {
        OnCollectedCoin.Invoke();
    }
    public static void ArivveFinishEventStart()
    {
        OnArrivedFinish.Invoke();
    }
    //public static void CheckPointEventStart()
    //{
    //    Debug.Log("eventManagerMethod");
    //    OnCheckPoint?.Invoke();
    //}
}
