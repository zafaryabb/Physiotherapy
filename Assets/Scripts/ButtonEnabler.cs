using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
    public List<Button> allButtons;
    public List<GameObject> allTextBoxes;

    public CanvasGroup canvasGroup;
    public TMP_Text titleText;

    private void OnEnable()
    {
        StartCoroutine(FlashCG());
    }

    public void EnableButton(Button button)
    {
        foreach(Button b in allButtons)
            b.interactable = true;

        foreach(GameObject f in allTextBoxes)
            f.SetActive(false);

        StartCoroutine(FlashCG(button));
    }

    IEnumerator FlashCG(Button button = null)
    {
        float startTime = 0;
        float duration = 0.25f;

        while(startTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, startTime * 4);
            startTime += Time.deltaTime;
            yield return null;
        }

        if (button != null)
        {
            button.interactable = false;
            titleText.text = button.gameObject.name;
            allTextBoxes[allButtons.IndexOf(button)].SetActive(true);
        }

        startTime = 0;
        duration = 0.25f;

        while(startTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, startTime * 4);
            startTime += Time.deltaTime;
            yield return null;
        }

    }
}
