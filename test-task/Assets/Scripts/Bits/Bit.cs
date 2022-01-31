using System;
using CustomInput;
using UnityEngine;

namespace Bits
{
    public class Bit : MonoBehaviour
    {
        public event Action<Bit> BitClicked; 
        public int BitPoints { get; protected set; }

        private Collider2D _collider2D;
        protected SpriteRenderer SpriteRenderer;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            _collider2D = GetComponent<Collider2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input2D.Raycast2D() == _collider2D)
            {
                BitClicked?.Invoke(this);
            }
        }
    }
}
