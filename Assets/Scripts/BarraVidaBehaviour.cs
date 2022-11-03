using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaBehaviour : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imgBarraVida;
    // Start is called before the first frame update
    void Start()
    {
        //vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarBarra();
        /*if (vidaActual <= 0)
        {

        }*/
    }

    public void ActualizarBarra()
    {
        imgBarraVida.fillAmount = vidaActual / vidaMax;
    }
}
