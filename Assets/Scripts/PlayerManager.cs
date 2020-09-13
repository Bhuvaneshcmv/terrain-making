using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float frontValue;
    private float sideValue;
    private int moveSpeed;

    private CharacterController controller;
    
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    private float ySpeed = 10;
    void Start()
    {
        moveSpeed = 10;
        controller = this.gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        LookAround();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
 
    void GetInput()
    {
        frontValue = Input.GetAxis("Vertical");
        sideValue = Input.GetAxis("Horizontal");
    }

    void MovePlayer()
    {
        if (!controller.isGrounded)
        {
            ySpeed = -100;
            Debug.Log("Grounded");
        }
        else ySpeed = 0;
        controller.Move(this.transform.TransformDirection(new Vector3(sideValue,ySpeed, frontValue )* moveSpeed * Time.deltaTime));
    }
    void LookAround()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
