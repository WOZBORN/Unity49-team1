using UnityEngine;
using UnityEngine.UI;

public class DoorPrompt : MonoBehaviour
{
    public Transform player;
    public Transform door;
    public float interactionDistance = 2f;
    public Text interactionText;
    public int sceneIndexToLoad = 1; // ������ ����� ��� �������� (1 � ������ ������)
    private bool canInteract = false;

    void Update()
    {
        float distance = Vector3.Distance(player.position, door.position);
        if (distance <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);
            canInteract = true;
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            canInteract = false;
        }

        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        // ��������� ����� � �������� sceneIndexToLoad �� Build Settings
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndexToLoad);
    }
}
