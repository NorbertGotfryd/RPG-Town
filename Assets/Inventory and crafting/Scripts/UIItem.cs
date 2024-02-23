using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;
    public bool craftingSlot = false;
    private CraftingSlots craftingSlots;
    public bool craftingResultSlot = false;


    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();
        tooltip = FindObjectOfType<Tooltip>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;     
        }
        else
        {
            spriteImage.color = Color.clear;
        }
        if(craftingSlot)
        {
            craftingSlots.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            UICraftResult craftResult = GetComponent<UICraftResult>();
            if (craftResult != null && this.item != null && selectedItem.item == null)
            {
                craftResult.PickItem();
                selectedItem.UpdateItem(this.item);
                craftResult.ClearSlots();
            }
            else if (!craftingResultSlot)
            {
                if (selectedItem.item != null)
                {
                    Item clone = new Item(selectedItem.item);
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(clone);
                }
                else
                {
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(null);
                }
            }
        }
        else if (selectedItem.item != null && !craftingResultSlot)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
