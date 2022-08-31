using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    Animator animator;
    int isWalkingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
    }

    void FixedUpdate()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            animator.SetBool(isWalkingHash, true);  //Animasyonu aktif ediyor.
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);  //Bakýþ açýsýný ayarlýyor.
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
