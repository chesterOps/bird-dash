using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> _blockContainers = new();
    private int amountToPool = 8;
    [SerializeField] private GameObject _blockContainer;

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Pre-instantiate block containers and add them to the pool
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(_blockContainer);
            obj.transform.parent = transform;
            obj.SetActive(false);
            _blockContainers.Add(obj);
        }
    }


    public GameObject GetBlockContainer()
    {
        // Retrieve an inactive block container from the pool
        for (int i = 0; i < _blockContainers.Count; i++)
        {
            if (!_blockContainers[i].activeInHierarchy)
            {
                return _blockContainers[i];
            }
        }
        return null;
    }
}
