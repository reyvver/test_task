using CustomInput;
using UnityEngine;

namespace Other
{
    public class StopBlock : MonoBehaviour
    {
        [SerializeField] private StopBlockSide side;
        private enum StopBlockSide
        {
            Left,
            Right
        }
        private void Awake()
        {
            ChangeSize();
            ChangePosition();
        }
        private void ChangeSize()
        {
            Vector3 newScale = transform.localScale;
            newScale.y = Input2D.ScreenValueY * 2;

            transform.localScale = newScale;
        }
        private void ChangePosition()
        {
            Vector2 newPosition = new Vector2(Input2D.ScreenValueX * 1.45f, 0);
            newPosition.x = side == StopBlockSide.Left ? newPosition.x : -newPosition.x;
        
            transform.position = newPosition;
        }
    }
}
