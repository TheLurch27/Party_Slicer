using UnityEngine;

public class SlashController : MonoBehaviour
{
    public GameObject slashLinePrefab;
    public float lineLifetime = 1f;

    private bool isDrawing = false;
    private GameObject currentLine;
    private LineRenderer lineRenderer;
    private float timer;
    public static bool isSlicing = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlash();
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            UpdateSlash();
        }

        if (isDrawing)
        {
            timer += Time.deltaTime;
            if (timer >= lineLifetime)
            {
                EndSlash();
            }
        }
    }

    void StartSlash()
    {
        currentLine = Instantiate(slashLinePrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, mousePos);

        isDrawing = true;
        isSlicing = true; // NEU!
        timer = 0f;
    }

    void UpdateSlash()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
    }

    void EndSlash()
    {
        if (currentLine != null)
        {
            currentLine.GetComponent<LineFadeOut>().StartFading();
        }
        isDrawing = false;
        isSlicing = false; // NEU!
    }
}
