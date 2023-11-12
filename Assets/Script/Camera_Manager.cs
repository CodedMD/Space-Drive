using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams;
    private int _currentCam;


    // Start is called before the first frame update
    void Start()
    {
        _vCams[0].GetComponent<CinemachineVirtualCamera>().Priority = 15;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentCam++;
            if (_currentCam>= _vCams.Length)
            {
                _currentCam = 0;
            }
            SetLowCamPriorities();
            SetCurrentCamera();
        }
    }

    public void SetLowCamPriorities()
    {
        foreach (var c in _vCams)
        {
            if (c.GetComponent<CinemachineVirtualCamera>())
            {
                c.GetComponent<CinemachineVirtualCamera>().Priority = 10;

            }

            if (c.GetComponent<CinemachineBlendListCamera>())
            {
                c.GetComponent<CinemachineBlendListCamera>().Priority = 10;

            }


        }
    }

    public void SetCurrentCamera()
    {

        if (_vCams[_currentCam].GetComponent<CinemachineBlendListCamera>())
        {
            _vCams[_currentCam].GetComponent<CinemachineBlendListCamera>().Priority = 15;

        }

        if (_vCams[_currentCam].GetComponent<CinemachineVirtualCamera>())
        {
            _vCams[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 15;
        }


    }



}
