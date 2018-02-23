using UnityEngine;
using System.Collections;

public class Gyroscope : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    
    // Use this for initialization
	void Start () {
        gyroEnabled = enableGyro();
	}
	
    private bool enableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;

    }
	// Update is called once per frame
	 Update () {

	}
}
