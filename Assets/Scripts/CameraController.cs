using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject gimbal;
    [SerializeField] float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate camera gimbal
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            gimbal.transform.Rotate(Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed, -Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0f);
        }

        // Clamp vertical rotation to prevent somersaulting
        gimbal.transform.rotation = Quaternion.Euler(Mathf.Clamp(Helpers.NormalizeAngle(gimbal.transform.rotation.eulerAngles.x), -5f, 55f), gimbal.transform.rotation.eulerAngles.y, 0f);
    }
}
