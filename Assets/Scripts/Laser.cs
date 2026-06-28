using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float activeTime = 8f;
    public float inactiveTime = 8f;

    public GameObject gameOverPanel;
    public AudioClip laserSound;

    private Renderer laserRenderer;
    private Collider laserCollider;

    private bool isGameOver = false;

    void Start()
    {
        laserRenderer = GetComponent<Renderer>();
        laserCollider = GetComponent<Collider>();

        gameOverPanel.SetActive(false);

        StartCoroutine(LaserLoop());
    }

    IEnumerator LaserLoop()
    {
        while (true)
        {
            yield return StartCoroutine(LaserOn());

            yield return new WaitForSeconds(inactiveTime);
        }
    }

    IEnumerator LaserOn()
    {
        float timer = 0f;

        while (timer < activeTime)
        {
            // 🔥 flicker (nyala-mati cepat)
            bool state = Mathf.FloorToInt(Time.time * 10) % 2 == 0;

            laserRenderer.enabled = state;
            laserCollider.enabled = state;

            timer += Time.deltaTime;
            yield return null;
        }

        laserRenderer.enabled = false;
        laserCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameOver)
        {
            isGameOver = true;
            if (SFXManager.IsSFXOn())
            {
                AudioSource.PlayClipAtPoint(
    laserSound,
    transform.position,
    0.9f
);
            }

            // reset uang
            MoneyManager.totalMoney = 0;

            gameOverPanel.SetActive(true);

            Time.timeScale = 0f;

            Debug.Log("Kena laser! Uang hilang semua!");
        }
    }
}