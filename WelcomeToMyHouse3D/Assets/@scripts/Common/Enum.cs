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
        Fade,
        InfoShow,
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
        FirstMap,
        SecondMap,
    }

    public enum ItemName
    {
        None,
        GardenMap_BushKey, //별장 출입 열쇠
        GardenMap_FlashLight, //손전등
        FirstFloor_Key, //2층 출입 열쇠
        FirstFloor_Injector, //1층 주사기
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
        SFX_PaperSound,
        SFX_HorrorAppear,
        SFX_Siren,
        SFX_GetItem,
        SFX_Gag,
        SFX_Curtain,
        SFX_MetalDoorOpen,
        SFX_Injector,
    }

    public enum BGMName
    {
        BGM_GardenMap,
        BGM_FirstFloor,
    }

    public enum QuestName
    {
        GardenMap_OpenDoor = 0, //정원 문 열기
        FirstFloor_GetInjector = 1,
        SecondFloor_GetSaw = 2,
    }

    public enum DoorCount
    {
        FirstDoor,
        SecondDoor,
    }

    public enum SpiderState
    {
        attack1,
        run,
        idle,
        taunt,
    }
}

