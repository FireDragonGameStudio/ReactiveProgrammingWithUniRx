using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager_02 : MonoBehaviour {

    [SerializeField]
    private GameObject scoreBoderCube;

    [SerializeField]
    private ColorCube colorCubePrefab;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Button tapScore;

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(0);
    [SerializeField]
    private BoolReactiveProperty isScoreable = new BoolReactiveProperty(false);

    [SerializeField]
    private Material[] _materialsAlpha;

    private ColorCubePool _cubePool = null;

    // Use this for initialization
    void Start() {
        // also possible as singleton or other global gameobject
        _cubePool = new ColorCubePool(colorCubePrefab);

        // spawn cubes at random time interval with object pool
        var spawnStream = gameObject.AddComponent<ObservableRandomEventTrigger>();
        spawnStream.OnRandomEventAsObservable().Subscribe(_ => {
            var colorCube = _cubePool.Rent();
            colorCube.ColorCubePool = _cubePool;

            Debug.Log("SPAWNED NEW CUBE FROM POOL");
        });

        // check for scorecount
        scoreBoderCube.GetComponent<ObservableTriggerTrigger>().OnTriggerEnterAsObservable().Subscribe(x => {
            if (x.GetComponent<Renderer>().material.color.r == scoreBoderCube.GetComponent<Renderer>().material.color.r) {
                isScoreable.Value = true;
            }
        });
        // disable scorecount
        scoreBoderCube.GetComponent<ObservableTriggerTrigger>().OnTriggerExitAsObservable().Subscribe(_ => {
            isScoreable.Value = false;
        });
        // change color for score border
        scoreBoderCube.AddComponent<ObservableRandomEventTrigger>();
        scoreBoderCube.GetComponent<ObservableRandomEventTrigger>().OnRandomEventAsObservable().Subscribe(_ => {
            scoreBoderCube.GetComponent<Renderer>().material = _materialsAlpha[UnityEngine.Random.Range(0, 2)];
        });

        // get button and increment score
        tapScore.OnClickAsObservable().Subscribe(_ => {
            if (isScoreable.Value) {
                score.Value++;
                isScoreable.Value = false;
            } else {
                score.Value--;
            }
        });

        // change score text according to text
        score.SubscribeToText(scoreText);
    }
}
