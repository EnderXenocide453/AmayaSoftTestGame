using UnityEngine;
using GridManagement.Data;
using GridManagement.Generation;
using GridManagement.UI;
using System.Collections;

namespace GridManagement
{
    public class GridExecutionHandler : MonoBehaviour
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

        private void Start()
        {
            if (!ValidateData())
                return;

            InitLevel(0);
        }

        public void OnCellSelected(GridCellButton cellButton)
        {
            if (cellButton.Index == m_GridData.CorrectIndex) {
                cellButton.PlayApplyAnimation();
                PassLevel();

                return;
            }

            cellButton.PlayDenyAnimation();
        }

        private void InitLevel(int id)
        {
            id %= m_GridLevels.Length;

            m_GridData = m_GridGenerator.GenerateGrid(m_CellsData, m_GridLevels[id]);
            m_GridVisualizer.VisualizeGrid(m_GridData);
            m_QuestionVisualizer.VisualizeQuestion(m_GridData.CorrectCell.Name);

            m_CurrentLevel = id;
        }

        private void InitLevel(int id, GridCellsData gridCellsData)
        {
            m_CellsData = gridCellsData;
            InitLevel(id);
        }

        private void PassLevel()
        {
            StartCoroutine(WaitAndPass(m_LevelPassDelay));
        }

        private void LoadNextLevel()
        {
            InitLevel(m_CurrentLevel + 1);
        }

        private bool ValidateData()
        {
            bool isValid = true;

            if (m_CellsData == null) {
                Debug.LogError("�� ������� ������ ���������� �����!");
                isValid = false;
            } if (m_GridLevels == null) {
                Debug.LogError("�� ������� ������ �������!");
                isValid = false;
            } if (m_GridGenerator == null) {
                Debug.LogError("�� �������� ��������� �����!");
                isValid = false;
            } if (m_GridVisualizer == null) {
                Debug.LogError("�� �������� ������������ �����!");
                isValid = false;
            } if (m_QuestionVisualizer == null) {
                Debug.LogError("�� �������� ������������ �������!");
                isValid = false;
            }

            return isValid;
        }

        private IEnumerator WaitAndPass(float delay)
        {
            yield return new WaitForSeconds(delay);

            LoadNextLevel();
        }
    }
}

