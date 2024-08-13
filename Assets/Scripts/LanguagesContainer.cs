using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Languages
{
    English = 0,
    Russian = 1,
    Brazilian = 2
}

public enum TextKeys
{
    Settings,
    Amount,
    Convert,
    PrewConverts,
    TotalAmount,
    AddNew,
    Token,
    Save,
    Delete,
    Theme,
    Language,
    Convertion,
    Close
}

public class LanguagesContainer : MonoBehaviour
{
    private static Languages gameLanguage = Languages.Russian;
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<TextKeys, string>> WordsDictionary { get; private set; }
    public UnityEvent LanguageChanged;

    private void Awake()
    {
        FillWordsDictionary();
        ChangeLanguage((Languages)PlayerPrefs.GetInt(PlayerPrefsKeys.Language, 1));
        // To be rewritten using progress and json saves
    }

    public void ChangeLanguage(Languages language)
    {
        gameLanguage = language;
        PlayerPrefs.SetInt(PlayerPrefsKeys.Language, (int)gameLanguage);
        // And that's like 28th says
        LanguageChanged?.Invoke();
    }

    public void SetToRussian() =>
        ChangeLanguage(Languages.Russian);

    public void SetToEnglish() =>
        ChangeLanguage(Languages.English);


    private void FillWordsDictionary()
    {
        WordsDictionary = new Dictionary<Languages, Dictionary<TextKeys, string>>()
        {
            [Languages.Russian] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.Settings] = "Настройки",
                [TextKeys.Amount] = "Количество",
                [TextKeys.Convert] = "Конвертировать",
                [TextKeys.PrewConverts] = "Ваши предыдущие конверсии",
                [TextKeys.TotalAmount] = "Общая сумма",
                [TextKeys.AddNew] = "Добавление",
                [TextKeys.Token] = "Токен",
                [TextKeys.Save] = "Сохранить",
                [TextKeys.Delete] = "Удалить",
                [TextKeys.Theme] = "Тема",
                [TextKeys.Language] = "Язык",
                [TextKeys.Convertion] = "Конвертация",
                [TextKeys.Close] = "Закрыть"

            },

            [Languages.English] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.Settings] = "Settings",
                [TextKeys.Amount] = "Amount",
                [TextKeys.Convert] = "Convert",
                [TextKeys.PrewConverts] = "Your previous conversions",
                [TextKeys.TotalAmount] = "Total amount",
                [TextKeys.AddNew] = "Add new",
                [TextKeys.Token] = "Token",
                [TextKeys.Save] = "Save",
                [TextKeys.Delete] = "Delete",
                [TextKeys.Theme] = "Theme",
                [TextKeys.Language] = "Language",
                [TextKeys.Convertion] = "Convertion",
                [TextKeys.Close] = "Close"
            }
        };
    }
}



