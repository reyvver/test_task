using System;
using UnityEngine;

namespace Bits
{
    [RequireComponent(typeof(BitMovement))]
    public class BitDynamic : Bit
    {
        public event Action<BitDynamic> BitStopped;
        public bool WrongBit { get; private set; }
        private BitMovement _movement;

        protected override void Init()
        {
            base.Init();
            
            if (TryGetComponent(out BitMovement movement))
            {
                _movement = movement;
                _movement.Init();
            }
        }
        
        public void Activate(Color32 color, int points, bool wrong)
        {
            BitPoints = points;
            WrongBit = wrong;
            SetColor(color);
        
            _movement.SetStartPosition();
            _movement.StartMotion();
        }
        
        private void SetColor(Color32 color)
        {
            color.a = 255;
            SpriteRenderer.color = color;
        }
    
        public void Deactivate()
        {
            _movement.StopMotion();
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            Deactivate();
            BitStopped?.Invoke(this);
        }
    }
}