using UnityEngine;
using GridManagement.Data;
using GridManagement.Generation;
using GridManagement.UI;
using System.Collections;
using System;
using UnityEngineInternal;

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
        private bool m_FirstInit = true;
        private GridGenerationData m_GridData;

        public bool IsFirstInit => m_FirstInit;

        public event Action onWin;

        private void Start()
        {
            if (!ValidateData())
                return;

            InitLevel(0);
        }

        public void OnCellSelected(GridCellButton cellButton)
        {
            if (cellButton.Index == m_GridData.CorrectIndex) {
                cellButton.Animation.PlayApplyAnimation();
                PassLevel();

                return;
            }

            cellButton.Animation.PlayDenyAnimation();
        }

        public void Restart()
        {
            InitLevel(0);
        }

        private void InitLevel(int id)
        {
            id = Mathf.Clamp(id, 0, m_GridLevels.Length - 1);

            m_GridData = m_GridGenerator.GenerateGrid(m_CellsData, m_GridLevels[id]);
            m_GridVisualizer.VisualizeGrid(m_GridData);
            m_QuestionVisualizer.VisualizeQuestion(m_GridData.CorrectCell.Name);

            m_CurrentLevel = id;
            m_FirstInit = false;
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
            if (++m_CurrentLevel >= m_GridLevels.Length) {
                Win();
                return;
            }

            InitLevel(m_CurrentLevel);
        }

        private void Win()
        {
            onWin?.Invoke();
        }

        private bool ValidateData()
        {
            bool isValid = true;

            if (m_CellsData == null) {
                Debug.LogError("Не указаны данные наполнения ячеек!");
                isValid = false;
            } if (m_GridLevels == null) {
                Debug.LogError("Не указаны данные уровней!");
                isValid = false;
            } if (m_GridGenerator == null) {
                Debug.LogError("Не назначен генератор сетки!");
                isValid = false;
            } if (m_GridVisualizer == null) {
                Debug.LogError("Не назначен визуализатор сетки!");
                isValid = false;
            } if (m_QuestionVisualizer == null) {
                Debug.LogError("Не назначен визуализатор вопроса!");
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

