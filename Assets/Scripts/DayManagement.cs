using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManagement : MonoBehaviour
{
    [SerializeField] float time;

    [SerializeField] TextMeshProUGUI dayText;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the text of the text
        dayText.text = "DAY" + LevelManager.level.ToString();

        StartCoroutine(DayTimer());
    }

    //Deactivate DAY text after a certain time
    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}
