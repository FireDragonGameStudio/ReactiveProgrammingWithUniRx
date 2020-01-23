using UniRx;
using UnityEngine;

public class Filter : MonoBehaviour {

    void Start() {
        // generate base stream
        //UniRx.IObservable<int> numberStream = Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Select(_ => Random.Range(0, 10));

        //UniRx.IObservable<int> mapStream = numberStream.Where(x => x > 4);
        //mapStream.Subscribe(x => Debug.Log("Filtered value: " + x));

        // alternative
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => Random.Range(0, 10))
            .Where(x => x > 4)
            .Subscribe(x => Debug.Log($"Filtered value >4: {x}"));
    }
}
