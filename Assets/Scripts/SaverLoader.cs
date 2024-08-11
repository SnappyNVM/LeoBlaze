using Assets.Scripts;
using UnityEngine;

public class SaverLoader
{
    private const string ProgressKey = "Progress";
    public UserProgressData Progress { get; private set; }

    public SaverLoader() => Load();

    public void Load() =>
        Progress = PlayerPrefs.GetString(ProgressKey) == null || PlayerPrefs.GetString(ProgressKey).Length == 0 ? new() : PlayerPrefs.GetString(ProgressKey).FromJson<UserProgressData>();

    public void Save() =>
        PlayerPrefs.SetString(ProgressKey, Progress.ToJson());

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Load();
        Save();
    }
}
