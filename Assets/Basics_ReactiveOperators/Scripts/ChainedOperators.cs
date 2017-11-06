using System;
using UniRx;
using UnityEngine;

public class ChainedOperators : MonoBehaviour {


    void Start () {
        // generate clickstream
        var clickStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        // click counter
        var countStream = clickStream.Select(x => x = 1);
        countStream.Scan((x, y) => x + y)
            .Subscribe(x => Debug.Log("Click: " + x));

        // another way of writing
        //clickStream.Select(x => x = 1)
        //    .Scan((x, y) => x + y)
        //    .Subscribe(x => Debug.Log("Click: " + x));
    }
}
