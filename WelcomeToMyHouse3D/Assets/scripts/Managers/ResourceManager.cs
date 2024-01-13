using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;
using Assets.Scripts.Manager.Base;
public class ResourceManager : SingletonBase<ResourceManager>
{
    public Sprite LoadSprite(string fileName)
    {
        string dataPath = "Textures/Images/" + fileName;
        Sprite sprite = Resources.Load<Sprite>(dataPath);

        if (sprite != null)
        {
            return sprite;
        }
        else
        {
            Debug.LogWarning("No File Found! : " + dataPath);
            return null;
        }
    }
    public VideoClip LoadVideoClip(string fileName)
    {
        string dataPath = "Video/" + fileName;
        VideoClip vClip = Resources.Load<VideoClip>(dataPath);

        if (vClip != null)
        {
            return vClip;
        }
        else
        {
            Debug.LogWarning("No File Found!" + dataPath);
            return null;
        }
    }
    public AudioClip[] LoadAudioLibrary()
    {
        string dataPath = "Sound/";
        AudioClip[] aClips = Resources.LoadAll<AudioClip>(dataPath);

        if (aClips != null)
        {
            return aClips;
        }
        else
        {
            Debug.LogWarning("No File Found!" + dataPath);
            return null;
        }
    }
}
