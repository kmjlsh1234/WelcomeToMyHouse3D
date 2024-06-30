using Assets.Scripts.Common;
using Assets.Scripts.Manager.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class MapManager : SingletonBase<MapManager>
    {
        private const string MAPPATH = "Pref/Map";
        public GameObject[] MapPrefabs;
        public List<GameObject> GenerateMapList = new List<GameObject>();
        protected override void Awake()
        {
            base.Awake();
            MapPrefabs = Resources.LoadAll<GameObject>(MAPPATH);
        }

        public void GenerateMap(MapType type)
        {
            //¸Ê ÀüºÎ ²ô±â
            if(GenerateMapList.Count>0)
            {
                foreach (GameObject map in GenerateMapList)
                    map.SetActive(false);
            }

            var generatedMap = GenerateMapList.FirstOrDefault(x => x.name.Contains(type.ToString()));

            if(generatedMap != null)
            {
                generatedMap.SetActive(true);
                PlayerViewModel.Instance.CurrentMap = generatedMap;
            }

            else
            {
                GameObject target = MapPrefabs.FirstOrDefault(x => x.name.Contains(type.ToString()));
                if (target != null)
                {
                    var map = Instantiate(target);
                    map.name = target.name;
                    map.transform.rotation = Quaternion.identity;
                    PlayerViewModel.Instance.CurrentMap = map;
                    PlayerViewModel.Instance.PlayerData.CurMapType = type;
                    GenerateMapList.Add(map);
                }
            }


            
            
        }


    }
}

