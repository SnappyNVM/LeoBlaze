using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class LastViewedRecipes : MonoBehaviour
    {
        [SerializeField] private RecipePageCore _recipeViewPrefab;
        [SerializeField] private List<RecipePageCore> _datas;
        [SerializeField] private Transform _root;

        private List<RecipePageCore> _currentSpawnedRecipes = new();
        private SaverLoader _saverLoader;

        [Inject]
        private void Construct(SaverLoader saverLoader) =>
            _saverLoader = saverLoader;

        private void OnEnable() => 
            UpdateRecipes();

        private void UpdateRecipes()
        {
            _currentSpawnedRecipes.ForEach(x => Destroy(x.gameObject));
            _currentSpawnedRecipes.Clear();
            for(int i = _saverLoader.Progress.RecipesId.Count - 1; i >= 0; i--)
            {
                var instance = Instantiate(_recipeViewPrefab, _root);
                instance.GetComponent<RecipePageMediaHandler>().Initialize(this);
                instance.Data = _datas[i].Data;
                instance.View.UnboxMediaViewInList();

                instance.Initialize();
                _currentSpawnedRecipes.Add(instance);
            }
        }

        public void OnSellectRecipes(RecipePageCore data)
        {
            if(_saverLoader.Progress.RecipesId.Contains(_datas.IndexOf(data)))
                _saverLoader.Progress.RecipesId.Remove(_datas.IndexOf(data));
            _saverLoader.Progress.RecipesId.Add(_datas.IndexOf(data));
            _saverLoader.Save();
        }
    }
}
