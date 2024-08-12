using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Page Data")]
public sealed class RecipePageMediaData : PageMediaPackDataBase
{
    [field: SerializeField] public string Calories { get; private set; }
}
