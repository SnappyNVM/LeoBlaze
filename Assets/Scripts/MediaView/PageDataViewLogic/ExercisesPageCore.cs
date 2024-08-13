using System;

public sealed class ExercisesPageCore : PageMediaCoreBase
{
    protected override void OnValidate()
    {
        base.OnValidate();
        if (Data is ExercisesPageMediaData == false)
            throw new ArgumentException("Data is has to be ExercisesPageMediaData", nameof(Data));
        if (_view is ExercisesDataView == false)
            throw new ArgumentException("View is has to be ExercisesDataView", nameof(_view));
    }
}