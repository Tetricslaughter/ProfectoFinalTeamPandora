using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed = 3f;
    private float speedRotate = 200f;
    private Animator animacion;
    private float x, y;
    private float jumpForce;
    private Rigidbody physicBody;
    private bool isJump = false;
    private bool floorDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jumpForce = 6f;
        physicBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        

    }
    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        float rotationY = (Input.GetAxis("Mouse X"));
        transform.Rotate(new Vector3(0, rotationY, 0) * Time.deltaTime * speedRotate);

        animacion.SetFloat("VelX", horizontal);
        animacion.SetFloat("VelY", vertical);
        isJump = Input.GetButtonDown("Jump");

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 1.03f))
        {
            floorDetected = true;
            // Debug.Log("esta en true");
        }
        else
        {
            floorDetected = false;
        }

        if (isJump && floorDetected)

        {
            physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            
        }
    }
}
