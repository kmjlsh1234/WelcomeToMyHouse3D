using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;

namespace Assets.Scripts.Manager
{
    public class DataManager : SingletonBase<DataManager>
    {
        private const string USERDATA = "USERDATA";
        public PlayerData PlayerData = null;
        
        public void LoadData()
        {
            PlayerData = ES3.Load<PlayerData>(USERDATA, defaultValue : null);
            if(PlayerData == null)
            {
                PlayerData = new PlayerData();
                SaveData();
            }

        }

        public void SaveData()
        {
            Transform playerTrans = PlayerViewModel.Instance.Player.gameObject.transform;
            PlayerData.Position = playerTrans.position;
            PlayerData.Rotation = playerTrans.rotation.eulerAngles;
            Debug.Log("데이터 저장 완료!");

        }
    }
}

