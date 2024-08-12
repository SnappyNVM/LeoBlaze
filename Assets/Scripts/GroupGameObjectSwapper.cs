using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GroupGameObjectSwapper : MonoBehaviour
{
    [SerializeField] private GameObject[] _toSwap;
    [SerializeField] private int _startActiveId = 0;
    [SerializeField] private bool _hasStartActive = false;
    [SerializeField] private bool _hasStartActiveReverse = false;

    public UnityEvent<GameObject> GroupObjectSwapped;

    private void Start()
    {
        DisableAll();

        if (_hasStartActive)
            _toSwap[_startActiveId].SetActive(true);
        if (_hasStartActiveReverse)
            ReverseSwapGameObject(_startActiveId);
        GroupObjectSwapped?.Invoke(_toSwap[_startActiveId]);
    }

    public void SwapGameObject(int id)
    {
        DisableAll();
        _toSwap[id].SetActive(true);
        GroupObjectSwapped?.Invoke(_toSwap[id]);
    }

    public void ReverseSwapGameObject(int id)
    {
        foreach (var elem in _toSwap)
            elem.SetActive(true);
        _toSwap[id].SetActive(false);
        GroupObjectSwapped?.Invoke(_toSwap[id]);
    }

    public void SwitchToNext()
    {
        var last = _toSwap.Last();
        if (last.activeSelf)
        {
            _toSwap.First().SetActive(true);
            last.SetActive(false);
        }
        else
        {
            for (int i = 0; i < _toSwap.Length; i++)
            {
                if (_toSwap[i].activeSelf)
                {
                    _toSwap[i].SetActive(false);
                    _toSwap[i + 1].SetActive(true);
                    break;
                } 
                    
            }
        }
    }

    public void DisableAll()
    {
        foreach (var elem in _toSwap)
            elem.SetActive(false);
    }

    private void OnValidate()
    {
        if (_hasStartActive && _hasStartActiveReverse)
            _hasStartActiveReverse = false;
    }
}
