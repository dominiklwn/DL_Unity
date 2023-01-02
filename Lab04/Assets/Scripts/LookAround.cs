using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0.01f;
    bool lockX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        player.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(new Vector3(-mouseY, 0f, 0f), Space.Self);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
