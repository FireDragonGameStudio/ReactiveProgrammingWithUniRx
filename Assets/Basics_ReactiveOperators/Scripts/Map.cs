using UniRx;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(0);

    void Start() {
        // generate base stream
        var numberStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => ++score.Value);
        //.Subscribe(x => Debug.Log("Generated value: " + x));

        var mapStream = numberStream.Select(x => x * 10);
        mapStream.Subscribe(x => Debug.Log("Mapped value: " + x));

        // alternative
        //numberStream.Select(x => x * 10)
        //    .Subscribe(x => Debug.Log("Mapped value: " + x));

        // just another way
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Select(_ => ++score.Value)
        //    .Select(x => x * 10)
        //    .Subscribe(x => Debug.Log("Mapped value: " + x));
    }
}
