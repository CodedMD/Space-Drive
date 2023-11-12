using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Shake : MonoBehaviour
{
    private CinemachineImpulseSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _source.GenerateImpulse();

    }
}
