using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class GaurdDoll : ObjectBase
    {
        [SerializeField] private AudioClip[] _touchInteractionClips;
        private AudioSource _audioSource;
        private int interactionNum = 0;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            if (interactionNum == _touchInteractionClips.Length) interactionNum = 0;

            _audioSource.clip = _touchInteractionClips[interactionNum];
            _audioSource.Play();
            interactionNum++;
        }
    }
}

