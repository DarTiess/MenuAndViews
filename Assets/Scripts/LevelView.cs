using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField]
    private Button upButton;
    [SerializeField]
    private Button downButton;
    [SerializeField]
    private GameObject firstBlocks;
    [SerializeField]
    private GameObject secondsBlocks;
  
    [SerializeField]
    private GameObject downPlace;
    [SerializeField]
    private GameObject upperPlace;
    private Bootstraper _bootstraper;

    private ViewBase _viewBase;
    private void Start()
    {
        _viewBase = GetComponent<ViewBase>();
        _bootstraper = _viewBase.Bootstraper;
        upButton.onClick.AddListener(OpenSecondsBlocks);
        downButton.onClick.AddListener(OpenFirstBlocks);
    }

    private void OpenFirstBlocks()
    {
        _bootstraper.PlayClickSound();
        firstBlocks.transform.DOMoveY(secondsBlocks.transform.position.y, 0.5f)
                     .OnStart(() =>
                     {
                         secondsBlocks.transform.DOMoveY(upperPlace.transform.position.y, 0.5f);
                     });
    }

    private void OpenSecondsBlocks()
    {
        _bootstraper.PlayClickSound();
        secondsBlocks.transform.DOMoveY(firstBlocks.transform.position.y, 0.5f)
                     .OnStart(() =>
                     {
                         firstBlocks.transform.DOMoveY(downPlace.transform.position.y, 0.5f);
                     });
    }
}