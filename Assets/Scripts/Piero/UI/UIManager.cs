using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI infoText;







    public void LoadText(string actualtext)
    {
        infoText.text = "" + actualtext;
    }

    public void ExitText()
    {
        infoText.gameObject.SetActive(false);
    }

    public void OpenText()
    {
        infoText.gameObject.SetActive(true);
    }
}
