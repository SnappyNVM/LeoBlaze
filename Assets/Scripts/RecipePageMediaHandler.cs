using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class RecipePageMediaHandler : MonoBehaviour
    {
        [SerializeField] private RecipePageCore _core;

        private LastViewedRecipes _lastViewedRecipes;
        
        [Inject]
        private void Construct(LastViewedRecipes lastViewedRecipes)
        {
            _lastViewedRecipes = lastViewedRecipes;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public void Initialize(LastViewedRecipes lastViewedRecipes)
        {
            _lastViewedRecipes = lastViewedRecipes;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            _lastViewedRecipes.OnSellectRecipes(_core);
        }
    }
}
