using System;
using UniRx;
using UnityEngine;

public class ChainedOperators : MonoBehaviour {
    private void Start () {
        // generate clickstream
        //UniRx.IObservable<long> clickStream = Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0));

        // click counter
        //UniRx.IObservable<long> countStream = clickStream.Select(x => x = 1);
        //countStream.Scan((x, y) => x + y)
        //    .Subscribe(x => Debug.Log("Click: " + x));

        // another way of writing
        //clickStream.Select(x => x = 1)
        //    .Scan((x, y) => x + y)
        //    .Subscribe(x => Debug.Log("Click: " + x));

        // just another way
        Observable.EveryUpdate()
           .Where(_ => Input.GetMouseButtonDown(0))
           .Select(x => x = 1)
           .Scan((x, y) => x + y)
           .Subscribe(x => Debug.Log($"Click: {x}"));
    }
}
