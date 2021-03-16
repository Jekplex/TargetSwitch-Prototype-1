using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public GameObject[] panels;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowPanel(GameObject panel)
    {
        // hide everything
        HideAllPanels();

        // show panel
        panel.SetActive(true);

    }

    public void QuitApp()
    {
        // May want to add are you sure option for quality of life.

        Debug.Log("Application will be called to quit.");
        Application.Quit();

        
    }

    private void HideAllPanels()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
    }

}
