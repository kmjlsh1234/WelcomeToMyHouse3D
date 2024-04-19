using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public enum PopupStyle
    {
        Dialog,
        Setting,
        ItemShow,
        Inventory,
        Joystick,
    }

    public enum SceneName
    {
        SplashScene,
        MainScene
    }

    public enum ObjectType
    {
        ChoiceObject,
        NotChoiceObject,
        ItemDropObject,
    }

    public enum PortalType
    {
        
        StartMap_TO_HouseEntranceMap,
        StartMap_TO_ExitMap,
        HouseEntranceMap_TO_StartMap,
        FirstLobbyMap
    }

    public enum MapType
    {
        GardenMap,
        FirstFloor,
        InSide
    }

    public enum ItemName
    {
        GardenMap_BushKey, //���� ���� ����
        FirstFloor_Key, //2�� ���� ����
        FirstFloor_Injector, //1�� �ֻ��
    }

    public enum SFXName
    {
        None,
        SFX_Click,
        SFX_ItemDrop,
        SFX_CatSound,
        SFX_DoorOpen,
        SFX_DoorClose,
        SFX_BushSound,
    }

    public enum BGMName
    {
        BGM_Wind,
        BGM_MainHouse
    }

    public enum QuestName
    {
        GardenMap_OpenDoor = 0, //���� �� ����
        FirstFloor_GetInjector = 1,
        FirstFloor_OpenDoor = 2,
    }

    public enum DoorCount
    {
        FirstDoor,
        SecondDoor,
    }
}

