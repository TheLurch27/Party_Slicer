using UnityEngine;

public class EmojiSpawner : MonoBehaviour
{
    public GameObject[] emojiPrefabs;
    public Transform[] spawners;
    public float spawnInterval = 1.0f;
    public float spawnForce = 500f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEmoji();
            timer = 0f;
        }
    }

    void SpawnEmoji()
    {
        int randomSpawnerIndex = Random.Range(0, spawners.Length);
        Transform spawnPoint = spawners[randomSpawnerIndex];

        int randomEmojiIndex = Random.Range(0, emojiPrefabs.Length);
        GameObject emoji = Instantiate(emojiPrefabs[randomEmojiIndex], spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = emoji.GetComponent<Rigidbody2D>();

        switch (randomSpawnerIndex)
        {
            case 0:
                rb.AddForce(new Vector2(1f, 1f).normalized * spawnForce);
                break;
            case 1:
                rb.AddForce(new Vector2(0.5f, 1f).normalized * spawnForce);
                break;
            case 2:
                rb.AddForce(new Vector2(-0.5f, 1f).normalized * spawnForce);
                break;
            case 3:
                rb.AddForce(new Vector2(-1f, 1f).normalized * spawnForce);
                break;
        }
    }
}
