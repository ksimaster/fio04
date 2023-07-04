using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> itemsToFind; // ������ ������� �������� ��� ������
    public float timeLimit = 60.0f; // ����� ��� ������ � ��������
    private float currentTime; // ������� �����
    private int totalItemsFound; // ���������� ��������� ��������
    private bool isGameOver; // ���� ��������� ����
    public GameObject gameOverPanel; // ������ ��� ����������� ��������� � ����� ����
    public TMP_Text timerText;
    public TMP_Text itemText;

    void Start()
    {
        currentTime = timeLimit;
        totalItemsFound = 0;
        isGameOver = false;
        DisplayItems();
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            timerText.text = ((int)currentTime).ToString();
            if (currentTime <= 0)
            {
                GameOver();
            }
        }
    }

    void DisplayItems()
    {
        // ���������� ������� ��� ������ �� �����
        foreach (GameObject item in itemsToFind)
        {
            item.SetActive(true);
            item.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void ItemFound(GameObject item)
    {
        // ��������� ���������� ������� ��� ������
        if (itemsToFind.Contains(item))
        {
            totalItemsFound++;
            itemText.text = totalItemsFound.ToString();
            itemsToFind.Remove(item);
            item.SetActive(false);

            if (itemsToFind.Count == 0)
            {
                GameOver();
            }
        }
    }

    private void OnMouseDown()
    {
        
    }

    void GameOver()
    {
        // ��������� ��������� ����
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}
