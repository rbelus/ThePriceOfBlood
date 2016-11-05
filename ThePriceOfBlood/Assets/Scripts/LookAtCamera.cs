using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

    private Camera mCam;

    void Start()
    {
        mCam = Camera.main;
        //transform.rotation = mCam.transform.rotation;
        //transform.rotation *= Quaternion.Euler(-40, 0, 0);
    }

    void Update()
    {

    }
}
