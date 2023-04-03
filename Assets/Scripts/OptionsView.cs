using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class OptionsView : MonoBehaviour
{
  [SerializeField]
   private Button _soundButton;
   [SerializeField]
   private Button _musicButton;
   private Bootstraper _bootstraper;

   private ViewBase _viewBase;
   private void Start()
   {
       _viewBase = GetComponent<ViewBase>();
       _bootstraper = _viewBase.Bootstraper;
       _soundButton.onClick.AddListener(()=>_bootstraper.SwitchSoundState());
       _musicButton.onClick.AddListener(()=>_bootstraper.SwitchMusicState());
   }
}
