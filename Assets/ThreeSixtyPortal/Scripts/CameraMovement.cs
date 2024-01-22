using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Move the camera forward, backward, left, and right
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);

    }
}
