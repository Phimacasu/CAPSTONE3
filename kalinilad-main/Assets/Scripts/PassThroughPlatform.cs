using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlatform : MonoBehaviour
{
    private Collider _collider;
    private bool _playerOnPlatform;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (_playerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            _collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision other, bool value)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _playerOnPlatform = value;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        SetPlayerOnPlatform(other, value:true);
    }

    private void OnCollisionExit(Collision other)
    {
        SetPlayerOnPlatform(other, value:true);
    }
}
