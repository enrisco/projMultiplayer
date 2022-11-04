using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField] GameObject PlayerReadyText;
    [SerializeField] GameObject[] PlayableCharacters;
    public int PlayerCount;
    List<ArrowController> PlayersReady = new List<ArrowController>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCount == PlayersReady.Count) SceneManager.GoToScene("sceGame");
    }

    public void SetPlayerReady(ArrowController player, int playerID, int characterChoosed)
    {
        PlayersReady.Add(player);
        if (playerID == 1) GameData.PlayerOneCharacter = PlayableCharacters[characterChoosed];
        else if (playerID == 2) GameData.PlayerTwoCharacter = PlayableCharacters[characterChoosed];
        WritePlayer();
    }

    public void RemovePlayer(ArrowController player, int playerID)
    {
        PlayersReady.Remove(player);
        if (playerID == 1) GameData.PlayerOneCharacter = null;
        else if (playerID == 2) GameData.PlayerTwoCharacter = null;
        WritePlayer();
    }

    public void WritePlayer()
    {
        UIManager.SetText(PlayerReadyText, "");
        foreach(var p in PlayersReady)
        {
            UIManager.AddText(PlayerReadyText, $"<color=#{p.TextColor}> P{p.PlayerNumber};</color>");
        }
    }
}
