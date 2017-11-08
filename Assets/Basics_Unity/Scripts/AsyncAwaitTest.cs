using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class AsyncAwaitTest : MonoBehaviour {

    //[SerializeField]
    //private bool startAsynTask = false;

    private float _waitForMilliSec = 1500f;

    void Start() {
        // start async task
        UniRxSynchronizationContextSolves();
        Debug.Log("async task called");
    }

    // example: How to call async task during update
    //void Update () {
    //    if (startAsynTask) {
    //        startAsynTask = false;
            
    //        // start async task
    //        UniRxSynchronizationContextSolves();

    //        Debug.Log("async task called");
    //    }
    //}

    async Task UniRxSynchronizationContextSolves() {
        Debug.Log("start delay");

        // UniRxSynchronizationContext is automatically used.
        await Task.Delay(TimeSpan.FromMilliseconds(1500f));

        Debug.Log("from another thread, but you can touch gameobjects.");
        GameObject.Find("AsyncAwaitTestText").GetComponent<Text>().text ="waited " + _waitForMilliSec + "ms";
    }
}
