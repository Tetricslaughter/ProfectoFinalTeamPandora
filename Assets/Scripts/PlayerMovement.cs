using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 0.0f;
    public float RotationSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);

        float rotationY = (Input.GetAxis("Mouse X"));
        transform.Rotate(new Vector3(0, rotationY, 0) * Time.deltaTime * RotationSpeed);  
    }
}
