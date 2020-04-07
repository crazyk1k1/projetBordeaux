using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float smoothPlayer = 12;
    public float smoothCamH;
    public float smoothCamV;
    public float maxYcam;

    public Transform playerBody;
    public Transform aimCamPoint;
    public Transform pivotCamPoint;
    public Transform followCamPoint;
    private Vector3 followCamStartPos;

    float xRotation = 0f;

    public bool lockerCam = true;
    public bool playerFollowMouse = true;

    // Start is called before the first frame update
    void Start()
    {
        followCamStartPos = followCamPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(lockerCam)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
       else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


       if(lockerCam)
        {
            float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            
            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            
            //Vector3 rot = new Vector3(MouseX, MouseY, 0f);
           // transform.rotation = new Quaternion (rot.x, rot.y, rot.z, transform.rotation.w);
           if(playerFollowMouse)
            {
                playerBody.Rotate(Vector3.up * MouseX * smoothPlayer);
            }
           



            if (followCamPoint.localPosition.y <= maxYcam && followCamPoint.localPosition.y >= -maxYcam)
            {
                followCamPoint.localPosition = new Vector3(followCamPoint.localPosition.x, followCamPoint.localPosition.y + MouseY * smoothCamV * Time.deltaTime, followCamPoint.localPosition.z);
            }
                

            if (followCamPoint.localPosition.y > maxYcam)
            {
                followCamPoint.localPosition = new Vector3(followCamPoint.localPosition.x, followCamPoint.localPosition.y - 0.05f, followCamPoint.localPosition.z);
            }
           if (followCamPoint.localPosition.y < -maxYcam)
            {
                followCamPoint.localPosition = new Vector3(followCamPoint.localPosition.x, followCamPoint.localPosition.y + 0.05f, followCamPoint.localPosition.z);
            }

            //Debug.Log(followCamPoint.localPosition.y);

            aimCamPoint.localRotation = playerBody.rotation;
            aimCamPoint.localPosition = Vector3.MoveTowards(aimCamPoint.localPosition, pivotCamPoint.localPosition, smoothCamH * Time.deltaTime);
        }
       
    }
}
