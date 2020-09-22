using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    Animator _animator;
    RigidbodyFirstPersonController _rigidbodyFirstPersonController;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbodyFirstPersonController = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _rigidbodyFirstPersonController.GetInput();


        //Debug.Log("Horizontal: " + input.x);
        //Debug.Log("Vertical: " + input.y);

        _animator.SetFloat("Horizontal", input.x);
        _animator.SetFloat("Vertical", input.y);


        if (_rigidbodyFirstPersonController.Running)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
            _animator.SetBool("IsRunning", false);

    }
}
