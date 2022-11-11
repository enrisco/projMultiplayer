using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Netcode;

public class GameController : NetworkBehaviour
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

    [Header("Timer")]
    [SerializeField] GameObject TxtTimer;
    [SerializeField] int TimeInMinutes;
    double TotalInSeconds;
    TimeSpan Timer;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnObjects();
    }

    private void Start()
    {
        Timer = new TimeSpan(0, TimeInMinutes, 0);
        TotalInSeconds = Timer.TotalSeconds;
        InvokeRepeating("DecreaseTimer", 0f, 1f);
    }

    // Update is called once per frame
    void SpawnObjects()
    {
        if (!IsHost) return;

        int r = UnityEngine.Random.Range(0, 4);

        switch (r)
        {
            case 0: 
                PlataformType = PlataformTypes.Rectangular;
                //SpawnPlayers(rectP1, rectP2);
                break;
            case 1: 
                PlataformType = PlataformTypes.Circular;
                //SpawnPlayers(circP1, circP2);
                break;
            case 2: 
                PlataformType = PlataformTypes.Hexagonal;
                //SpawnPlayers(hexaP1, hexaP2);
                break;
            case 3: 
                PlataformType = PlataformTypes.Triangular;
                //SpawnPlayers(triaP1, triaP2);
                break;
        }

        PlataformChooser.Spawn(r);
    }

    /*void SpawnPlayers(Transform player1Pos, Transform player2Pos)
    {
        Instantiate
        (
            GameData.PlayerOneCharacter,
            player1Pos
        );

        Instantiate
        (
            GameData.PlayerTwoCharacter,
            player2Pos
        );
    }*/

    void DecreaseTimer()
    {
        if(Timer.TotalSeconds > 0)
        {
            Timer = Timer.Subtract(new TimeSpan(0, 0, 1));
            UIManager.SetText(TxtTimer, FormatTime(Timer));
            ChangePlataformMass();
        }
    }

    void ChangePlataformMass()
    {
        if (Timer.TotalSeconds == (TotalInSeconds * 75) / 100) PlataformChooser.PlataformRigidbody.mass = 7.5f;
        else if (Timer.TotalSeconds == (TotalInSeconds * 50) / 100) PlataformChooser.PlataformRigidbody.mass = 5f;
        else if (Timer.TotalSeconds == (TotalInSeconds * 25) / 100) PlataformChooser.PlataformRigidbody.mass = 1f;
    }

    string FormatTime(TimeSpan time)
    {
        return $"{time.Minutes}:{time.Seconds:00}";
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
