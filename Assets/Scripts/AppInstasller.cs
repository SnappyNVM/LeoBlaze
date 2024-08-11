using Assets.Scripts;
using UnityEngine;
using Zenject;

public class AppInstasller : MonoInstaller
{
    [SerializeField] private ThemeChangePoint _themeChangePoint;
    [SerializeField] private LanguagesContainer _languagesContainer;
    [SerializeField] private CurrencyContainer _currencyContainer;
    [SerializeField] private CurrencyAdder _currencyAdder;

    private Services Services;

    public override void InstallBindings()
    {
        Container.Bind<SaverLoader>().FromNew().AsSingle().NonLazy();
        Container.Bind<ThemeChangePoint>().FromInstance(_themeChangePoint).AsSingle().Lazy();
        Container.Bind<LanguagesContainer>().FromInstance(_languagesContainer).AsSingle().NonLazy();
        Container.Bind<CurrencyContainer>().FromInstance(_currencyContainer).AsSingle().NonLazy();
        Services = new();
        Services.ThemeChangePoint = _themeChangePoint;
        Services.CurrencyAdder = _currencyAdder;
    }
}
