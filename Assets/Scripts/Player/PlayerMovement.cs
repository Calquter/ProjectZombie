using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Vector2 _inputs;
    [SerializeField] private float _playerSpeed;

    [SerializeField] private Camera _camera;
    
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        GetInputs();
        Movement();
    }


    private void GetInputs()
    {
        _inputs.x = Input.GetAxisRaw("Horizontal");
        _inputs.y = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        Vector3 moveVelocity = (_camera.transform.right * _inputs.x + _camera.transform.forward * _inputs.y).normalized;
        

        if (moveVelocity.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(_inputs.x, _inputs.y) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, 5);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        _rigidBody.velocity = moveVelocity * _playerSpeed;
    }

}
