using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUITextCommand : SlideCommand
{
    public Text Text;
    public string newText;

    public float textSpeed = 100f;

    public override void Execute()
    {
        base.Execute();
        Text.text = "";
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i <= newText.Length; i++)
        {
            string displayString = newText.ToUpper().Substring(0, i);
            Text.text = displayString;
            yield return new WaitForSeconds(1f/textSpeed);
        }
    }
}
