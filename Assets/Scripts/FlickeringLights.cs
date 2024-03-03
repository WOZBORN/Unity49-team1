using UnityEngine;
using System.Collections;


public class FlickeringLights : MonoBehaviour
{
    public Light[] lights; // ������ ���� �������� ����������, ������� ����� ������
    public float minIntensity = 0.25f; // ����������� ������������� ����� �� ����� ��������
    public float maxIntensity = 1.0f; // ������������ ������������� ����� �� ����� ��������
    public float flickerSpeed = 0.1f; // �������� ��������

    private float randomFlicker;

    void Start()
    {
        // ������������� �������� ��������
        randomFlicker = Random.Range(0.0f, 1.0f);

        // ������ �������� ��� �������� �������� ����������
        StartCoroutine(FlickerLights());
    }

    IEnumerator FlickerLights()
    {
        while (true)
        {
            // ��������� ����� �������� ������������� ��� ������� ��������� ���������
            foreach (Light light in lights)
            {
                float flickerIntensity = Mathf.Lerp(minIntensity, maxIntensity, randomFlicker);
                light.intensity = flickerIntensity;

                // ���������� ����� ��������� �������� ��� ���������� ����� ��������
                randomFlicker = Random.Range(0.0f, 1.0f);
            }

            // ���� ��������� ����� ����� ��������� ������ ��������
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
