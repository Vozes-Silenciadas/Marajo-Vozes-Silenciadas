using UnityEngine;

public class inventarioControla : MonoBehaviour
{

    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int quantiSlot;
    public GameObject[] itemPrefab;

    void Start()
    {
        for (int i = 0; i < quantiSlot; i++)
        {
            Slot slot = Instantiate(slotPrefab, hotbarPanel.transform).GetComponent<Slot>();

            if (i < itemPrefab.Length)
            {
                GameObject item = Instantiate(itemPrefab[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.itemAtual = item;
            }
        }
    }

    public bool AddItem(GameObject itemPrefab)
    {
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.itemAtual == null)
            {
                GameObject novoItem = Instantiate(itemPrefab, slotTransform);
                novoItem.transform.localScale = slotTransform.localScale;
                novoItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.itemAtual = novoItem;
                return true;
            }
        }
        return false;
    }

    public bool verificarItemDestr(int id) // Usar o item e logo ele é destruido 
    {
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.itemAtual != null)
            {
                Item item = slot.itemAtual.GetComponent<Item>();

                if (item != null && item.ID == id)
                {
                    Destroy(slot.itemAtual);
                    slot.itemAtual = null;
                    return true;
                }
            }
        }
        return false;
    }
    
    public bool verificarItem(int id) // Usar o item e deixar no inventario 
    {
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.itemAtual != null)
            {
                Item item = slot.itemAtual.GetComponent<Item>();

                if (item != null && item.ID == id) {
                    return true;
                }
            }
        }
        return false;
    }
}
