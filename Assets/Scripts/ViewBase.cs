using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ViewBase: MonoBehaviour
    {
        [SerializeField] private float _rotateAngle;
        [SerializeField] private float _rotateDuration;
        [SerializeField]
        private List<ViewButton> _buttonsView = new List<ViewButton>();

        private Bootstraper _bootstraper;
        public Bootstraper Bootstraper { get => _bootstraper; }

        private void Awake()
        {
            OnAwake();
        }

        public void Construct(Bootstraper bootstraper)
        {
            _bootstraper = bootstraper;
           
        }



        protected virtual void OnAwake()
        {
            foreach (ViewButton viewButton in _buttonsView)
            {
                viewButton.button.onClick.AddListener(()=>OnClickButton(viewButton));

            }
        }

        private void OnClickButton(ViewButton viewButton)
        {
            viewButton.button.transform.DORotate(Vector3.up *_rotateAngle, _rotateDuration)
                      .OnStart(() =>
                      {
                          _bootstraper.PlayClickSound();
                      })
                      .OnComplete(() =>
                      {
                          _bootstraper.SwitchView(viewButton.destinationId);
                          viewButton.button.transform.DORotate(Vector3.zero, 0f);
                      });
        }
    }
}