using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gyroscopeClass : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyroSensor;

    private Quaternion initialRotation;
    private Quaternion gyroInitialRotation;

    private GameObject cameraContrainer;
    private Quaternion rot;

    // Use this for initialization
	void Start () {
        cameraContrainer = new GameObject("Camera Container");
        cameraContrainer.transform.position = transform.position;
        transform.SetParent(cameraContrainer.transform);

        gyroEnabled = enableGyro();
	}
	
    private bool enableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroSensor = Input.gyro;
            gyroSensor.enabled = true;

            initialRotation = transform.rotation;
            gyroInitialRotation = Input.gyro.attitude;

            cameraContrainer.transform.rotation = Quaternion.Euler(90f, -90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false; 
    }

	// Update is called once per frame
	void Update () {

        if (gyroEnabled)
        {
            transform.rotation = Quaternion.Inverse(gyroSensor.attitude) * rot;

        }

	}

}
