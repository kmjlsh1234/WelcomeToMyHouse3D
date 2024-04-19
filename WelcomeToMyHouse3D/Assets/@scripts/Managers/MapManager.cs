using Assets.Scripts.Common;
using Assets.Scripts.Manager.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : SingletonBase<MapManager>
{
    private const string MAPPATH = "Map";
    public GameObject[] MapList;
    protected override void Awake()
    {
        base.Awake();
        MapList = Resources.LoadAll<GameObject>(MAPPATH);
    }

    private void Start()
    {
        //GenerateMap(PlayerViewModel.Instance.PlayerData.CurMapType);
    }

    public void GenerateMap(MapType type)
    {
        if(PlayerViewModel.Instance.CurrentMap != null)
        {
            Destroy(PlayerViewModel.Instance.CurrentMap);
        }

        GameObject target = MapList.FirstOrDefault(x => x.name.Contains(type.ToString()));
        if(target != null)
        {
            var map = Instantiate(target);
            map.name = target.name;
            map.transform.position = Vector3.zero;
            map.transform.rotation = Quaternion.identity;
            map.transform.localScale = Vector3.one;
            PlayerViewModel.Instance.CurrentMap = map;
        }
        PlayerViewModel.Instance.PlayerData.CurMapType = type;
    }

    
}
