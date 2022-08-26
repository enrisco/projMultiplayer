using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movX;
    public float movZ;
    public float velocidade;
    public float forca_Pulo;
    public bool podePular;

    Vector3 move;

    Rigidbody rigbd;
    void Start()
    {
        rigbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1")
        {
            movX = Input.GetAxis("Horizontal1");
            movZ = Input.GetAxis("Vertical1");

            if (Input.GetKeyDown(KeyCode.Space) && podePular)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo, ForceMode.Impulse);
            }
        }

        if (gameObject.tag == "Player2")
        {
            movX = Input.GetAxis("Horizontal2");
            movZ = Input.GetAxis("Vertical2");

            if (Input.GetKeyDown(KeyCode.End) && podePular)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        move = new Vector3(movX * velocidade, 0, movZ * velocidade);

        rigbd.velocity = move * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            podePular = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            podePular = false;
        }
    }
}
