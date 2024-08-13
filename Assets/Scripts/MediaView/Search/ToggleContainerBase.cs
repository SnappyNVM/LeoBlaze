using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ToggleContainerBase : MonoBehaviour
{
    public Dictionary<FiltersTypes, ToggleModel> ToggleModels;
    public abstract FiltersTypes[] ToggleTypeGroup { get; }
    public abstract FiltersTypes ToggleTypeToActivateAll { get; }   

    public virtual void Initialize()
    {
        FillTogglesDictionary();
        ResetToggles();
    }

    private void ResetToggles()
    {
        foreach(var type in ToggleTypeGroup)
            ToggleModels[type].SetToggleOff();
    }

    private void FillTogglesDictionary()
    {
        ToggleModels = new();
        ToggleModel[] models = GetComponentsInChildren<ToggleModel>();
        foreach (var model in models)
            ToggleModels.Add(model.Type, model);

        try
        {
            foreach (FiltersTypes type in ToggleTypeGroup)
                ToggleModels[type] = ToggleModels[type]; 
        }
        catch
        {
            throw new ArgumentException("Not all toggles of filter group actually exist");
        }
    }
}

