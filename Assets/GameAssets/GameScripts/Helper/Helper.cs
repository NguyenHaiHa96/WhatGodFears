using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    private static readonly Dictionary<float, WaitForSeconds> WFSDict = new();
    private static readonly Dictionary<float, WaitForSecondsRealtime> WFSRDict = new();

    public static WaitForSeconds GetWaitForSeconds(float time)
    {
        if (WFSDict.TryGetValue(time, out var wait)) return wait;

        WFSDict[time] = new(time);
        return WFSDict[time];
    }

    public static WaitForSecondsRealtime GetWaitForSecondsRealtime(float time)
    {
        if (WFSRDict.TryGetValue(time, out var wait)) return wait;

        WFSRDict[time] = new(time);
        return WFSRDict[time];
    }

    public static WaitForEndOfFrame GetWaitForEndOfFrame() => new();

    public static bool GetPercentChance(float percent)
    {
        if (Random.Range(0, 1f) <= percent) return true;
        return false;
    }
}
