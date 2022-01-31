using System.Collections.Generic;
using UnityEngine;

namespace Bits
{
    public class BitsCreator : MonoBehaviour
    {
        private readonly Queue<GameObject> _objectPool = new Queue<GameObject>();

        private GameObject _prefab;
        private Transform _parent;

        public void Init(GameObject prefab, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public void SetStartPoolCapacity(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObject newBit = CreateNewObject();
                _objectPool.Enqueue(newBit);
            }
        }

        private GameObject CreateNewObject()
        {
            GameObject newObj = Instantiate(_prefab, _parent);
            newObj.name = _prefab.name;
            return newObj;
        }

        public void Return(GameObject obj)
        {
            if (_objectPool.Contains(obj)) return;
            _objectPool.Enqueue(obj);
        }

        public GameObject Get()
        {
            if (_objectPool.Count == 0){ return CreateNewObject();}

            return _objectPool.Dequeue();
        }
    }
}
