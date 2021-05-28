using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;
    public PlayerController.PlayerType playerType = PlayerController.PlayerType.P1;

    void Awake()
    {
        if (playerManager) { Destroy(this.gameObject); }
        else
        {
            playerManager = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "SampleScene")
        {
            if (playerType == PlayerController.PlayerType.P2)
            {
                var multiplayer = FindObjectOfType<MultiplayerController>();
                multiplayer.SetMultiplayer();
            }

            // playerManager = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }

    public void SetMultiplayer(bool multiplayer)
    {
        playerType = (multiplayer)
                                ? PlayerController.PlayerType.P2
                                : PlayerController.PlayerType.P1;
    }

}
