using UnityEngine;
//Spawns the enemies
public class EnemySpawnerET : MonoBehaviour
{
    public GameObject redEnemyPrefab;
    public GameObject blueEnemyPrefab;
    public Transform spawn;

    public void SpawnRed()
    {
        SpawnEnemy(redEnemyPrefab, "Red");
        Debug.Log("Added Red Enemy");
    }

    public void SpawnBlue()
    {
        SpawnEnemy(blueEnemyPrefab, "Blue");
        Debug.Log("Added Blue Enemy");
    }

    private void SpawnEnemy(GameObject prefab, string typeName)
    {

        GameObject newEnemy = Instantiate(prefab, spawn.position, spawn.rotation ); //spawn

        EnemyTracker.Instance.AddTarget(newEnemy, typeName); //add the enemy to the list in EnemyTracker
    }
}