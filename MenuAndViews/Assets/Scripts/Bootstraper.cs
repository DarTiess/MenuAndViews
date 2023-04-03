using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Bootstraper: MonoBehaviour
    {
        [SerializeField]
        private ViewBase _menuPrefab;
        [SerializeField]
        private ViewBase _optionPrefab;
        [SerializeField]
        private ViewBase _levelPrefab;


        [SerializeField] private AudioSource _soundSource;
        [SerializeField] private AudioSource _musicSource;
       private Dictionary<WindowId, ViewBase> _views;

       private void Awake()
        {
           
            CreateAllViews();
            _views.First(x=>x.Key==WindowId.MenuView).Value.gameObject.SetActive(true);
        }

        private void CreateAllViews()
        {
            _views = new Dictionary<WindowId, ViewBase>
            {
                [WindowId.MenuView] = CreateView(_menuPrefab),
                [WindowId.OptionView] = CreateView(_optionPrefab),
                [WindowId.LevelView] = CreateView(_levelPrefab),
            };

        }

        private ViewBase CreateView(ViewBase prefab)
        {
            ViewBase view = Instantiate(prefab);
            view.Construct(this);
            view.gameObject.SetActive(false);
            return view;
        }

        public void SwitchView(WindowId windowId)
        {
            CloseAllView();
           OpenView(windowId);
        }

        private void OpenView(WindowId id)
        {
            _views.First(x => x.Key == id).Value.gameObject.SetActive(true);
        }

        private void CloseAllView()
        {
            foreach (KeyValuePair<WindowId, ViewBase> view in _views)
            {
                view.Value.gameObject.SetActive(false);
            }
        }

        public void SwitchSoundState()
        {
            SwitchAudioSourceState(_soundSource);
        }

        public void SwitchMusicState()
        {
           SwitchAudioSourceState(_musicSource);
        }

        private void SwitchAudioSourceState(AudioSource audioSource)
        {
            if (audioSource.isActiveAndEnabled)
            {
                audioSource.enabled = false;
            }
            else
            {
                audioSource.enabled = true;
            }
        }
    }
}