using Assets.Scripts;
using UnityEngine;
using Zenject;

public class AppInstasller : MonoInstaller
{
    [SerializeField] private LanguagesContainer _languagesContainer;
    [SerializeField] private LastViewedRecipes _lastViwedRecipes;

    public override void InstallBindings()
    {
        Container.Bind<SaverLoader>().FromNew().AsSingle().NonLazy();
        Container.Bind<LastViewedRecipes>().FromInstance(_lastViwedRecipes).AsSingle().NonLazy();

        //////Container.Bind<LanguagesContainer>().FromInstance(_languagesContainer).AsSingle().NonLazy();
    }
}
