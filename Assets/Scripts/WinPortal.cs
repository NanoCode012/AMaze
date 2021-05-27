using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
    private ChangeSceneWithButton sceneController;
    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<ChangeSceneWithButton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            sceneController.LoadScene("Win");
        }
    }
}
