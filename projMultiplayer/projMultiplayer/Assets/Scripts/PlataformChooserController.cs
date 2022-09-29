using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformChooserController : MonoBehaviour
{
    [SerializeField] GameObject[] Plataforms;

    public void Spawn(int index)
    {
        Instantiate
        (
            Plataforms[index],
            transform
        );
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
