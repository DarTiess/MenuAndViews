using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class OptionsView : MonoBehaviour
{
  [SerializeField]
   private Button _soundButton;
   [SerializeField]
   private Button _musicButton;
   [SerializeField]
   private Color clickedColor;
   private Bootstraper _bootstraper;

   private ViewBase _viewBase;
   private bool _isClickedSound;
   private bool _isClickedMusic;
   private void Start()
   {
       _viewBase = GetComponent<ViewBase>();
       _bootstraper = _viewBase.Bootstraper;
       _soundButton.onClick.AddListener(SwitchSound);
       _musicButton.onClick.AddListener(SwitchMusic);
   }

   private void SwitchMusic()
   {
      _isClickedMusic= ChangeColorButton(_isClickedMusic,_musicButton);
       _bootstraper.SwitchMusicState();
   }

   private void SwitchSound()
   {
      _isClickedSound= ChangeColorButton(_isClickedSound, _soundButton);


       _bootstraper.SwitchSoundState();
   }

   private bool ChangeColorButton(bool isClicked, Button button)
   {
       if (!isClicked)
       {
           button.image.color = clickedColor;
           isClicked= true;
       }
       else
       {
           button.image.color = new Color(255, 255, 255, 255);
           isClicked = false;
       }

       return isClicked;
   }
}
