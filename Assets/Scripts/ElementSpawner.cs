using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    [Header("Spawnpoints (Reihenfolge: Rechts, ObenRechts, ObenLinks, Links)")]
    public Transform[] spawnPoints; // 0 = Rechtsbogen, 1 = Oben Rechts, 2 = Oben Links, 3 = Linksbogen

    [Header("Objekte, die abgeschossen werden können")]
    public GameObject[] elementsToSpawn;

    [Header("Wurfeinstellungen")]
    public float launchForce = 10f;
    public float arcAmount = 2f;

    void Start()
    {
        // Beim Start: einmal zufällig feuern
        FireRandom();
    }

    public void FireRandom()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject prefab = elementsToSpawn[Random.Range(0, elementsToSpawn.Length)];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Prefab hat kein Rigidbody2D.");
            return;
        }

        Vector2 force = Vector2.zero;

        // Richtung abhängig vom Spawnpoint
        switch (spawnIndex)
        {
            case 0: force = new Vector2(1f, 1f); break;    // Rechtsbogen
            case 1: force = new Vector2(0.3f, 1f); break;  // Oben mit leicht Rechts
            case 2: force = new Vector2(-0.3f, 1f); break; // Oben mit leicht Links
            case 3: force = new Vector2(-1f, 1f); break;   // Linksbogen
        }

        rb.AddForce(force.normalized * launchForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-arcAmount, arcAmount), ForceMode2D.Impulse);
    }
}
