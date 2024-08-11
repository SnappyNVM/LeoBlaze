using UnityEngine;
using UnityEngine.Events;

public class GroupGameObjectSwapper : MonoBehaviour
{
    [SerializeField] private GameObject[] _toSwap;
    [SerializeField] private int _startActiveId = 0;
    [SerializeField] private bool _hasStartActive;

    public UnityEvent<GameObject> GroupObjectSwapped;

    private void Start()
    {
        DisableAll();

        if (_hasStartActive)
            _toSwap[_startActiveId].SetActive(true);
        GroupObjectSwapped?.Invoke(_toSwap[_startActiveId]);
    }

    public void SwapGameObject(int id)
    {
        DisableAll();
        _toSwap[id].SetActive(true);
        GroupObjectSwapped?.Invoke(_toSwap[id]);
    }

    public void DisableAll()
    {
        foreach (var gameObject in _toSwap)
            gameObject.SetActive(false);
    }
}
