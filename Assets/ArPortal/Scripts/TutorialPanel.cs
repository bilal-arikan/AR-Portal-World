using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == 0);
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            int currentIndex = 0;
            var childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    currentIndex = i;
                    break;
                }
            }
            if (currentIndex < childCount - 1)
            {
                transform.GetChild(currentIndex).gameObject.SetActive(false);
                transform.GetChild(currentIndex + 1).gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        });
    }
}
