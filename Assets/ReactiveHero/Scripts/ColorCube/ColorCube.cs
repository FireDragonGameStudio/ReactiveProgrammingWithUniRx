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

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        // automatically destroy cube after reaching y <= -5f
        transform.ObserveEveryValueChanged(pos => pos.position).Subscribe(pos => {
            if (pos.y < -5f) {
                ColorCubePool.Return(this);
            }
        });
    }

    private void OnEnable() {
        transform.position = new Vector3(Random.Range(-3f, 3f), 5, 0);

        _rigidbody.velocity = Vector3.zero;
        _meshRenderer.material = _materials[Random.Range(0, 2)];
        _rigidbody.AddTorque(Vector3.one);
    }
}
