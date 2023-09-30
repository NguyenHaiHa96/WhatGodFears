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
    None            
}

public enum GameState
{
    None,
    Gameplay
}

public enum GameMode
{
    None
}

public enum UIID
{
    None,
    Gameplay
}

public enum CardState
{
    None,
    Standby,
    InHand,
    InDiscard
}
