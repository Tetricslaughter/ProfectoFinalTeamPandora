using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    [SerializeField]
    private float speedZ;
    [SerializeField]
    private int plataformType;
    [SerializeField]
    private float negativeSpeedZ;
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float negativeSpeedX;
    private float posX;
    private float posZ;
    void Start()
    {
        posZ = transform.position.z;
        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlataformas();
    }

    public void MovePlataformas()
    {
        switch (plataformType)
        {
            case 1:
                {
                    if (transform.position.z > posZ + 0.25f || transform.position.z < posZ - 7f)
                    {
                        negativeSpeedZ *= -1;
                    }
                    transform.Translate(0, 0, negativeSpeedZ * Time.deltaTime);

                    break;
                }
            case 2:
                {
                    if (transform.position.z < posZ - 0.25f || transform.position.z > posZ + 8f)
                    {
                        speedZ *= -1;
                    }
                    transform.Translate(0, 0, speedZ * Time.deltaTime);
                    break;
                }
            case 3:
                {
                    if (transform.position.x < posX - 0.25f || transform.position.x > posX + 25f)
                    {
                        speedX *= -1;
                    }
                    transform.Translate(speedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 4:
                {
                    if (transform.position.x < posX - 0.25f || transform.position.x > posX + 8f)
                    {
                        speedX *= -1;
                    }
                    transform.Translate(speedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 5:
                {
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 8f)
                    {
                        negativeSpeedX *= -1;
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 6:
                {
                    if (transform.position.z > posZ + 0.25f || transform.position.z < posZ - 24f)
                    {
                        negativeSpeedZ *= -1;
                    }
                    transform.Translate(0, 0, negativeSpeedZ * Time.deltaTime);
                    break;
                }
            case 7:
                {
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 20f)
                    {
                        negativeSpeedX *= -1;
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 8:
                {
                    if (transform.position.z > posZ + 0.25f || transform.position.z < posZ - 15f)
                    {
                        negativeSpeedZ *= -1;
                    }
                    transform.Translate(0, 0, negativeSpeedZ * Time.deltaTime);
                    break;
                }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
