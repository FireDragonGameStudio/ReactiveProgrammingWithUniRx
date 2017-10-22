using UniRx.Toolkit;
using UnityEngine;

public class ColorCubePool : ObjectPool<ColorCube> {

    readonly ColorCube _prefab;

    public ColorCubePool(ColorCube prefab) {
        this._prefab = prefab;
    }

    protected override ColorCube CreateInstance() {
        return GameObject.Instantiate<ColorCube>(_prefab, new Vector3(Random.Range(-3f, 3f), 5, 0), Quaternion.identity);
    }

    // You can overload OnBeforeRent, OnBeforeReturn, OnClear for customize action.
    // In default, OnBeforeRent = SetActive(true), OnBeforeReturn = SetActive(false)

    // protected override void OnBeforeRent(Foobar instance)
    // protected override void OnBeforeReturn(Foobar instance)
    // protected override void OnClear(Foobar instance)
}
