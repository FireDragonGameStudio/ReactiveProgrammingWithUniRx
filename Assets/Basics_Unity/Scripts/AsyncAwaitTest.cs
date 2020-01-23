using UnityEngine;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class AsyncAwaitTest : MonoBehaviour {

    [SerializeField]
    private bool startAsynTask = false;

    private float _waitForMilliSec = 1500f;

    private async void Start() {
        Debug.Log("async task called");
        await UniRxSynchronizationContextSolves();
    }

    // example: How to call async task during update
    private async void Update() {
        if (startAsynTask) {
            startAsynTask = false;

            Debug.Log("async task called");

            await UniRxSynchronizationContextSolves();
        }
    }

    async Task UniRxSynchronizationContextSolves() {
        Debug.Log("start delay");

        // UniRxSynchronizationContext is automatically used.
        await Task.Delay(TimeSpan.FromMilliseconds(1500f));

        Debug.Log("from another thread, but you can touch gameobjects.");
        GameObject.Find("AsyncAwaitTestText").GetComponent<Text>().text ="waited " + _waitForMilliSec + "ms";
    }
}
