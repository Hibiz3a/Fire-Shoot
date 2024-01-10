using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string playerIdPrefix = "Player";

    private static Dictionary<string, Pl_Player> players = new Dictionary<string, Pl_Player>();

    public Mg_MatchSettings matchSettings;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }

        Debug.LogError("Plusieurs instance de GameManager");
    }

    public static void RegisterPlayer(string netID, Pl_Player player)
    {
        string playerId = playerIdPrefix + netID;
        players.Add(playerId, player);
        player.transform.name = playerId;
    }

    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }

    public static Pl_Player GetPLayer(string playerId)
    {
        return players[playerId];
    }

    //private void OnGUI()
    //{
    //    GUILayout.BeginArea(new Rect(500, 50, 200, 500));
    //    GUILayout.BeginVertical();

    //    foreach(string playerId in players.Keys)
    //    {
    //        GUILayout.Label(playerId + " - " + players[playerId].transform.name);
    //    }

    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}
}
