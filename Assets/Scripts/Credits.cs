using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour
{
    public RectTransform creditsTransform; // Ссылка на RectTransform текста титров
    public float scrollSpeed = 20f; // Скорость прокрутки текста
    public float initialDelay = 3f; // Задержка перед началом прокрутки
    public float watch = 1100; // Уровень, до которого нужно прокрутить текст

    private void Start()
    {
        // Запускаем корутину для прокрутки титров
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        // Задержка перед началом прокрутки
        yield return new WaitForSeconds(initialDelay);

        // Бесконечный цикл прокрутки текста
        while (true)
        {
            // Увеличиваем позицию текста по вертикали
            creditsTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

            // Если текст долистал до конца, выходим из цикла
            if (creditsTransform.anchoredPosition.y >= watch)
            {
                break;
            }

            yield return null;
        }
        // Ждем 3 секунды перед выходом из игры
        yield return new WaitForSeconds(3f);

        // Выход из игры
        Application.Quit();
    }
}
