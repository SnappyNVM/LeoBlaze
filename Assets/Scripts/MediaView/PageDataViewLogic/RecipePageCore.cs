using System;
using UnityEngine;

public sealed class RecipePageCore : PageMediaCoreBase
{
    protected override void OnValidate()
    {
        base.OnValidate();
        if (Data is RecipePageMediaData == false)
            throw new ArgumentException("Data is has to be RecipePageMediaData", nameof(Data));
        if (_view is RecipeDataView == false)
            throw new ArgumentException("View is has to be RecipeDataView", nameof(_view));
    }
}

