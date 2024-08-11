using Assets.Scripts;
using UnityEngine;
using Zenject;

public class AppInstasller : MonoInstaller
{
    [SerializeField] private LanguagesContainer _languagesContainer;

    public override void InstallBindings()
    {
        Container.Bind<SaverLoader>().FromNew().AsSingle().NonLazy();
        //////Container.Bind<LanguagesContainer>().FromInstance(_languagesContainer).AsSingle().NonLazy();
    }
}
