using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public int PlayerNumber;
    public string TextColor;

    [SerializeField] List<RectTransform> ArrowPositions;
    [SerializeField] int ActualPosition;
    [SerializeField] CharacterSelectController SelectCharacterController;

    KeyCode left, right, select;
    bool ready;

    RectTransform RectTransform;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        TextColor = UIManager.ReturnHexTextColor(gameObject);
        if (PlayerNumber == 1)
        {
            left = KeyCode.A;
            right = KeyCode.D;
            select = KeyCode.J;
        }
        else
        {
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            select = KeyCode.Alpha3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(left) || Input.GetKeyDown(right)) && !ready)
        {
            if (Input.GetKeyDown(left)) ActualPosition--;
            else if (Input.GetKeyDown(right)) ActualPosition++;

            if (ActualPosition == -1) ActualPosition = 3;
            else if (ActualPosition == 4) ActualPosition = 0;

            RectTransform.position = new Vector3
            (
                ArrowPositions[ActualPosition].position.x, 
                RectTransform.position.y, 
                RectTransform.position.z
            );
        }

        if(Input.GetKeyDown(select))
        {
            ready = !ready;
            if (ready) SelectCharacterController.SetPlayerReady(this, PlayerNumber, ActualPosition);
            else SelectCharacterController.RemovePlayer(this, PlayerNumber);
        }
    }
}
