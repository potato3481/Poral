using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControtl : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private Rigidbody myRigid;
    [SerializeField]
    public float RunSpeed;
    public float AprSpeed;
    private bool isRun = false;
    
    
    public float lookSeneitivity;

    public float cameraRotatLimit;
    private float currnentCamraRotationX = 0;


    [SerializeField]
    private Camera theCamera;

    private Rigidbody MyRigid;
    
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        theCamera = FindObjectOfType<Camera>();

        
    }
    void Update()
    {
        Running();
        RunCancel();
        TryRun();
        Move();
        CameraRotation();
        CharacacterRotation();
        
    }

    
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirY = Input.GetAxisRaw("Vertical");

        Vector3 _MoveHorizontal = transform.right * _moveDirX;
        Vector3 _MoveVertical = transform.forward * _moveDirY;

        Vector3 _velocity = (_MoveHorizontal + _MoveVertical).normalized * AprSpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

    }
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunCancel();
        }
    }
    private void Running()
    {
        isRun = true;
        AprSpeed = RunSpeed;
    }
    private void RunCancel()
    {
        isRun = false;
        AprSpeed = walkSpeed;
    }
    //좌우 케릭터 회전 
    private void CharacacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characacterRotationY = new Vector3(0f, _yRotation, 0f) * lookSeneitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characacterRotationY));
    }
    //상화 카메라 회전 
    private void CameraRotation()
    {
        float _xRotaion = Input.GetAxisRaw("Mouse Y");
        float _cameraRotaionX = _xRotaion * lookSeneitivity;
        currnentCamraRotationX += _cameraRotaionX;
        currnentCamraRotationX = Mathf.Clamp(currnentCamraRotationX, -cameraRotatLimit, cameraRotatLimit);

        theCamera.transform.localEulerAngles = new Vector3(currnentCamraRotationX, 0f, 0f);
    }
}
