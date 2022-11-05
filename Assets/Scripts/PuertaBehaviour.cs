using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBehaviour : MonoBehaviour
{
    [SerializeField]
    private int numberDoor;
    private bool isOpen;
    private float speedMoveDoor;
    private float altura;
    //private float speedMoveDoor2;
    private float posY;

    public int NumberDoor { get => numberDoor; set => numberDoor = value; } //ahora lo podemos usar en el otro script

    void Start()
    {
        isOpen = false; //por defecto esta cerrado la puerta
        speedMoveDoor = 0.1f; //velocidad de la puarta sube
        posY = transform.position.y;
        altura = 4f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenClose()
    {
        if (isOpen != true)
        {
            switch (numberDoor)
            {
                case 1:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
                        //Debug.Log("instancio");
                        break;
                    }
                case 2:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
                        break;
                    }
                case 3:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
                        break;
                    }
                case 4:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
                        break;
                    }
            }
            /*while (transform.position.y > posY-3f)
            {
                transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
            }
            isOpen = true;*/
            /*Transform transformGate = transform.GetChild(4).transform; //obtengo el trasnform de la puerta
            while (transformGate.position.y < 2.5f)
            {
                transformGate.Translate(0, speedMoveGate * Time.deltaTime, 0);
            }
            isOpen = true;*/
        }
    }
}
