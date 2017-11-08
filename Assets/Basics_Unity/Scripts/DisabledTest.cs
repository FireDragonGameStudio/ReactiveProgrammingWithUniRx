using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledTest : MonoBehaviour {


    void Awake() {
        Debug.Log("Awake called on " + gameObject.name);
    }

    void Start () {
        Debug.Log("Start called on " + gameObject.name);
    }

    void OnEnable() {
        Debug.Log("OnEnable called on " + gameObject.name);
    }

    void FixedUpdate() {
        Debug.Log("FixedUpdate called on " + gameObject.name);
    }

    void Update () {
        Debug.Log("Update called on " + gameObject.name);
    }

    void LateUpdate() {
        Debug.Log("LateUpdate called on " + gameObject.name);
    }
}
