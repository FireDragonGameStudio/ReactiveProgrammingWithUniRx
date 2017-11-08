using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager_00 : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Button tapScore;

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(0);

    // Use this for initialization
    void Start() {

        // spawn cubes at regular time interval
        //var spawnStream = Observable.Interval(TimeSpan.FromMilliseconds(500));

        // spawn cubes at random time interval
        var spawnStream = gameObject.AddComponent<ObservableRandomEventTrigger>();
        spawnStream.OnRandomEventAsObservable().Subscribe(_ => {

            var newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.AddComponent<Rigidbody>();

            // when using prefabs, use instantiate
            //newCube = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

            // destroy cube, after reaching y = -5
            newCube.transform.ObserveEveryValueChanged(x => x).Subscribe(x => {
                if (x.position.y < -5f) {
                    Destroy(newCube);
                }
            });

            Debug.Log("SPAWNED NEW CUBE");
        });

        // get button and increment score
        tapScore.OnClickAsObservable().Subscribe(_ => {
            score.Value++;
        });

        // change score text according to text
        score.SubscribeToText(scoreText);        
    }
}
