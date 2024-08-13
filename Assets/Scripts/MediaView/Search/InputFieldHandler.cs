using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputFieldHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private PageMediaCoreContainer _coreContainer;

    public UnityEvent Searched;

    private void Awake()
    {
        _inputField ??= GetComponent<TMP_InputField>();
        _inputField.text = string.Empty;
    }

    public void Search()
    {
        EventlessSearch();
        Searched?.Invoke();
    }


    private void EventlessSearch()
    {
        var extraSymbols = new char[] { ' ', '\t' };
        string searchText = _inputField.text.TrimStart(extraSymbols).TrimEnd(extraSymbols);
        foreach (var core in _coreContainer.Cores)
        {
            core.SearchDisplayable = core.Data.Name.ToLower().Contains(searchText.ToLower());
        }
    }
}
