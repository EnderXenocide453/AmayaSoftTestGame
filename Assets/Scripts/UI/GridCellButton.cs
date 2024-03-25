using GridManagement.Animations;
using GridManagement.Data;
using System;
using UnityEngine;

namespace GridManagement.UI
{
    [RequireComponent(typeof(GridCellButtonAnimation))]
    public class GridCellButton : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_IconRenderer;
        
        private Vector2Int m_Index;
        private GridCellButtonAnimation m_Animation;

        public Vector2Int Index => m_Index;
        public GridCellButtonAnimation Animation => m_Animation ??= GetComponent<GridCellButtonAnimation>();

        public event Action<GridCellButton> OnClick;

        public void SetData(CellData data, Vector2Int index)
        {
            m_IconRenderer.sprite = data.Sprite;
            m_Index = index;

            m_IconRenderer.transform.Rotate(0, 0, data.CompensationAngle);
        }

        public void SetOnClickAction(Action<GridCellButton> onClick)
        {
            OnClick += onClick;
        }

        private void OnMouseDown()
        {
            OnClick?.Invoke(this);
        }
    }
}

