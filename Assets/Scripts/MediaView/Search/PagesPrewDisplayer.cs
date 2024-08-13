using UnityEngine;
using Zenject.Asteroids;

public class PagesPrewDisplayer : MonoBehaviour
{
    [SerializeField] private ToggleContainerBase _toggleContainer;
    [SerializeField] private PageMediaCoreContainer _coresContainer;
    [SerializeField] private GroupGameObjectSwapper _filterPanelSwapper;
    [SerializeField] private InputFieldHandler _inputFieldHandler;
    [SerializeField] private RectTransform _scrollRectContent;

    private void Awake()
    {
        _toggleContainer.Initialize();
        _coresContainer.Initialize();
        SubscribeTheEvents();
        _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].SetToggleOn();
    }

    private void OnCheckmarkValueChanged(FiltersTypes type, bool enabled)
    {
        CheckIfAllActivated(type, enabled);
        SetUpTheCores();
    }

    private void SubscribeTheEvents()
    {
        _inputFieldHandler.Searched.AddListener(SetUpTheCores);
        foreach (var type in _toggleContainer.ToggleTypeGroup)
        {
            _toggleContainer.ToggleModels[type].ToggleStateChanged.AddListener(OnCheckmarkValueChanged);
        }
        _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].ToggleStateChanged.AddListener(OnCheckmarkValueChanged);
    }

    private void CheckIfAllActivated(FiltersTypes type, bool enabled)
    {
        bool allActivated = true;
        bool allDeactivated = true;
        foreach (var filtersType in _toggleContainer.ToggleTypeGroup)
        {
            if (_toggleContainer.ToggleModels[filtersType].ToggleOnStatment == false)
                allActivated = false;
            else 
                allDeactivated = false;
        }
        if (type == _toggleContainer.ToggleTypeToActivateAll)
        {
            if (enabled)
            {
                foreach (var filtersType in _toggleContainer.ToggleTypeGroup)
                    _toggleContainer.ToggleModels[filtersType].SetToggleOn();
            }
            else
            {
                if(allActivated == false)
                    return;
                _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].SetToggleOn();
            }
            return;
        }
        if (type != _toggleContainer.ToggleTypeToActivateAll)
        {
            if (enabled == false)
            {
                if (allDeactivated)
                    _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].SetToggleOn();
                else if (_toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].ToggleOnStatment == true)
                     _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].SetToggleOff();
            }
            else if (enabled == true && allActivated && _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].ToggleOnStatment == false)
                _toggleContainer.ToggleModels[_toggleContainer.ToggleTypeToActivateAll].SetToggleOn();
        }
    }

    private void SetUpTheCores()
    {
        foreach (var core in _coresContainer.Cores)
        {
            core.gameObject.SetActive(_toggleContainer.ToggleModels[core.Data.Type].ToggleOnStatment && core.SearchDisplayable);
            _scrollRectContent.SetY(0);
        }
    }
}
