using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MultiThreadingTest : MonoBehaviour {

    void Start () {
        // Observable.Start is start factory methods on specified scheduler
        // default is on ThreadPool
        var heavyMethod = Observable.Start(() =>
        {
            // heavy method...
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            return 10;
        });

        var heavyMethod2 = Observable.Start(() =>
        {
            // heavy method...
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            return 30;
        });

        // Join and await two other thread values
        Observable.WhenAll(heavyMethod, heavyMethod2)
            .ObserveOnMainThread() // return to main thread
            .Subscribe(xs => {
                // Unity can't touch GameObject from other thread
                // but using ObserveOnMainThread, you can touch GameObject naturally.
                GameObject.Find("MultiThreadingTestText").GetComponent<Text>().text = xs[0] + ":" + xs[1];
            });
    }
}
