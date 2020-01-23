using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableRandomEventTrigger : ObservableTriggerBase {

    public float IntervalMax = 1.0f;
    public float IntervalMin = 0.1f; // must not be set from external

    private Subject<Unit> onRandomEvent;

    private float _currentInterval = 0f;
    private float _currentIntervalDuration = 0f;

    private void Start() {
        _currentInterval = GenerateNewInterval();
    }

    private void Update() {
        _currentIntervalDuration += Time.deltaTime;

        if (_currentIntervalDuration >= _currentInterval) {
            if (onRandomEvent != null) {
                onRandomEvent.OnNext(Unit.Default);
            }

            //Debug.Log("Random Event Interval:" + _currentInterval);

            // reset interval and generate new
            _currentIntervalDuration = 0f;
            _currentInterval = GenerateNewInterval();
        }
    }

    public IObservable<Unit> OnRandomEventAsObservable() {
        return onRandomEvent ?? (onRandomEvent = new Subject<Unit>());
    }

    protected override void RaiseOnCompletedOnDestroy() {
        if (onRandomEvent != null) {
            onRandomEvent.OnCompleted();
        }
    }

    private float GenerateNewInterval() {
        return Random.Range(IntervalMin, IntervalMax);
    }
}
