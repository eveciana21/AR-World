using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
   [SerializeField] private float _speed = 5;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        Destroy(this.gameObject, 5f);
    }
}
