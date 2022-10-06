using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformChooserController : MonoBehaviour
{
    [SerializeField] GameObject[] Plataforms;
    public Rigidbody PlataformRigidbody;

    public void Spawn(int index)
    {
        PlataformRigidbody = Instantiate
        (
            Plataforms[index],
            transform
        ).GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
