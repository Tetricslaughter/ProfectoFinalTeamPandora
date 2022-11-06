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
    private float posY;

    public int NumberDoor { get => numberDoor; set => numberDoor = value; } //ahora lo podemos usar en el otro script

    void Start()
    {
        isOpen = false; //por defecto esta cerrado la puerta
        speedMoveDoor = 0.1f; //velocidad con la que la puarta sube
        posY = transform.position.y;//guarda la posicion en y de la puerta
        altura = 4f; //altura a la que se eleva la puerta
    }

    // Update is called once per frame
    void Update()
    {

    }

    //abre una puerta
    public void OpenClose()
    {
        if (isOpen != true)//si la puerta no esta abierta
        {
            switch (numberDoor)     //eleva la puerta correspondiente a su valor en numberDoor
            {
                case 1:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
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
                case 6:
                    {
                        while (transform.position.y < posY + altura)
                        {
                            transform.Translate(0, speedMoveDoor * Time.deltaTime, 0);
                        }
                        isOpen = true;
                        break;
                    }
            }
        }
    }
}
