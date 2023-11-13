using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;
    [SerializeField] private GameObject _thrusters;
    [SerializeField] private float _turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
        if (_currentSpeed >= 2)
        {
            _thrusters.SetActive(true);
        }
        if (_currentSpeed <=1)
        {
            _thrusters.SetActive(false);
        }
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > 4)
            {
                _currentSpeed = 4;
            }
            



        }//increase speed


        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }//decrease speed

        
        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed*.2f * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeed*.2f * Time.deltaTime);

        transform.Rotate(new Vector3(0, _horizontal*.2f, -_horizontal * 0.1f), Space.Self);
        transform.Rotate(new Vector3(_vertical*0.1f, 0, 0), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;


    }
}
