using UnityEngine;

public class SliceableEmoji : MonoBehaviour
{
    public GameObject leftHalfPrefab;
    public GameObject rightHalfPrefab;
    public GameObject splatterPrefab;
    public GameObject[] bloodStainPrefabs; // NEU: Array für Flecken
    public float splitForce = 5f;

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && SlashController.isSlicing)
        {
            SpawnHalves();
            SpawnSplatter();
            SpawnBloodStain();
            Destroy(gameObject);
        }
    }

    void SpawnHalves()
    {
        Vector2 spawnPosition = transform.position;

        GameObject leftHalf = Instantiate(leftHalfPrefab, spawnPosition, Quaternion.identity);
        GameObject rightHalf = Instantiate(rightHalfPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D leftRb = leftHalf.GetComponent<Rigidbody2D>();
        Rigidbody2D rightRb = rightHalf.GetComponent<Rigidbody2D>();

        if (leftRb != null)
            leftRb.AddForce(new Vector2(-1, 1) * splitForce, ForceMode2D.Impulse);
        if (rightRb != null)
            rightRb.AddForce(new Vector2(1, 1) * splitForce, ForceMode2D.Impulse);
    }

    void SpawnSplatter()
    {
        Instantiate(splatterPrefab, transform.position, Quaternion.identity);
    }

    void SpawnBloodStain()
    {
        if (bloodStainPrefabs.Length == 0)
            return;

        int randomIndex = Random.Range(0, bloodStainPrefabs.Length);
        GameObject bloodStain = Instantiate(bloodStainPrefabs[randomIndex], transform.position, Quaternion.identity);

        // OPTIONAL: Blutfleck leicht drehen für Variation
        bloodStain.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}
