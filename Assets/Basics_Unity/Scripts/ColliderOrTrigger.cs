using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOrTrigger : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollisionEnter called on " + gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter called on " + gameObject.name);
    }
}
