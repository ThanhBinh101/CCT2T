using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float distance = 0.2f;
    [SerializeField] public GameObject targetPortal;
    private GameObject _instantiatePortal;
    private void Start()
    {
        _instantiatePortal = Instantiate(targetPortal, new Vector2(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-8f, 8f)), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(_instantiatePortal.transform.position.x, _instantiatePortal.transform.position.y);
            _instantiatePortal?.SetActive(false);
            gameObject.SetActive(false);
        }
    }


}
