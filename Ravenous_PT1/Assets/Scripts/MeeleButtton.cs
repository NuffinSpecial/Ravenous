using UnityEngine;
using UnityEngine.UI;
public class MeleeButton : MonoBehaviour
{
    public int id;
    public Image selectedItem;
    private bool selected;
    public Sprite icon;

    // Update is called once per frame
    private void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
        }
    }

    public void Selected()
    {
      selected = true;  
    }

    public void Deselected()
    {
      selected = false;  
    }
    
}
