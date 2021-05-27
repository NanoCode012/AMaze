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

    public void PlayClip(string clipName, Vector3 position)
    {
        var clip = GetClip(clipName);
        if (clip) AudioSource.PlayClipAtPoint(clip, position);
    }

    private AudioClip GetClip(string name)
    {
        for (int i = 0; i < clips.Count; i++)
            if (clips[i].Name == name) return clips[i].clip;

        return null;
    }


}
