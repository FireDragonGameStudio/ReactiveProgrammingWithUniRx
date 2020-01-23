﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    [SerializeField]
    private Button scriptButton;

    private void Start() {
        if (scriptButton) {
            scriptButton.onClick.AddListener(OnClick_EventListener);
        }
    }

    public void OnClick() {
        Debug.Log("OnClick called.");
    }

    public void OnClick_EventTrigger() {
        Debug.Log("OnClick_EventTrigger called.");
    }

    private void OnClick_EventListener() {
        Debug.Log("OnClick_EventListener called.");
    }

    private void OnDestroy() {
        if (scriptButton) {
            scriptButton.onClick.RemoveAllListeners();
        }
    }
}
