using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> itemsToFind; // Список игровых объектов для поиска
    public float timeLimit = 60.0f; // Время для поиска в секундах
    private float currentTime; // Текущее время
    private int totalItemsFound; // Количество найденных объектов
    private bool isGameOver; // Флаг окончания игры
    public GameObject gameOverPanel; // Панель для отображения сообщения о конце игры
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
        // Показываем объекты для поиска на сцене
        foreach (GameObject item in itemsToFind)
        {
            item.SetActive(true);
            item.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void ItemFound(GameObject item)
    {
        // Обработка нахождения объекта для поиска
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
        // Обработка окончания игры
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}
