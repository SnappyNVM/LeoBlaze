using TMPro;
using UnityEngine;

public sealed class RecipeDataView : PageMediaDataViewBase
{
    [Header("Additional")]
    [SerializeField] private TMP_Text _caloriesOnLine;
    [SerializeField] private TMP_Text _caloriesOnPage;

    private RecipePageMediaData Data => _core.Data as RecipePageMediaData;

    public override void UnboxMediaViewInList()
    {
        base.UnboxMediaViewInList();
        _caloriesOnLine.text = Data.Calories;
    }

    public override void UnboxMediaViewWhenPageOpen()
    {
        base.UnboxMediaViewWhenPageOpen();
        _caloriesOnPage.text = Data.Calories;
    }
}