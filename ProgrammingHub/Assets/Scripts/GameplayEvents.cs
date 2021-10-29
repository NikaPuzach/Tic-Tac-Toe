using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayEvents 
{
    //Check - which cell and what team
    public static Action<Cell, Player.Teams> onCellChecked = (cell, team) => { };

    
}
