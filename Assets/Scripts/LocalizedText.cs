using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private TextKeys _key;
    protected TMP_Text _selfText;

    private LanguagesContainer _container;

    [Inject]
    private void Construct(LanguagesContainer languagesContainer) =>
        _container = languagesContainer;

    public virtual void Start()
    {
        _container.LanguageChanged.AddListener(UpdateText);
        _selfText ??= GetComponent<TMP_Text>();
        UpdateText();
    }

    protected virtual void UpdateText() =>
        _selfText.text = _container.WordsDictionary[LanguagesContainer.GameLanguage][_key];
}

