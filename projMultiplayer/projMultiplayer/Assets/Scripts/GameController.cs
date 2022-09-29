using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] PlataformChooserController PlataformChooser;

    [Header("Players")]
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    [Header("Rectangular Player Positions")]
    [SerializeField] Transform rectP1;
    [SerializeField] Transform rectP2;

    [Header("Circular Player Positions")]
    [SerializeField] Transform circP1;
    [SerializeField] Transform circP2;

    [Header("Hexagonal Player Positions")]
    [SerializeField] Transform hexaP1;
    [SerializeField] Transform hexaP2;

    [Header("Triangular Player Positions")]
    [SerializeField] Transform triaP1;
    [SerializeField] Transform triaP2;
    PlataformTypes PlataformType;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void SpawnObjects()
    {
        int r = Random.Range(0, 4);

        switch (r)
        {
            case 0: 
                PlataformType = PlataformTypes.Rectangular;
                SpawnPlayers(rectP1, rectP2); break;
            case 1: 
                PlataformType = PlataformTypes.Circular;
                SpawnPlayers(circP1, circP2); break;
            case 2: 
                PlataformType = PlataformTypes.Hexagonal;
                SpawnPlayers(hexaP1, hexaP2); break;
            case 3: 
                PlataformType = PlataformTypes.Triangular;
                SpawnPlayers(triaP1, triaP2); break;
        }

        PlataformChooser.Spawn(r);
    }

    void SpawnPlayers(Transform player1Pos, Transform player2Pos)
    {
        Instantiate
        (
            Player1,
            player1Pos
        );

        Instantiate
        (
            Player2,
            player2Pos
        );
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
