using UnityEngine;

public class PanelNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panel1; // e.g., Main Menu
    public GameObject panel2; // e.g., Settings
    public GameObject panel3; // e.g., Credits

    private GameObject currentPanel;

    private void Start()
    {
        ShowPanel(panel1); // Start with the first panel
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // Deactivate all panels
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // Activate the selected panel
        panelToShow.SetActive(true);
        currentPanel = panelToShow;
    }

    public void NextPanel()
    {
        if (currentPanel == panel1) ShowPanel(panel2);
        else if (currentPanel == panel2) ShowPanel(panel3);
        else ShowPanel(panel1); // loop back
    }

    public void PreviousPanel()
    {
        if (currentPanel == panel1) ShowPanel(panel3);
        else if (currentPanel == panel2) ShowPanel(panel1);
        else ShowPanel(panel2);
    }
}
