using UnityEngine;

public class PageMediaCoreContainer : MonoBehaviour
{
    public PageMediaCoreBase[] Cores { get; private set; }

    public void Initialize()
    {
        Cores = GetComponentsInChildren<PageMediaCoreBase>();
        foreach (var core in Cores)
        {
            core.Initialize();
            core.gameObject.SetActive(false);
        }
    }
}

