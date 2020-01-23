using UnityEngine;

public class ActivationTest : MonoBehaviour {
    private void Awake() {
        Debug.Log("Awake called on " + gameObject.name);
    }

    private void Start () {
        Debug.Log("Start called on " + gameObject.name);
    }

    private void OnEnable() {
        Debug.Log("OnEnable called on " + gameObject.name);
    }

    private void FixedUpdate() {
        Debug.Log("FixedUpdate called on " + gameObject.name);
    }

    private void Update () {
        Debug.Log("Update called on " + gameObject.name);
    }

    private void LateUpdate() {
        Debug.Log("LateUpdate called on " + gameObject.name);
    }

    private void OnDestroy() {
        Debug.Log("OnDestroy called on " + gameObject.name);
    }
}
