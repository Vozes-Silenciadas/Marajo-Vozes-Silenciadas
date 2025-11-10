using UnityEngine;

public class inventarioControla : MonoBehaviour
{

    public GameObject hotbarPanel;       // Painel que contém todos os slots da hotbar
    public GameObject slotPrefab;        // Prefab do slot 
    public int quantiSlot;               // Quantidade total de slots na hotbar
    public GameObject[] itemPrefab;      // Array de prefabs dos itens iniciais a adicionar na hotbar

    void Start()
    {
        for (int i = 0; i < quantiSlot; i++)                     // Loop para criar todos os slots
        {
            Slot slot = Instantiate(slotPrefab, hotbarPanel.transform).GetComponent<Slot>(); // Instancia o slot e pega seu script Slot

            if (i < itemPrefab.Length)                            // Se houver um item para esse slot
            {
                GameObject item = Instantiate(itemPrefab[i], slot.transform); // Instancia o item dentro do slot
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Centraliza o item no slot
                slot.itemAtual = item;                             // Define o item atual do slot
            }
        }
    }

    public bool AddItem(GameObject itemPrefab)                   // Método para adicionar um item à hotbar
    {
        foreach (Transform slotTransform in hotbarPanel.transform) // Percorre todos os slots da hotbar
        {
            Slot slot = slotTransform.GetComponent<Slot>();      // Pega o script do slot
            if (slot != null && slot.itemAtual == null)          // Se o slot estiver vazio
            {
                GameObject novoItem = Instantiate(itemPrefab, slotTransform); // Instancia o item no slot
                novoItem.transform.localScale = slotTransform.localScale;     // Ajusta a escala do item para combinar com o slot
                novoItem.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100); // Define tamanho do item
                novoItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Centraliza o item
                slot.itemAtual = novoItem;                              // Define o item atual do slot
                Debug.Log("Ei");
                return true;                                           // Retorna true 
            }
        }
        return false;                                               // Retorna false caso não tenha slot vazio
    }

    public bool verificarItemDestr(int id)                        // Verifica o item e destrói após uso
    {
        foreach (Transform slotTransform in hotbarPanel.transform) // Percorre todos os slots
        {
            Slot slot = slotTransform.GetComponent<Slot>();       // Pega o script do slot
            if (slot != null && slot.itemAtual != null)           // Se o slot não estiver vazio
            {
                Item item = slot.itemAtual.GetComponent<Item>();  // Pega o componente Item

                if (item != null && item.ID == id)                // Se o ID do item bater com o procurado
                {
                    Destroy(slot.itemAtual);                     // Destroi o item
                    slot.itemAtual = null;                        // Limpa o slot
                    return true;                                  // Retorna true 
                }
            }
        }
        return false;                                             // Retorna false se o item não for encontrado
    }

    public bool verificarItem(int id)                             // Verifica se o item existe no inventário (sem destruir)
    {
        foreach (Transform slotTransform in hotbarPanel.transform) // Percorre todos os slots
        {
            Slot slot = slotTransform.GetComponent<Slot>();       // Pega o script do slot
            if (slot != null && slot.itemAtual != null)           // Se o slot não estiver vazio
            {
                Item item = slot.itemAtual.GetComponent<Item>();  // Pega o componente Item

                if (item != null && item.ID == id)                // Se o ID bater
                {
                    return true;                                 // Retorna true 
                }
            }
        }
        return false;                                            // Retorna false caso não encontre o item
    }
}