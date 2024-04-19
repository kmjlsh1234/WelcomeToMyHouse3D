using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Player;
using System.IO;
using Assets.Scripts.Common;

namespace Assets.Scripts.Manager
{
    public class DataManager : SingletonBase<DataManager>
    {
        private const string SAVEPATH = "/playerData.json";

        private void Start()
        {
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(SAVEPATH))
            {
                var jsonData = File.ReadAllText(SAVEPATH);
                var data = JsonUtility.FromJson<PlayerData>(jsonData);
                PlayerViewModel.Instance.PlayerData = data;
            }
            else
            {
                PlayerViewModel.Instance.PlayerData = new PlayerData();

                PlayerViewModel.Instance.PlayerData.CurMapType = MapType.GardenMap;
                PlayerViewModel.Instance.PlayerData.QuestName = QuestName.GardenMap_OpenDoor;
                PlayerViewModel.Instance.PlayerData.ItemList = new List<ItemName>();
            }
        }

        public void SaveData()
        {
            PlayerViewModel.Instance.PlayerData.Position = PlayerViewModel.Instance.Player.transform.position;
            PlayerViewModel.Instance.PlayerData.Rotation = PlayerViewModel.Instance.Player.transform.rotation.eulerAngles;

           var jsonData = JsonUtility.ToJson(PlayerViewModel.Instance.PlayerData);
            File.WriteAllText(SAVEPATH, jsonData);
        }
    }
}

