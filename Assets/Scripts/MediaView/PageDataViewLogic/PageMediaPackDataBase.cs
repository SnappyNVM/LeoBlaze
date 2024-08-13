using UnityEngine;
using UnityEngine.Video;

public abstract class PageMediaPackDataBase : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string NameRu { get; private set; }
    [field: SerializeField] public string NameBr { get; private set; }

    [field: SerializeField] public int TimeInMinutes { get; private set; }
    [field: SerializeField, TextArea(10, 100)] public string MediaText { get; private set; }
    [field: SerializeField, TextArea(10, 100)] public string MediaTextRu { get; private set; }
    [field: SerializeField, TextArea(10, 100)] public string MediaTextBr { get; private set; }

    [field: SerializeField] public VideoClip MediaVideo { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite VideoPrew { get; private set; }
    [field: SerializeField] public FiltersTypes Type { get; private set; }
}
