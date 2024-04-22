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
        None,
        GardenMap_BushKey, //∫∞¿Â √‚¿‘ ø≠ºË
        FirstFloor_Key, //2√˛ √‚¿‘ ø≠ºË
        FirstFloor_Injector, //1√˛ ¡÷ªÁ±‚
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
    }

    public enum BGMName
    {
        BGM_GardenMap,
        BGM_FirstFloor,
    }

    public enum QuestName
    {
        GardenMap_OpenDoor = 0, //¡§ø¯ πÆ ø≠±‚
        FirstFloor_GetInjector = 1,
        FirstFloor_OpenDoor = 2,
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

