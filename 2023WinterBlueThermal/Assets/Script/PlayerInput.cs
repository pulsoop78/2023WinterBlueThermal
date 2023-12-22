using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _rotateYSpeed = 10f;
    private float _inputX;
    private float _inputZ;
    private float _mouseY;

    private Vector3 _moveDirection;
    private Player _player;
   
    protected void Init()
    {
        _player = GetComponent<Player>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _moveDirection = new Vector3(0, 0, 0);
        _mouseY = 0;
    }
    
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        SetMoveDirection();
        ClampAngleY();
    }

    private void FixedUpdate()
    {
        _player.MoveEntity(_moveDirection);
        _player.RotateY(_mouseY);
    }

    private void SetMoveDirection()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector3(_inputX, 0, _inputZ);
    }

    private void ClampAngleY()
    {
        _mouseY += Input.GetAxis("Mouse X") * _rotateYSpeed;
        if (_mouseY < 0) {  _mouseY += 360; }
        if (_mouseY > 360) { _mouseY -= 360; }
    }
}