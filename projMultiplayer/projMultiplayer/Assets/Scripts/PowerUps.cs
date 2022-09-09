using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Rigidbody rigbd;
    public float tempo;
    public float tempoLimite;
    public static float velocidadeDeBuff = 1f;
    public static float forcaPuloDeBuff = 1f;
    public GameObject telaSuja;
    void Start()
    {
        tempo = -1f;
        telaSuja.SetActive(false);
    }

    void Update()
    {
        if (tempo >= 0f && tempo <= tempoLimite) tempo += Time.deltaTime;
        if (tempo >= tempoLimite)
        {
            //PlayerController.rigbd.mass = 1f;
            velocidadeDeBuff = 1f;
            forcaPuloDeBuff = 1f;
            telaSuja.SetActive(false);
            tempo = -1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            if (gameObject.tag == "AumentoDePeso")
            {
                tempo = 0f;
                //PlayerController.rigbd.mass = 2f;
                forcaPuloDeBuff = 2f;
            }

            if (gameObject.tag == "Lentidao") 
            {
                tempo = 0f;
                velocidadeDeBuff = 0.5f;
            }

            if (gameObject.tag == "DiminuicaoPulo")
            {
                tempo = 0f;
                forcaPuloDeBuff = 0.5f;
            }

            if (gameObject.tag == "LimCampoVisao")
            {
                tempo = 0f;
                telaSuja.SetActive(true);
            }

            if (gameObject.tag == "InverterControles")
            {
                tempo = 0f;
                velocidadeDeBuff = -0.5f;
            }

            if (gameObject.tag == "Banana")
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.transform.position.z + 6);
            }
        }
    }
}
