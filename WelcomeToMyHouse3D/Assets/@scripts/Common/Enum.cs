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
        GardenMap_BushKey,
    }

    public enum SFXName
    {
        SFX_Door,
        SFX_WallClose,
        SFX_Crush
    }

    public enum BGMName
    {
        BGM_Wind,
        BGM_MainHouse
    }

    public enum QuestName
    {
        GardenMap_OpenDoor = 0,
    }

    public enum DoorCount
    {
        FirstDoor,
        SecondDoor,
    }
}

