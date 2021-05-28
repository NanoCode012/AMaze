using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public List<GameObject> singlePlayer;
    public List<GameObject> multiplayer;

    public void SetMultiplayer()
    {
        foreach (GameObject obj in singlePlayer)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in multiplayer)
        {
            obj.SetActive(true);
        }
    }
}
