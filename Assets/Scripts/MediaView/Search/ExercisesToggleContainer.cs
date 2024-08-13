public sealed class ExercisesToggleContainer : ToggleContainerBase
{
    public override FiltersTypes[] ToggleTypeGroup => _toggleTypeGroup;

    public override FiltersTypes ToggleTypeToActivateAll => FiltersTypes.AllForExercises;

    private readonly FiltersTypes[] _toggleTypeGroup = new FiltersTypes[] { FiltersTypes.Head, FiltersTypes.Foots, 
        FiltersTypes.Body, FiltersTypes.Hands,
        FiltersTypes.Neck, FiltersTypes.Back,
        FiltersTypes.Belly
    };
}