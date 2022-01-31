using System;
using CustomInput;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bits
{
    public class BitMovement : MonoBehaviour
    {
        [SerializeField] private float minSpeed = 2;
        [SerializeField] private float maxSpeed = 5;

        private const float SpaceFromTop = 2.5f;
        private const float SpaceFromBottom = 2f;

        private Vector2 _hiddenPos;

        public void Init()
        {
            _hiddenPos = new Vector2(Input2D.ScreenValueX * 1.25f,0);
            transform.position = _hiddenPos;
        }
    
        public void SetStartPosition()
        {
            Vector2 pos = transform.position;
            int randomSign = Random.value > 0.5f ? 1 : -1;
        
            pos.x *= randomSign;
            pos.y = Random.Range(-Input2D.ScreenValueY + SpaceFromBottom, Input2D.ScreenValueY - SpaceFromTop);
            
            transform.position = pos;
        }

        public void StartMotion()
        {
            float speed = Random.Range(minSpeed, maxSpeed);
            float path = Input2D.ScreenValueX * 1.45f + Input2D.ScreenValueX * 1.25f;
            float time = path / speed;
            
            transform.DOMoveX(-1 * Input2D.ScreenValueX * 1.45f * Math.Sign(transform.position.x), time);
            GoUp(time/5);
        }

        public void StopMotion()
        {
            transform.DOKill();
            transform.position = _hiddenPos;
        }

        private void GoUp(float time)
        {
            transform.DOMoveY(transform.position.y + 1, time).OnComplete(()=>GoDown(time));
        }

        private void GoDown(float time)
        {
            transform.DOMoveY(transform.position.y - 1, time).OnComplete(()=>GoUp(time));
        }
        
    }
}
