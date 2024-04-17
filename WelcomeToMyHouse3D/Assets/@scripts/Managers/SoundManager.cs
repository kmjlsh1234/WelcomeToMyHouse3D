using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Common;

namespace Assets.Scripts.Manager
{
    public class SoundManager : SingletonBase<SoundManager>
    {
        private Dictionary<string, AudioClip> _audioLibrary = new Dictionary<string, AudioClip>();
        public AudioSource _aSourceSFX;
        public AudioSource _aSourceBGM;

        public string _curBGMName = "";
        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            AudioClip[] aClips = ResourceManager.Instance.LoadAudioLibrary();

            _aSourceSFX = gameObject.AddComponent<AudioSource>();
            _aSourceBGM = gameObject.AddComponent<AudioSource>();
            _aSourceBGM.loop = true;

            for (int i = 0; i < aClips.Length; i++)
            {
                _audioLibrary.Add(aClips[i].name, aClips[i]);
            }
        }

        public AudioClip GetClip(string clipName)
        {
            if (_audioLibrary.TryGetValue(clipName, out AudioClip clip))
            {
                return clip;
            }
            else
            {
                Debug.Log("No Audio Clip Found! => " + clipName);
                return null;
            }
        }

        public void PlaySound(SFXName sfxName)
        {
            var clipName = sfxName.ToString();
            Debug.Log("ClipName : " + clipName);
            if (_audioLibrary.TryGetValue(clipName, out AudioClip clip))
                _aSourceSFX.PlayOneShot(clip);
            else
            {
                Debug.Log("No Audio Clip Found! => " + clipName);
            }
        }
        public void PlayBGM(BGMName bgmName)
        {
            _aSourceBGM.Stop();
            var clipName = bgmName.ToString();
            if (_audioLibrary.TryGetValue(clipName, out AudioClip clip))
            {
                _aSourceBGM.clip = clip;
                _aSourceBGM.Play();
            }
            else
            {
                Debug.Log("No Audio Clip Found! => " + clipName);
            }
        }

        public void CheckBGMChange(MapType _mapType)
        {

            if (_aSourceBGM.clip != null)
                _curBGMName = _aSourceBGM.clip.name;

            var _nextBGM = _mapType == MapType.InSide ? BGMName.BGM_MainHouse : BGMName.BGM_Wind;
            var _nextBGMName = _nextBGM.ToString();

            if (_curBGMName == _nextBGMName)
                return;

            else
                PlayBGM(_nextBGM);
        }
    }
}

