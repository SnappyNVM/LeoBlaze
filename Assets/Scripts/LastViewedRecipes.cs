using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            Debug.Log(nameof(UpdateRecipes));
            _currentSpawnedRecipes.ForEach(x => Destroy(x.gameObject));
            _currentSpawnedRecipes.Clear();
            foreach(var i in _saverLoader.Progress.RecipesId)
            {
                var instance = Instantiate(_recipeViewPrefab, _root);
                instance.GetComponent<RecipePageMediaHandler>().Initialize(this);
                instance.Data = _datas[i].Data;
                instance.View._headerNameView = _datas[i].View._headerNameView;
                instance.View._mediaTextView = _datas[i].View._mediaTextView;
                instance.View._specialRecipeOnPageStuff = _datas[i].View._specialRecipeOnPageStuff;
                instance.View._textScrollRectContent = _datas[i].View._textScrollRectContent;
                instance.View._timeInPage = _datas[i].View._timeInPage;
                instance.View._typeInPageView = _datas[i].View._typeInPageView;
                instance.View._videoIconView = _datas[i].View._videoIconView;
                instance.View._videoPanel = _datas[i].View._videoPanel;
                Button button = instance.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick = _datas[i].View.GetComponent<Button>().onClick;
                instance.View.SubscribeToUpdate(button);
                (instance.View as RecipeDataView)._caloriesOnPage = (_datas[i].View as RecipeDataView)._caloriesOnPage;

                instance.Initialize();
                _currentSpawnedRecipes.Add(instance);
            }
        }

        public void OnSellectRecipes(RecipePageCore data)
        {
            if(_saverLoader.Progress.RecipesId.Contains(_datas.IndexOf(data)))
                _saverLoader.Progress.RecipesId.Remove(_datas.IndexOf(data));
            _saverLoader.Progress.RecipesId.Add(_datas.IndexOf(data));
           
            Debug.Log(_saverLoader.Progress.RecipesId.Count);
            _saverLoader.Save();
        }
    }
}
