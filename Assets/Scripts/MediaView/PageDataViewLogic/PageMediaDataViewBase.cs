using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Zenject.Asteroids;

[RequireComponent(typeof(PageMediaCoreBase))]
public abstract class PageMediaDataViewBase : MonoBehaviour
{
    [SerializeField] protected PageMediaCoreBase _core;
    [Header("Views during the scroll")]
    [SerializeField] protected TMP_Text _nameView;
    [SerializeField] protected TMP_Text _timeInMinutesView;
    [SerializeField] protected TMP_Text _typeView;
    [SerializeField] protected Image _iconView;
    [Header("Views when media opened")]
    [SerializeField] public TMP_Text _headerNameView;
    [SerializeField] public TMP_Text _mediaTextView;
    [SerializeField] public TMP_Text _timeInPage;
    [SerializeField] public RectTransform _textScrollRectContent;
    [SerializeField] public Image _videoIconView;
    [SerializeField] public TMP_Text _typeInPageView;
    [SerializeField] public VideoPanel _videoPanel;
    [SerializeField] public GameObject _specialRecipeOnPageStuff;

    private void Awake() =>
        GetComponent<Button>().onClick.AddListener(UnboxMediaViewWhenPageOpen);

    private void OnEnable() =>
        UnboxMediaViewInList();

    public virtual void UnboxMediaViewInList()
    {
        Debug.Log(nameof(UnboxMediaViewInList) + " of " + _core.Data.name);
        switch(LanguagesContainer.GameLanguage)
        {
            case Languages.Russian:
                _nameView.text = _core.Data.NameRu;
                break;
            case Languages.English:
                _nameView.text = _core.Data.Name;
                break;
            case Languages.Brazilian:
                _nameView.text = _core.Data.NameBr;
                break;
        }
        _timeInMinutesView.text = _core.Data.TimeInMinutes.ToString() + " min";
        _iconView.sprite = _core.Data.Icon;
        _typeView.text = "Hello";//LanguagesContainer.Instance.TagsDictionary[LanguagesContainer.GameLanguage][_core.Data.Type];
    }

    public virtual void UnboxMediaViewWhenPageOpen()
    {
        switch (LanguagesContainer.GameLanguage)
        {
            case Languages.Russian:
                _headerNameView.text = _core.Data.NameRu;
                break;
            case Languages.English:
                _headerNameView.text = _core.Data.Name;
                break;
            case Languages.Brazilian:
                _headerNameView.text = _core.Data.NameBr;
                break;
        }
        if (_core.Data.VideoPrew != null)
            _videoIconView.sprite = _core.Data.VideoPrew;
        else
            _videoIconView.sprite = null;
        _iconView.sprite = _core.Data.Icon;
        _typeInPageView.text = LanguagesContainer.Instance.TagsDictionary[LanguagesContainer.GameLanguage][_core.Data.Type];
        _timeInPage.text = _core.Data.TimeInMinutes.ToString() + " min";

        _videoPanel.OnPanelOpened(_core.Data.MediaVideo);
        SetScrollTextContent();
        _specialRecipeOnPageStuff.SetActive(this is RecipeDataView);

    }

    protected virtual void OnValidate() =>
        _core ??= GetComponent<PageMediaCoreBase>();

    private void SetScrollTextContent()
    {
        switch (LanguagesContainer.GameLanguage)
        {
            case Languages.Russian:
                _mediaTextView.text = _core.Data.MediaTextRu;
                break;
            case Languages.English:
                _mediaTextView.text = _core.Data.MediaText;
                break;
            case Languages.Brazilian:
                _mediaTextView.text = _core.Data.MediaTextBr;
                break;
        }
        Canvas.ForceUpdateCanvases();
        _textScrollRectContent.sizeDelta = new Vector2(_textScrollRectContent.sizeDelta.x, _mediaTextView.preferredHeight + 50);
        _textScrollRectContent.anchoredPosition = new Vector2(_textScrollRectContent.anchoredPosition.x, 0);
    }

    public void SubscribeToUpdate(Button button) =>
        button.onClick.AddListener(UnboxMediaViewWhenPageOpen);
}

