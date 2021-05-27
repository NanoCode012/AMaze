using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class DictionaryAudioClips : SerializableDictionary<string, AudioClip> { }

[System.Serializable]
public struct Clips
{
    public string Name;
    public AudioClip clip;
}

public class AudioController : MonoBehaviour
{

    public List<Clips> clips;

    public void PlayClip(string clipName)
    {
        var clip = GetClip(clipName);
        if (clip)
        {
            print("playing audio");
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
        else
        {
            Debug.LogWarning("Audio clip not found : " + clipName);
        }
    }

    private AudioClip GetClip(string name)
    {
        for (int i = 0; i < clips.Count; i++)
            if (clips[i].Name == name) return clips[i].clip;

        return null;
    }


}
