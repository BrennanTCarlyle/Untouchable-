using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    private float _degreesToShift = 90;
    private float _maxDegrees = 270;
    readonly float _speed = 350;
    readonly float _margin = 10;
    private Vector3 _destination;
    private bool _isSwitching;
    private bool _isMoving;
    private bool _isRight;

    void Update()
    {
        if (!_isSwitching)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetSwitching(true);
            }
            if (Input.GetMouseButtonDown(1))
            {
                SetSwitching(false);
            }
        }
    }

    public void SetSwitching(bool givenDirection)
    {
        _isSwitching = true;
        _isRight = givenDirection;
        if (_isRight)
        {
            if (transform.localEulerAngles.z < _maxDegrees)
            {
                _destination = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + _degreesToShift);
            }
            else
            {
                _destination = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
            }
        }
        else if (!_isRight)
        {
            if (transform.localEulerAngles.z <= _margin && transform.localEulerAngles.z >= 0)
            {
                _destination = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, _maxDegrees);
            }
            else
            {
                _destination = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - _degreesToShift);
            }
        }
        _isMoving = true;
    }

    private void FixedUpdate()
    {
        if (_isSwitching && _isMoving)
        {
            if (_isRight)
            {
                transform.Rotate (Vector3.forward * (_speed * Time.fixedDeltaTime));
            }
            else if (!_isRight)
            {
                transform.Rotate (Vector3.back * (_speed * Time.fixedDeltaTime));
            }

            if (transform.eulerAngles.z > _destination.z - _margin && transform.eulerAngles.z < _destination.z + _margin)
            {
                _isSwitching = false;
                _isMoving = false;
                transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, _destination.z);
            }
        }     
    }
}
