using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Teams team;

    //Перечисление играющих команд
    public enum Teams
    {
        Circle,
        Cross
    }
}
