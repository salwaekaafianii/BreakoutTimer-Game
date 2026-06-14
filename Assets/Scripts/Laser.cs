using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float activeTime = 8f;
    public float inactiveTime = 8f;

    public GameObject gameOverPanel;

    private Renderer laserRenderer;
    private Collider laserCollider;

    private bool isGameOver = false;

    void Start()
    {
        laserRenderer = GetComponent<Renderer>();
        laserCollider = GetComponent<Collider>();

        StartCoroutine(LaserLoop());
    }

    IEnumerator LaserLoop()
    {
        while (true)
        {
            laserRenderer.enabled = true;
            laserCollider.enabled = true;

            yield return new WaitForSeconds(activeTime);

            laserRenderer.enabled = false;
            laserCollider.enabled = false;

            yield return new WaitForSeconds(inactiveTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameOver)
        {
            isGameOver = true;

            gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}