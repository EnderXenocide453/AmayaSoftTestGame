using GridManagement.Data;
using GridManagement.Generation;
using System;
using System.Collections;
using UnityEngine;

namespace GridManagement
{
    public class LevelsIterator : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GridCellsData m_CellsData;
        [SerializeField] private GridSizeData[] m_GridLevels;
        [Header("Logic")]
        [SerializeField] private BaseGridGenerator m_GridGenerator;
        [SerializeField] private BaseGridVisualizer m_GridVisualizer;
        [SerializeField] private BaseQuestionVisualizer m_QuestionVisualizer;
        [Header("Misc.")]
        [SerializeField] private float m_LevelPassDelay = 1f;

        private int m_CurrentLevel;
        private GridGenerationData m_GridData;

        public event Action onIterationEnds;

        private void Start()
        {
            if (!ValidateData())
                return;
        }

        public void InitLevel(int id)
        {
            id = Mathf.Clamp(id, 0, m_GridLevels.Length - 1);

            m_GridData = m_GridGenerator.GenerateGrid(m_CellsData, m_GridLevels[id]);
            m_GridVisualizer.VisualizeGrid(m_GridData);
            m_QuestionVisualizer.VisualizeQuestion(m_GridData.CorrectCell.Name);

            m_CurrentLevel = id;
        }

        public void InitLevel(int id, GridCellsData gridCellsData)
        {
            m_CellsData = gridCellsData;
            InitLevel(id);
        }

        public void PassLevel()
        {
            StartCoroutine(WaitAndPass(m_LevelPassDelay));
        }

        public bool CheckIndex(Vector2Int index) => index == m_GridData.CorrectIndex;
        
        private void LoadNextLevel()
        {
            if (++m_CurrentLevel >= m_GridLevels.Length) {
                Win();
                return;
            }

            InitLevel(m_CurrentLevel);
        }

        private void Win()
        {
            onIterationEnds?.Invoke();
        }

        private IEnumerator WaitAndPass(float delay)
        {
            yield return new WaitForSeconds(delay);

            LoadNextLevel();
        }

        private bool ValidateData()
        {
            bool isValid = true;

            if (m_CellsData == null) {
                Debug.LogError("�� ������� ������ ���������� �����!");
                isValid = false;
            }
            if (m_GridLevels == null) {
                Debug.LogError("�� ������� ������ �������!");
                isValid = false;
            }
            if (m_GridGenerator == null) {
                Debug.LogError("�� �������� ��������� �����!");
                isValid = false;
            }
            if (m_GridVisualizer == null) {
                Debug.LogError("�� �������� ������������ �����!");
                isValid = false;
            }
            if (m_QuestionVisualizer == null) {
                Debug.LogError("�� �������� ������������ �������!");
                isValid = false;
            }

            return isValid;
        }
    }
}

