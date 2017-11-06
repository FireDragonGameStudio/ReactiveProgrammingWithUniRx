using System;
using UniRx;
using UnityEngine;

public class ChainedTimedOperators : MonoBehaviour {


    void Start () {
        // generate clickstream
        var clickStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        // multiple click counter with time window
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(500)))
            .Where(x => x.Count >= 2)
            .Subscribe(x => Debug.Log("multiple clicks detected! Count: " + x.Count));
    }
}
