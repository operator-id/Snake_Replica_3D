using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int spawnInterval = 5;

    private float nextSpawnTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            SpawnCoin();
        }
    }
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
    public void SpawnCoin()
    {
        Debug.Log("Coin Spawned!");

        nextSpawnTime = Time.time + spawnInterval;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;

        float tolerance = mesh.bounds.size.x / 8;

        Vector3 position = new Vector3(Random.Range(-bounds.size.x / 2 + tolerance, bounds.size.x / 2 - tolerance),
            bounds.size.y - coinPrefab.transform.localScale.y, Random.Range(-bounds.size.z / 2 + tolerance, bounds.size.z / 2 - tolerance));
        Transform food = (Instantiate(coinPrefab, position, Quaternion.identity) as GameObject).transform;


        food.SetParent(transform);

    }
}
