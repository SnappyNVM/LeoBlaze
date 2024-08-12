using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExercisesDataView : PageMediaDataViewBase
{

    [Header("Additional")]
    [SerializeField] private Image _stars;
    [SerializeField] private Image _bodyPartIcon;

    public ExercisesPageMediaData Data => _core.Data as ExercisesPageMediaData;

    public override void UnboxMediaViewInList()
    {
        base.UnboxMediaViewInList();
        _stars.sprite = Data.StarsIcon;
        _bodyPartIcon.sprite = Data.BodyPartIcon;
    }
}

