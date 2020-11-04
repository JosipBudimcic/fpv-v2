using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;



public class DroneMovement : MonoBehaviour
{
    Rigidbody DroneExample;
    public float upForce;
    public float upForceDefault;
    public Player Player;   
    
        void Awake()
    {
        DroneExample = GetComponent<Rigidbody>();
        Debug.Log("Awake");
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swerve();
        Debug.Log("Update");

        DroneExample.AddRelativeForce(Vector3.up * upForce);
        DroneExample.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));

    }

    void MovementUpDown()
    {
        
        if (Input.GetKey(KeyCode.I))
        {
            upForce = 200;

        }
        else if (Input.GetKey(KeyCode.K))
        {
            upForce = -200;
        }
        else if (Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
        {
            upForce = upForceDefault;
        }
    }

    public float movementForwardSpeed = 200.0f;
    public float tiltAmountForward = 0;
    public float tiltVelocityForward;

    void MovementForward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            DroneExample.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
        }
    }
    public float wantedYRotation;
    public float currentYRotation;
    public float rotateAmountByKeys = 2.5f;
    public float rotationYVelocity;

    void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmountByKeys;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    public Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            DroneExample.velocity = Vector3.ClampMagnitude(DroneExample.velocity, Mathf.Lerp(DroneExample.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            DroneExample.velocity = Vector3.ClampMagnitude(DroneExample.velocity, Mathf.Lerp(DroneExample.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f &&  Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            DroneExample.velocity = Vector3.ClampMagnitude(DroneExample.velocity, Mathf.Lerp(DroneExample.velocity.magnitude, 5.0f, Time.deltaTime * 5f));

        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            DroneExample.velocity = Vector3.SmoothDamp(DroneExample.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
        
    }

    public float sideMovementAmount;
    public float tiltAmountSideways;
    public float tiltAmountVelocity;
    public float inputAxis;
    void Swerve()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            DroneExample.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, inputAxis * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
    void Start()
    {
        Player.Load();
        Debug.Log("Player Load");
    }
}
