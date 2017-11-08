using UniRx;
using UnityEngine;

public class Scan : MonoBehaviour {

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(1);

    void Start() {
        // generate base stream
        var numberStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => score.Value);

        var scanStream = numberStream.Scan((x, y) => x + y);
        scanStream.Subscribe(x => Debug.Log("Scanned value: " + x));

        // alternative
        //numberStream.Scan((x, y) => x + y)
        //    .Subscribe(x => Debug.Log("Scanned value: " + x));

        // just another way
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Select(_ => score.Value)
        //    .Scan((x, y) => x + y)
        //    .Subscribe(x => Debug.Log("Scanned value: " + x));
    }
}
