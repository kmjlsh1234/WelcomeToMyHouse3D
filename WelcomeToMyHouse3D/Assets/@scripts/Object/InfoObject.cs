using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Object.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class InfoObject : ObjectBase
    {
        public override void TouchEvent()
        {
            base.TouchEvent();

            PlayerViewModel.Instance.Player._canMove = false;
            PlayerViewModel.Instance.Player._canRotate = false;
            PlayerViewModel.Instance.CurrentObjectName = this.gameObject.name;
            UIManager.Instance.Show(PopupStyle.InfoShow);
        }
    }
}

