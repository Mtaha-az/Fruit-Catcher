using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Quitpanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject instructionsPanel; // Reference to the instructions panel
    public float instructionDisplayTime = 3.5f;
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void level1()
    {
        //SceneManager.LoadScene("level 1");
        StartCoroutine(ShowInstructionsAndLoadLevel("level 1"));
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitManu()
    {
        Quitpanel.SetActive(true);
        mainPanel.SetActive(false);
        StartCoroutine(ScaleUp2(Quitpanel.transform));
    }
    public void web_QuitManu()
    {
        Quitpanel.SetActive(true);
        mainPanel.SetActive(false);
        StartCoroutine(ScaleUp(Quitpanel.transform));
    }
    public void Exit_Quitpanal()
    {
        StartCoroutine(ScaleDown(Quitpanel.transform));
    }

    IEnumerator ScaleUp(Transform panelTransform)
    {
        Vector3 initialScale = new Vector3(0, 0, 0);
        Vector3 finalScale = new Vector3(1, 1, 1);
        float duration = 0.3f;
        float elapsedTime = 0;

        panelTransform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        panelTransform.localScale = finalScale;
    }

    IEnumerator ScaleDown(Transform panelTransform)
    {
        Vector3 initialScale = panelTransform.localScale;
        Vector3 finalScale = new Vector3(0, 0, 0);
        float duration = 0.3f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        Quitpanel.SetActive(false);  // Disable the panel after shrinking
        mainPanel.SetActive(true);
    }
    IEnumerator ShowInstructionsAndLoadLevel(string levelName)
    {
        instructionsPanel.SetActive(true); // Show the instructions panel
        StartCoroutine(ScaleUp(instructionsPanel.transform));
        yield return new WaitForSeconds(instructionDisplayTime); // Wait for 3 to 4 seconds
        StartCoroutine(ScaleDown1(instructionsPanel.transform, levelName));

    }
    IEnumerator ScaleDown1(Transform panelTransform, string levelName)
    {
        Vector3 initialScale = panelTransform.localScale;
        Vector3 finalScale = new Vector3(0, 0, 0);
        float duration = 0.3f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        instructionsPanel.SetActive(false); // Hide the instructions panel
        SceneManager.LoadScene(levelName);  // Load the game level
    }
    IEnumerator ScaleUp2(Transform panelTransform)
    {
        Vector3 initialScale = new Vector3(0, 0, 0);
        Vector3 finalScale = new Vector3(2.3f, 2.03f, 1);
        float duration = 0.3f;
        float elapsedTime = 0;

        panelTransform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        panelTransform.localScale = finalScale;
    }
}
