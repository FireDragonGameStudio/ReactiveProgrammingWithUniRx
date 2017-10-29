using UniRx;
using UnityEngine;

public class ColorCube : MonoBehaviour {

    [SerializeField]
    public ColorCubePool ColorCubePool;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Material[] _materials;

    void Start() {
        // not necessaty to get the components in start method. Referencing in inspector is also possible
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        // automatically destroy cube after reaching y <= -5f
        transform.ObserveEveryValueChanged(pos => pos.position).Subscribe(pos => {
            if (pos.y < -5f) {
                ColorCubePool.Return(this);
            }
        });
    }

    void OnEnable() {
        // reset position
        transform.position = new Vector3(Random.Range(-3f, 3f), 5, 0);

        // reset velocity of rigidbody
        _rigidbody.velocity = Vector3.zero;
        // get new random material
        _meshRenderer.material = _materials[Random.Range(0, 2)];
        // add little torque for rotation
        _rigidbody.AddTorque(Vector3.one);
    }
}
