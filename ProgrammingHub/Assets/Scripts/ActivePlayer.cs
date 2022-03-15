using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayer : MonoBehaviour
{
    public Image firstPlayer;
    public Image secondPlayer;

    private void Start()
    {
        firstPlayer.sprite =
            MainManager.Instance.teamsToCharacters[Player.Teams.Circle].photo;
        secondPlayer.sprite =
            MainManager.Instance.teamsToCharacters[Player.Teams.Cross].photo;

    }
}
