using UnityEngine;

public abstract class PageMediaCoreBase : MonoBehaviour
{
    [field: SerializeField] public PageMediaPackDataBase Data { get; protected set; }

    [SerializeField] protected PageMediaDataViewBase _view;

    public bool SearchDisplayable { get; set; } = true;

    public virtual void Initialize()
    {
        SearchDisplayable = true;
        _view.UnboxMediaViewInList();
    }

    protected virtual void OnValidate() =>
        _view ??= GetComponent<PageMediaDataViewBase>();
}

