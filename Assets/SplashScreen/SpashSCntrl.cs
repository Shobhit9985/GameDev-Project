using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpashSCntrl : MonoBehaviour
{
    private float time = 0f;
    private RawImage rawImage;
    private TextMeshProUGUI textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponentInChildren<RawImage>();
        textMeshPro = rawImage.GetComponentInChildren<TextMeshProUGUI>(); 
        StartCoroutine(FadeInRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            //Reference menu scene here
            SceneManager.LoadScene("MainMenu");
        }
    }
    private IEnumerator FadeInRoutine()
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds before starting the fade
        textMeshPro.gameObject.SetActive(false);
        float timer = 0.0f;
        Color startColor = rawImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

        while (timer < 3.0f)
        {
            rawImage.color = Color.Lerp(startColor, endColor, timer / 3.0f);
            timer += Time.deltaTime;
            yield return null;

            if (timer > 1.0f && !rawImage.gameObject.activeSelf) // Check if it's been at least 1 second and text is still active
            {
                // Disable text on the RawImage
                rawImage.gameObject.SetActive(false);
            }
        }

        rawImage.color = endColor; // Ensure it's fully transparent
    }

}
