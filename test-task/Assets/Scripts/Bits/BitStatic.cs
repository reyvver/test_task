using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Bits
{
    public class BitStatic : Bit
    {
        [SerializeField] private float timeToFade = 2f;
        [SerializeField] private float timeToWait = 5f;

        [SerializeField] private Color32 regularColor;
        [SerializeField] private Color32 activeColor;

        [SerializeField] private ParticleSystem effect;
        public bool Active { get; private set; }

        protected override void Init()
        {
            base.Init();

            BitPoints = 100;
            regularColor.a = 255;
            activeColor.a = 255;

            BitClicked += OnBitClicked;
        }

        public void StartColorChange()
        {
            Active = false;
            StartCoroutine(ColorChange());
        }

        public void StopColorChange()
        {
            StopAllCoroutines();
            if (SpriteRenderer == null)
                SpriteRenderer = GetComponent<SpriteRenderer>();
            
            SpriteRenderer.DOKill();
            SpriteRenderer.color = regularColor;
        }

        private IEnumerator ColorChange()
        {
            while (true)
            {
                ChangeBitColor(activeColor, timeToFade, true);
                yield return new WaitForSeconds(timeToWait + timeToFade);
                
                SetInteractable(false);
                
                ChangeBitColor(regularColor, timeToFade, false);
                yield return new WaitForSeconds(timeToFade);
            }
        }

        private void ChangeBitColor(Color32 color, float time, bool interactable = false)
        {
            SpriteRenderer.DOColor(color, time).OnComplete(()=>SetInteractable(interactable));
            SpriteRenderer.material.DOColor(color, "_EmissionColor", time);
        }

        private void SetInteractable(bool value)
        {
            Active = value;
            
            if (value) effect.Play();
            else effect.Stop();
        }

        private void OnBitClicked(Bit bit)
        {
            if (!Active) return;

            SetInteractable(false);
            ChangeBitColor(regularColor, timeToFade / 2);
        }
    }
}