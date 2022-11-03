using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField]
    private int ArrowType;
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        switch (ArrowType)
        {
            case 1:
                {
                    transform.Translate(0, speed * Time.deltaTime, 0);
                    break;
                }
                case 2:
                    {
                        transform.Translate(0, speed * Time.deltaTime, 0);
                        break;
                    }
        }
        DestroyArrow();
    }

    public void DestroyArrow()
    {
        if (transform.position.z > 135f)
        {
            Destroy(gameObject);
        }
        if (ArrowType == 2 && transform.position.x < 50)
        {
            Destroy(gameObject);
        }
    }

}
