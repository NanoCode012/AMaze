using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public static VolumeController volumeController;

    private AudioSource audioSource;

    [SerializeField] private float volume = 0.5f;

    private void Awake()
    {
        if (volumeController) { Destroy(this.gameObject); }
        else
        {
            volumeController = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);

            FindAudioSource();
            SetVolume(volume);
        }
    }

    private void Update()
    {
        SetVolume(volume);
    }

    public void SetVolume(float vol)
    {
        audioSource.volume = vol;
        volume = vol;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        FindAudioSource();
        SetVolume(volume);
    }

    private void FindAudioSource()
    {
        // Check if in-game scene or in menu scene
        // ugly code but works because at most only 4 calls per scene
        if (FindObjectOfType<ItemController>())
        {
            audioSource = FindObjectOfType<ItemController>().GetComponent<AudioSource>();
        }
        else if (FindObjectOfType<MusicScenes>())
        {
            audioSource = FindObjectOfType<MusicScenes>().GetComponent<AudioSource>();
        }
    }
}
