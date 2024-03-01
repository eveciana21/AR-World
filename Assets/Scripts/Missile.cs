using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
    //[SerializeField] private GameObject _explosion;

   /* private void Start()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
    }*/

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }
}
