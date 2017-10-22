using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager_01 : MonoBehaviour {

    [SerializeField]
    private GameObject destroyBoderCube;

    [SerializeField]
    private ColorCube colorCubePrefab;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Button tapScore;

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(0);

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

        // get button and increment score
        tapScore.OnClickAsObservable().Subscribe(_ => {
            score.Value++;
        });

        // change score text according to text
        score.SubscribeToText(scoreText);

        // destroy cubes
        destroyBoderCube.GetComponent<ObservableTriggerTrigger>().OnTriggerEnterAsObservable().Subscribe(x => {
            _cubePool.Return(x.GetComponent<ColorCube>());
            Debug.Log("DESTROYED " + x.gameObject.name);
        });
    }
}
