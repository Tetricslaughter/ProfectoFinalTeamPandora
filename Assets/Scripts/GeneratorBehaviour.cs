using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow1;
    [SerializeField]
    private GameObject arrow2;
    [SerializeField]
    private int generatorType;
    private float randomTime = 0;
    void Start()
    {
        Invoke("ShootBullet", randomTime);
    }

    public void ShootBullet()
    {
        //Instantiate(bullet, transform.position, transform.rotation);
        switch (generatorType)
        {
            case 1:
                {
                    Instantiate(arrow1, transform.position, transform.rotation);
                    break;
                }
            case 2:
                {
                    Instantiate(arrow2, transform.position, transform.rotation);
                    break;
                }
        }
        randomTime = Random.Range(8, 10);
        Invoke("ShootBullet", randomTime);

    }
}
