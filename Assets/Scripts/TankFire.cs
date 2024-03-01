using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private GameObject _gunTransform;
    [SerializeField] private GameObject _explosion;
    //[SerializeField] private GameObject _explosionTransform;

    public void LaunchMissile()
    {
        Instantiate(_missilePrefab, _gunTransform.transform.position, _gunTransform.transform.rotation);
        GameObject explosion = Instantiate(_explosion, _gunTransform.transform.position, Quaternion.identity);
        Destroy(explosion, 3);
    }
}
