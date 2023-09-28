using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class holds the data across scenes.
/// </summary>
public static class GameData
{
    public static bool menu;
    public static bool open;
    public static int[,] resources;
    public static int[,] satisfaction;
    public static Dictionary<string, int> unlocks;

    //Constructor for default values
    static GameData()
    {
        open = true;
        menu = true;
        resources = new int[,] { { 1, 5 }, { 1, 5 }, { 1, 5 } };
        unlocks = new Dictionary<string, int>();
        unlocks.Add("B_table", 0);
        unlocks.Add("SW_table", -1);
        unlocks.Add("Farm_Plot", -1);
    }

    /// <summary>
    /// Resets values to base.
    /// </summary>
    public static void ResetData()
    {
        //TODO: Save file
        resources = new int[,] { { 1, 0 }, { 1, 0 }, { 0, 0 } };
    }

}
