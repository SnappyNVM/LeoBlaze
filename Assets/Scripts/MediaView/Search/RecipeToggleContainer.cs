public sealed class RecipeToggleContainer : ToggleContainerBase
{
    public override FiltersTypes[] ToggleTypeGroup => _toggleTypeGroup;

    public override FiltersTypes ToggleTypeToActivateAll => FiltersTypes.AllForRecipes;

    private readonly FiltersTypes[] _toggleTypeGroup = new FiltersTypes[] { FiltersTypes.Breakfast, FiltersTypes.Dinner, FiltersTypes.Dessert, FiltersTypes.Lunch };
}

