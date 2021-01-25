using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 20f;// _ podkreslenie prywatne, tylko w tym skrypcie
    Rigidbody _rigidbody; // dodanie rigidbody do kuli
    Vector3 _velocity; // movement speed kuli wraz z kierunkiem, rzeczywista predkosc
    // Start is called before the first frame update
    void Start()
    {
        // dodalismy sztywne cialo do kuli i chcemy chwycić OŚ, do ktorej nie bedziemy miec dostepu
        _rigidbody = GetComponent<Rigidbody>();
        // kula w dol * zmienna predkosc
        _rigidbody.velocity = Vector3.down * _speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;
    }
    // predefiniowana metoda wywola kolizje
    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}