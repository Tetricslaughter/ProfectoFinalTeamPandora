using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePremio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100f * Time.deltaTime); //solamente para que rote el premio
    }
}
