using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bits
{
    [RequireComponent(typeof(BitsCreator))]
    public class BitsCollection : MonoBehaviour
    {
        public event Action<int> UpdatePlayerScore;
        public static event Action WrongBitClicked;
        
        private BitsCreator _creator;
        private const int StartBitsCount = 10;

        [Serializable]
        struct BitsType
        {
            public bool wrong;
            public int bitValue;
            public Color32 bitColor;
        }

        [SerializeField] private List<BitsType> availableTypes;
        private List<BitDynamic> _activeBits;

        public void Init(GameObject prefab, Transform container = null)
        {
            _activeBits = new List<BitDynamic>();
            InitCreator(prefab, container);
        }
    
        private void InitCreator(GameObject prefab, Transform container = null)
        {
            _creator = GetComponent<BitsCreator>();
            _creator.Init(prefab, container);
            _creator.SetStartPoolCapacity(StartBitsCount);
        }
        
        public void CreateNewBit()
        {
            BitDynamic bit = _creator.Get().GetComponent<BitDynamic>();
            BitsType type = GetRandomType();

            bit.BitClicked += OnBitClicked;
            bit.BitStopped += ReturnToPool;
            bit.Activate(type.bitColor, type.bitValue, type.wrong);
        
            _activeBits.Add(bit);
        }
    
        private BitsType GetRandomType()
        {
            if (availableTypes.Count == 0)
            {
                throw new Exception("Bits types are not created");
            }

            int index = Random.Range(0, availableTypes.Count);
            return availableTypes[index];
        }

        public void StopAll()
        {
            foreach (var bit in _activeBits.ToList())
            {
                StopBit(bit);
            }
        }

        private void OnBitClicked(Bit bit)
        {
            BitDynamic dynamic = (BitDynamic)bit;
            StopBit(dynamic);
            UpdatePlayerScore?.Invoke(bit.BitPoints);
            
            if (dynamic.WrongBit)
                WrongBitClicked?.Invoke();
        }

        private void StopBit(BitDynamic bit)
        {
            bit.Deactivate();
            ReturnToPool(bit);
        }

        private void ReturnToPool(BitDynamic bit)
        {
            _creator.Return(bit.gameObject);
            _activeBits.Remove(bit);
        }
    }
}