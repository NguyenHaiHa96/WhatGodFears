using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enums 
{
    public static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static List<T> SortOrder<T>(List<T> list)
    {
        return list.OrderBy(d => System.Guid.NewGuid()).Take(list.Count).ToList();
    }
}

public enum BuildStatus
{

}

public enum GameState
{

}

public enum GameMode
{

}

public enum UIID
{
    Gameplay
}

public enum CardState
{
    Standby,
    InHand,
    InDiscard
}
