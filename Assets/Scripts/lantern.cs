using UnityEngine;
using TMPro;

public class lantern : MonoBehaviour
{
    // ������ �� ������, ������� �� ����� ��������/���������
    public GameObject objectToToggle;

    // ������ �� ��������� ��� ������
    public TextMeshProUGUI playerMessage;

    // ����, ����� �����������, ���� �� ��� ������� ������� G
    private bool gPressed = false;

    // ����� Update ���������� ������ ����
    void Update()
    {
        // ���������, ���� �� ������ ������� G � �� ���� �� ��� ������� �����
        if (Input.GetKeyDown(KeyCode.G) && !gPressed)
        {
            // ������������� ���� ������� ������� G � true
            gPressed = true;

            // ���������, ���� �� ��������� ��� ������ � �������� ���
            if (playerMessage != null)
            {
                playerMessage.gameObject.SetActive(false);
            }

            // ���� ������ �������, �� ��������� ���; ����� - ��������
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }

        // ���� ������� G ���� ��������, ���������� ���� ������� ������� G
        if (Input.GetKeyUp(KeyCode.G))
        {
            gPressed = false;
        }
    }
}
