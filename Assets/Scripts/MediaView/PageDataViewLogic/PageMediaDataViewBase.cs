using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] protected TMP_Text _headerNameView;
    [SerializeField] protected TMP_Text _mediaTextView;
    [SerializeField] protected TMP_Text _timeInPage;
    [SerializeField] protected RectTransform _textScrollRectContent;
    [SerializeField] protected Image _videoIconView;
    [SerializeField] protected TMP_Text _typeInPageView;
    [SerializeField] protected VideoPanel _videoPanel;
    [SerializeField] protected GameObject _specialRecipeOnPageStuff;

    public virtual void UnboxMediaViewInList()
    {
        Debug.Log(nameof(UnboxMediaViewInList) + " of " + _core.Data.name);
        _nameView.text = _core.Data.Name;
        _timeInMinutesView.text = _core.Data.TimeInMinutes.ToString() + " min";
        _iconView.sprite = _core.Data.Icon;
        _typeView.text = _core.Data.Type.ToString();
    }

    public virtual void UnboxMediaViewWhenPageOpen()
    {
        _headerNameView.text = _core.Data.Name;
        _videoIconView.sprite = _core.Data.VideoPrew;
        _iconView.sprite = _core.Data.Icon;
        _typeInPageView.text = _core.Data.Type.ToString();
        _timeInPage.text = _core.Data.TimeInMinutes.ToString() + " min";

        _videoPanel.OnPanelOpened(_core.Data.MediaVideo);
        SetScrollTextContent();
        _specialRecipeOnPageStuff.SetActive(this is RecipeDataView);

    }

    protected virtual void OnValidate() =>
        _core ??= GetComponent<PageMediaCoreBase>();

    private void SetScrollTextContent()
    {
        _mediaTextView.text = _core.Data.MediaText;
        Canvas.ForceUpdateCanvases();
        _textScrollRectContent.sizeDelta = new Vector2(_textScrollRectContent.sizeDelta.x, _mediaTextView.preferredHeight + 50);
        _textScrollRectContent.anchoredPosition = new Vector2(_textScrollRectContent.anchoredPosition.x, 0);
    }
}

