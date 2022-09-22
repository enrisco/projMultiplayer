using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{   
    public enum DeBuffType
    {
        Lentidao,
        AumentoDePeso,
        DiminuicaoDePulo,
        LimitarCampoVisao,
        InverterControles,
        Banana,
        BloquearAtaque
    };
    public DeBuffType tipoDeBuff;

    Rigidbody rigbd;
    public float tempo;
    public float tempoLimite;
    public static float velocidadeDeBuff = 1f;
    public static float forcaPuloDeBuff = 1f;
    public GameObject telaSuja;
    public static bool ataqueBloqueado;

    void Start()
    {
        tempo = -1f;
        telaSuja.SetActive(false);
        ataqueBloqueado = false;
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
            ataqueBloqueado = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            if (tipoDeBuff == DeBuffType.AumentoDePeso)
            {
                tempo = 0f;
                forcaPuloDeBuff = 2f;
            }

            if (tipoDeBuff == DeBuffType.Lentidao) 
            {
                tempo = 0f;
                velocidadeDeBuff = 0.5f;
            }

            if (tipoDeBuff == DeBuffType.DiminuicaoDePulo)
            {
                tempo = 0f;
                forcaPuloDeBuff = 0.5f;
            }

            if (tipoDeBuff == DeBuffType.LimitarCampoVisao)
            {
                tempo = 0f;
                telaSuja.SetActive(true);
            }

            if (tipoDeBuff == DeBuffType.InverterControles)
            {
                tempo = 0f;
                velocidadeDeBuff = -0.5f;
            }

            if (tipoDeBuff == DeBuffType.Banana)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.transform.position.z + 6);
            }

            if (tipoDeBuff == DeBuffType.BloquearAtaque) 
            {
                tempo = 0f;
                ataqueBloqueado = true;
            }
        }
    }
}
