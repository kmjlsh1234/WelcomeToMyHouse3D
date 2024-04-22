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

        private void Start()
        {
            LoadData();
        }

        public void LoadData()
        {
            string path = Path.Combine(Application.dataPath, "playerData.json");
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                var data = JsonUtility.FromJson<PlayerData>(jsonData);
                PlayerViewModel.Instance.PlayerData = data;

                PlayerViewModel.Instance.Player.gameObject.transform.position = data.Position;
                PlayerViewModel.Instance.Player.gameObject.transform.eulerAngles = data.Rotation;

            }
            else
            {
                PlayerViewModel.Instance.PlayerData = new PlayerData();
                
                PlayerViewModel.Instance.PlayerData.CurMapType = MapType.GardenMap;
                PlayerViewModel.Instance.PlayerData.QuestName = QuestName.GardenMap_OpenDoor;
                PlayerViewModel.Instance.PlayerData.ItemList = new List<ItemName>();
                PlayerViewModel.Instance.PlayerData.MapEventList = new List<string>();
            }

            MapManager.Instance.GenerateMap(PlayerViewModel.Instance.PlayerData.CurMapType);
        }

        public void SaveData()
        {
            PlayerViewModel.Instance.PlayerData.Position = PlayerViewModel.Instance.Player.transform.position;
            PlayerViewModel.Instance.PlayerData.Rotation = PlayerViewModel.Instance.Player.transform.rotation.eulerAngles;
            string path = Path.Combine(Application.dataPath, "playerData.json");
            var jsonData = JsonUtility.ToJson(PlayerViewModel.Instance.PlayerData);
            File.WriteAllText(path, jsonData);
        }
    }
}

