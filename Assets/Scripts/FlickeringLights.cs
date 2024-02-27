using UnityEngine;
using System.Collections;


public class FlickeringLights : MonoBehaviour
{
    public Light[] lights; // Массив всех световых источников, которые будут мигать
    public float minIntensity = 0.25f; // Минимальная интенсивность света во время мерцания
    public float maxIntensity = 1.0f; // Максимальная интенсивность света во время мерцания
    public float flickerSpeed = 0.1f; // Скорость мерцания

    private float randomFlicker;

    void Start()
    {
        // Инициализация значений мерцания
        randomFlicker = Random.Range(0.0f, 1.0f);

        // Запуск корутины для мерцания световых источников
        StartCoroutine(FlickerLights());
    }

    IEnumerator FlickerLights()
    {
        while (true)
        {
            // Вычисляем новые значения интенсивности для каждого светового источника
            foreach (Light light in lights)
            {
                float flickerIntensity = Mathf.Lerp(minIntensity, maxIntensity, randomFlicker);
                light.intensity = flickerIntensity;

                // Генерируем новое случайное значение для следующего цикла мерцания
                randomFlicker = Random.Range(0.0f, 1.0f);
            }

            // Ждем некоторое время перед следующим циклом мерцания
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
