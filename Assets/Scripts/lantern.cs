using UnityEngine;
using TMPro;

public class lantern : MonoBehaviour
{
    // Ссылка на объект, который мы хотим включать/выключать
    public GameObject objectToToggle;

    // Ссылка на сообщение для игрока
    public TextMeshProUGUI playerMessage;

    // Флаг, чтобы отслеживать, было ли уже нажатие клавиши G
    private bool gPressed = false;

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // Проверяем, была ли нажата клавиша G и не было ли уже нажатия ранее
        if (Input.GetKeyDown(KeyCode.G) && !gPressed)
        {
            // Устанавливаем флаг нажатия клавиши G в true
            gPressed = true;

            // Проверяем, есть ли сообщение для игрока и скрываем его
            if (playerMessage != null)
            {
                playerMessage.gameObject.SetActive(false);
            }

            // Если объект включен, то выключаем его; иначе - включаем
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }

        // Если клавиша G была отпущена, сбрасываем флаг нажатия клавиши G
        if (Input.GetKeyUp(KeyCode.G))
        {
            gPressed = false;
        }
    }
}
