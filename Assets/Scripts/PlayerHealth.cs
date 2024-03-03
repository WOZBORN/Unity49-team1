using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText;

    void Start()
    {
        // При загрузке сцены пытаемся загрузить здоровье из сохранения
        LoadHealth();

        // Если здоровье не было загружено (например, первый запуск игры), устанавливаем максимальное здоровье
        if (currentHealth == 0)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика для смерти игрока
        Debug.Log("Игрок умер!");
        Destroy(gameObject); // Удаляем игрока из сцены
    }
    void OnDestroy()
    {
        // При уничтожении игрового объекта (например, при переходе на другую сцену) сохраняем здоровье
        SaveHealth();
    }
    void SaveHealth()
    {
        // Сохраняем текущее здоровье в PlayerPrefs
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.Save();
    }

    void LoadHealth()
    {
        // Пытаемся загрузить здоровье из PlayerPrefs
        currentHealth = PlayerPrefs.GetInt("PlayerHealth", 0);
    }
}
