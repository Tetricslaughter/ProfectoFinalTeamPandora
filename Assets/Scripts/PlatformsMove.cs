using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    [SerializeField]
    private int plataformType;
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float negativeSpeedX;
    private float posX;
    void Start()
    {
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
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 20f)
                    {
                        negativeSpeedX *= -1;
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 2:
                {
                    if (transform.position.x < posX - 0.25f || transform.position.x > posX + 20f)
                    {
                        speedX *= -1;
                    }
                    transform.Translate(speedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 3:
                {
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 20f)
                    {
                        negativeSpeedX *= -1;
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0);
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
