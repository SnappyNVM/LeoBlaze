using TMPro;
using UnityEngine;
using Zenject;

public class LanguageButtonsHighlighter : ThemeAdapriveObject
{
    [SerializeField] private TMP_Text _engButton;
    [SerializeField] private TMP_Text _ruButton;

    private LanguagesContainer _languageContainer;

    [Inject]
    private void Construst(LanguagesContainer container) =>
        _languageContainer = container;

    private void OnEnable() =>
        UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey));

    private void Start()
    {
        _languageContainer.LanguageChanged.AddListener(() => UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey)));
        UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey));
    }

    protected override void UpdateObject(string theme)
    {
        Debug.Log("Update button colour");
        Color defaultColour = Color.white;
        switch (theme)
        {
            case nameof(PlayerPrefsKeys.DarkKey):
                defaultColour = Color.white; break;
            case nameof(PlayerPrefsKeys.LightKey):
                defaultColour = Color.black; break;
        }
        _engButton.color = defaultColour;
        _ruButton.color = defaultColour;

        Color green = defaultColour == Color.black ? Color.red : Color.green;
        switch (LanguagesContainer.GameLanguage)
        {
            case Languages.English:
                _engButton.color = green; break;
            case Languages.Russian:
                _ruButton.color = green; break;
        }
    }
}
