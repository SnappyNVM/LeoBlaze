using UnityEngine;

[CreateAssetMenu(fileName = "Exercises Page Data")]
public sealed class ExercisesPageMediaData : PageMediaPackDataBase
{
    [field: SerializeField] public Sprite StarsIcon { get; private set; }
    [field: SerializeField] public Sprite BodyPartIcon { get; private set; }
}
