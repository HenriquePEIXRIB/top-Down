using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    
    [SerializeField] Transform _root;
    [SerializeField] float _speed;
    [SerializeField] int _roll;
    [SerializeField] Animator _PlayerAnimator;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _sprintInput;
    [SerializeField] InputActionReference _rollInput;

    

    Vector2 _playerMovement;
    private void Start()
    {
        //Move 
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += EndMove;

        //Sprint
        //_sprintInput.action.started += Sprint;
        //Roll
        //_rollInput.action.started += Roll;
    }
   


    // Update is called once per frame
    void Update()
    {



        //Movement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
        _root.transform.Translate(direction * Time.deltaTime * _speed, Space.World);

       

        //Animator
        if (direction.x > 0) // Si on bouge
        {
            _PlayerAnimator.SetBool("IsWalking", true);

        }
        else  //Sinon c'est que l'on ne bouge pas donc false
        {
            _PlayerAnimator.SetBool("IsWalking", false); 
        }
    }
    void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log($"Appelé ! {_playerMovement}");
    }

    void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log($"Joystick Update ! {_playerMovement}");
    }

    void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log("Joystick annulé !");
    }
}
