using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText;

    void Start()
    {
        // ��� �������� ����� �������� ��������� �������� �� ����������
        LoadHealth();

        // ���� �������� �� ���� ��������� (��������, ������ ������ ����), ������������� ������������ ��������
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
        // ������ ��� ������ ������
        Debug.Log("����� ����!");
        Destroy(gameObject); // ������� ������ �� �����
    }
    void OnDestroy()
    {
        // ��� ����������� �������� ������� (��������, ��� �������� �� ������ �����) ��������� ��������
        SaveHealth();
    }
    void SaveHealth()
    {
        // ��������� ������� �������� � PlayerPrefs
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.Save();
    }

    void LoadHealth()
    {
        // �������� ��������� �������� �� PlayerPrefs
        currentHealth = PlayerPrefs.GetInt("PlayerHealth", 0);
    }
}
