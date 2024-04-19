using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

namespace Assets.Scripts.Util
{
    public static class Util
    {
        public static IObservable<Unit> OnSoundClickAsObservable(this Button button, SFXName sfx = SFXName.SFX_Click)
        {
            SoundManager.Instance.PlaySound(sfx);
            return button.OnClickAsObservable();
        }
    }
}

