using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private GameObject floatingText;
    [SerializeField] private float destroyTime = 3f;
    private GameObject newText;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && floatingText)
        {
            ShowFloatingText();
        }
    }

    private void ShowFloatingText()
    {
        newText = Instantiate(floatingText, transform.position, Quaternion.identity, transform);
        Destroy(newText, destroyTime);
    }
}
