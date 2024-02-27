using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour
{
    public RectTransform creditsTransform; // ������ �� RectTransform ������ ������
    public float scrollSpeed = 20f; // �������� ��������� ������
    public float initialDelay = 3f; // �������� ����� ������� ���������
    public float watch = 1100; // �������, �� �������� ����� ���������� �����

    private void Start()
    {
        // ��������� �������� ��� ��������� ������
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        // �������� ����� ������� ���������
        yield return new WaitForSeconds(initialDelay);

        // ����������� ���� ��������� ������
        while (true)
        {
            // ����������� ������� ������ �� ���������
            creditsTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

            // ���� ����� �������� �� �����, ������� �� �����
            if (creditsTransform.anchoredPosition.y >= watch)
            {
                break;
            }

            yield return null;
        }
        // ���� 3 ������� ����� ������� �� ����
        yield return new WaitForSeconds(3f);

        // ����� �� ����
        Application.Quit();
    }
}
