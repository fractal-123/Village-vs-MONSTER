using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI currecyUI;     
    [SerializeField] TextMeshProUGUI healhUI;
    [SerializeField] TextMeshProUGUI waveUI;

    private void OnGUI()
    {
        currecyUI.text = Manager.main.currency.ToString();
        healhUI.text = Manager.main.healh.ToString();
        waveUI.text = Manager.main.wave.ToString();
    }

  

}
