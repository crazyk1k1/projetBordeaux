using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerV2 : MonoBehaviour
{
    private Rigidbody rb;
    private Collider cd;
    private Animator anim;
    public GameObject visuel;

    public KeyCode avancer;
    public KeyCode reculer;
    public KeyCode droite;
    public KeyCode gauche;
    public KeyCode run;
    public KeyCode jump;

    private float speedBaseRef;
    public float speed;
    public float runSpeed;
    public float smoothSpeed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        //anim = GetComponent<Animator>();

        speedBaseRef = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(avancer) )
        {
            //Vector3 V = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
          
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(reculer))
        {
            //Vector3 V = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

            rb.MovePosition(transform.position + transform.forward * -speed * Time.deltaTime);

        }
        if (Input.GetKey(droite))
        {
            //Vector3 V = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
            /*
            Quaternion rotate = Quaternion.Euler(new Vector3(rb.rotation.x, rb.rotation.y + 90f, rb.rotation.z) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);*/
            /*
            Vector3 rotate = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 360f, transform.localEulerAngles.z);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, rotate, smoothSpeed * Time.deltaTime);*/

            transform.Rotate(Vector3.up * smoothSpeed);

        }
        if (Input.GetKey(gauche))
        {
            //Vector3 V = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

            rb.MovePosition(transform.position + transform.right * -speed * Time.deltaTime);

        }
        /*
        if (Input.GetKeyDown(jump))
        {
            //Vector3 V = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

            rb.MovePosition(transform.position + transform.up * jumpForce * Time.deltaTime);
            
        }*/

        if (Input.GetKey(run))
        {
            speed *= runSpeed;
        }
        else
        {
            speed = speedBaseRef;
        }
    }
}
