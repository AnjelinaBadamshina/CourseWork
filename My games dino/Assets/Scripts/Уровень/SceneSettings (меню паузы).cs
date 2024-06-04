using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public GameObject PausePanel;

    public WaterRiseController waterRiseController;

    // ���������� ���������� ���� ��� �� ����
    void Update()
    {
        // ���� ������ ������� Esc, �������� ������� TogglePause()
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }


    // ����� ���������� ��� ������� �� ������ �����
    public void PauseButtonPressed()
    {
        TogglePause();
    }

    // ����� ���������� ��� ������� �� ������ ����������
    public void ContinueButtonPressed()
    {
        TogglePause();

    }

    // ����� ���������� ��� ������� �� ������ ������������
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // ��������� ������� ���� � ���������� ��������
    }

    // ����� ���������� ��� ������� �� ������ ����� �����
    public void ChangeScene()
    {
        SceneManager.LoadScene(2); // �������� ������ �����
        Time.timeScale = 1f; // ��������� ������� ���� � ���������� ��������
    }

    // ����� ��� �������� � �������� �����
    void TogglePause()
    {
        bool isPaused = PausePanel.activeSelf; // ���������, ������� �� ������ �����
        PausePanel.SetActive(!isPaused); // ����������� ���������� ������ �����
        Time.timeScale = isPaused ? 1f : 0f; // ���� ���� ���� �� �����, ������������� ���������� �����, ����� - ������������� �����

        if (waterRiseController != null)
        {
            if (isPaused)
            {
                // ���� ���� ���� �� �����, ���������� ������
                waterRiseController.ResumeAndShowTimer();
            }
            else
            {
                // ���� ���� �� ���� �� �����, ������������� ������
                waterRiseController.StopAndHideTimer();
            }

        }

    }
}
