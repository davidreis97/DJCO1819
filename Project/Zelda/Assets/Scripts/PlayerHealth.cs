using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject heartPrefab;
    public GameObject heartContainer;

    public GameObject nokey;
    public GameObject key;
    public bool playerHasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab);
            heart.transform.SetParent(heartContainer.transform);
            heart.name = "heart_" + i; //Permite depois obter o coração certo <3 na função UpdateHearts
            heart.GetComponent<RectTransform>().anchoredPosition = new Vector3(45 + 45 * i, -42);
            heart.GetComponent<Heart>().SetFull();
            heart.transform.localScale = new Vector3(42, 42, 1);
        }
    }

    public void PlayerHasKey()
    {
        playerHasKey = true;
        nokey.SetActive(false);
        key.SetActive(true);
    }

    void UpdateHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = GameObject.Find("heart_" + i); // <3
            if (i < currentHealth)
            {
                heart.GetComponent<Heart>().SetFull();
            }
            else
            {
                heart.GetComponent<Heart>().SetEmpty();
            }
        }
    }

    public void TakeHit(int hearts)
    {
        currentHealth -= hearts;
        UpdateHearts();
        if(currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver"); // Create Game Over Menu
        }
    }

    public void HealUp(int hearts)
    {
        currentHealth += hearts;
        UpdateHearts();
    }
}
