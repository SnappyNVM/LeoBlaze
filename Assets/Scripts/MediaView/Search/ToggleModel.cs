using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleModel : MonoBehaviour
{
    [field: SerializeField] private Toggle _toggle;

    [field: SerializeField] public FiltersTypes Type { get; private set; }

    public bool ToggleOnStatment => _toggle.isOn;
    public UnityEvent<FiltersTypes, bool> ToggleStateChanged;

    private void OnValidate() =>
        _toggle ??= GetComponent<Toggle>();

    private void Awake() =>
        _toggle.onValueChanged.AddListener(OnToggleValueChanged);

    public void SetToggleOn()
    {
        _toggle.isOn = true;
        OnToggleValueChanged(true);
    }

    public void SetToggleOff()
    {
        _toggle.isOn = false;
        OnToggleValueChanged(false);
    }

    public void OnToggleValueChanged(bool value) =>
        ToggleStateChanged?.Invoke(Type, value);
}

