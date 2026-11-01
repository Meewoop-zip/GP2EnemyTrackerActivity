using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance { get; private set; }

    private List<GameObject> activeEnemies = new List<GameObject>();
    public TextMeshProUGUI enemyList;
    private int enemyCounter = 0;

    private void Awake() //prevents multiple instances of the EnemyTracker from existing in the scene.
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        UpdateUI();
    }

    public void AddTarget(GameObject enemy, string typeName) //add the spawned enemy to the list and updates the UI
    {
        enemyCounter++;
        enemy.name = typeName + " Enemy_" + enemyCounter;

        activeEnemies.Add(enemy);
        UpdateUI();
    }

    //remove enemy type
    public void DefeatRed() 
    {
        DefeatTarget("Red Enemy"); 
    }

    public void DefeatBlue()
    {
        DefeatTarget("Blue Enemy");
    }

    public void DefeatTarget(string typeName)
    {
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (activeEnemies[i] != null && activeEnemies[i].name.Contains(typeName))
            {
                GameObject target = activeEnemies[i];
                activeEnemies.RemoveAt(i);
                Destroy(target);
                Debug.Log($"Removed {target.name}");
                UpdateUI();
                return;
            }
        }

        Debug.LogWarning($"No {typeName} found in the list.");
    }

    //reset all
    public void ResetWave()
    {

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (activeEnemies[i] != null)
            {
                Destroy(activeEnemies[i]);
            }
        }

        activeEnemies.Clear(); //clears the list 
        enemyCounter = 0;
        Debug.Log("Wave Reset");
        UpdateUI();
    }


    private void UpdateUI()
    {
        

        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
            }
            
        }

        enemyList.text = "Active Enemies: " + activeEnemies.Count + "\n";

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            enemyList.text += $"- {activeEnemies[i].name}\n";
        }

    }



}