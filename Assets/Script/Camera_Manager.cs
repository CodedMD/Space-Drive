using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject[] _vCams;
    bool _canPlay = false;
    private int _currentCam;
    private float _playTime;
    // calculation variables



    // Start is called before the first frame update
    void Start()
    {

        _vCams[0].GetComponent<CinemachineVirtualCamera>().Priority = 15;

    }
  

    // Update is called once per frame
    void Update()
    {


        DirectorControls();

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


    private void DirectorControls()
    {

        _playTime += Time.deltaTime;

        if (Input.GetAxis("Mouse X") == 0f)
        {
            _canPlay = true;
        }
        else
        {
            _canPlay = false;
        }


        if ( _canPlay && _playTime >= 5.0f)
        {
            _director.Play();
        }
        else if( !_canPlay)
        {
            _director.Stop();
            _playTime = 0;  
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
