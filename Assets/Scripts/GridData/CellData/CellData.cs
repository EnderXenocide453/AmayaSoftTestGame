using System;
using UnityEngine;

namespace GridManagement.Data
{
    [Serializable]
    public class CellData
    {
        [SerializeField] private string m_Name;
        [SerializeField] private Sprite m_Sprite;
        [SerializeField] private float m_CompensationAngle;

        public string Name => m_Name;
        public Sprite Sprite => m_Sprite;
        public float CompensationAngle => m_CompensationAngle;
    }
}

