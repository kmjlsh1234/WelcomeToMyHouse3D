using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;
using Assets.Scripts.Manager.Base;
public class ResourceManager : SingletonBase<ResourceManager>
{
    public List<ItemData> ItemDataList = new List<ItemData>();

    protected override void Awake()
    {
        base.Awake();
        LoadItemData();
    }

    public void LoadItemData()
    {
        ItemDataList.Clear();

        ItemData[] itemDatas = Resources.LoadAll<ItemData>("Data/ItemData");

        foreach (ItemData itemData in itemDatas)
        {
            ItemDataList.Add(itemData);
        }
    }


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
