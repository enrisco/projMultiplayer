using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlataformChooserController : NetworkBehaviour
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
