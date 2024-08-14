using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private TextKeys _key;
    protected TMP_Text _selfText;

    private LanguagesContainer _container;

    public virtual void Start()
    {
        LanguagesContainer.Instance.LanguageChanged.AddListener(UpdateText);
        // hate singleton, i have no time
        _selfText ??= GetComponent<TMP_Text>();
        UpdateText();
    }

    protected virtual void UpdateText() =>
        _selfText.text = LanguagesContainer.Instance.WordsDictionary[LanguagesContainer.GameLanguage][_key];
}

