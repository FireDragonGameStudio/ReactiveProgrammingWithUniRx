using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour {

    [SerializeField]
    private GameObject scoreCube;
    [SerializeField]
    private ColorCube colorCubePrefab;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Button scoreButton;

    [SerializeField]
    private IntReactiveProperty score = new IntReactiveProperty(0);
    [SerializeField]
    private BoolReactiveProperty isScoreable = new BoolReactiveProperty(false);

    [SerializeField]
    private Material[] _materialsAlpha;

    private ColorCubePool _cubePool = null;

    private void Start() {
        _cubePool = new ColorCubePool(colorCubePrefab);

        ObservableRandomEventTrigger spawnStream = gameObject.AddComponent<ObservableRandomEventTrigger>();
        spawnStream.OnRandomEventAsObservable().Subscribe(_ => {
            var colorCube = _cubePool.Rent();
            colorCube.ColorCubePool = _cubePool;

            // Debug.Log("SPAWNED NEW CUBE FROM POOL");
        });

        ObservableTriggerTrigger scoreCubeCountTrigger = scoreCube.AddComponent<ObservableTriggerTrigger>();
        scoreCubeCountTrigger.OnTriggerEnterAsObservable().Subscribe(x => {
            if (x.GetComponent<Renderer>().material.color.r == scoreCube.GetComponent<Renderer>().material.color.r) {
                isScoreable.Value = true;
            }
        });
        scoreCubeCountTrigger.OnTriggerExitAsObservable().Subscribe(_ => {
            isScoreable.Value = false;
        });

        ObservableRandomEventTrigger scorCubeRandomColorTrigger = scoreCube.AddComponent<ObservableRandomEventTrigger>();
        scorCubeRandomColorTrigger.OnRandomEventAsObservable().Subscribe(_ => {
            scoreCube.GetComponent<Renderer>().material = _materialsAlpha[UnityEngine.Random.Range(0, 2)];
        });

        scoreButton.OnClickAsObservable().Subscribe(_ => {
            if (isScoreable.Value) {
                score.Value++;
                isScoreable.Value = false;
            } else {
                score.Value--;
            }
        });

        score.SubscribeToText(scoreText);
    }
}
