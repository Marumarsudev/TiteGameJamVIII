using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public bool hasInputFocus = false;
    public List<InventoryItem> playersInventory = new List<InventoryItem>();

    private RectTransform inventoryTransform;
    private Vector3 originalPos;

    public InventoryItem templateItem;

    private int selectedItem = 0;

    private float inventoryOffset = 2000f;

    public RectTransform maskTransform;

    private NotifController notifController;

    private float yoffset = 202f;

    void Start()
    {
        notifController = FindObjectOfType<NotifController>();
        templateItem.gameObject.SetActive(false);
        inventoryTransform = GetComponent<RectTransform>();
        originalPos = new Vector3(inventoryTransform.position.x, inventoryTransform.position.y, inventoryTransform.position.z);
        inventoryTransform.SetPositionAndRotation(new Vector3(originalPos.x, originalPos.y + inventoryOffset, originalPos.z), Quaternion.identity);
    }

    private void CheckSelected()
    {
        if(playersInventory.Count == 0)
        {
            selectedItem = 0;
        }
        else
        {
            if(selectedItem > playersInventory.Count - 1)
            {
                selectedItem = playersInventory.Count - 1;
            }
            else if(selectedItem < 0)
            {
                selectedItem = 0;
            }
        }
        UpdateInventory();
    }

    private void GetInputs()
    {
        if(InputManager.GetDirDownDown())
        {
            selectedItem++;
            
        }
        
        if(InputManager.GetDirUpDown())
        {
            selectedItem--;
            
        }

        if(InputManager.GetInteractDown() && playersInventory.Count > 0 && playersInventory[selectedItem] != null)
        {
            try
            {
            playersInventory[selectedItem].InteractWithItem();
            }
            catch
            {
            }
        }

        CheckSelected();
    }

    void Update()
    {
        if(hasInputFocus)
        {
            GetInputs();
        }
    }

    public void OpenInventory()
    {
        inventoryTransform.DOMoveY(originalPos.y, 0.75f).SetEase(Ease.OutCubic);
        CheckSelected();
    }

    public void CloseInventory()
    {
        inventoryTransform.DOMoveY(originalPos.y + inventoryOffset, 0.75f).SetEase(Ease.OutCubic);
    }

    public bool SearchItem(Item item, int amount)
    {
        bool isFound = false;
        bool isEnough = false;
        playersInventory.ForEach(iitem => {
            if (iitem.item == item)
            {
                if(iitem.amount >= amount)
                {
                    isFound = true;
                    isEnough = true;
                }
                else
                {
                    notifController.CreateNotif("Not enough " + item.itemname + "s.");
                }
                return;
            }
        });
        if(!isFound && !isEnough)
        {
            notifController.CreateNotif("No " + item.itemname + " found.");
        }
        return isFound;
    }

    public void RemoveItem(Item item, int amount)
    {
        if (item.stackable)
        {
            InventoryItem removedItem = null;
            playersInventory.ForEach(iitem => {
                if (iitem.item == item)
                {
                    iitem.amount -= amount;
                    if(iitem.amount <= 0)
                    {
                        removedItem = iitem;
                    }
                    return;
                }
            });
            playersInventory.Remove(removedItem);
            if(removedItem != null)
                Destroy(removedItem.gameObject);
        }
        else
        {
            InventoryItem removedItem = null;
            playersInventory.ForEach(iitem => {
                if (iitem.item == item)
                {
                    removedItem = iitem;
                    return;
                }
            });
            playersInventory.Remove(removedItem);
            Destroy(removedItem.gameObject);
        }

        // TextMeshProUGUI notif = Instantiate(inventoryNotif, inventoryNotif.GetComponent<RectTransform>().position, Quaternion.identity, transform);
        // notif.text = "Removed " + amount.ToString() + " " + item.itemname + ".";
        // notif.GetComponent<NotifFade>().Fade();

        CheckSelected();
    }

    public void AddItem(Item item, int amount)
    {
        bool addedToStack = false;
        if (item.stackable)
        {
            playersInventory.ForEach(iitem => {
                if (iitem.item == item)
                {
                    iitem.amount += amount;
                    addedToStack = true;
                    return;
                }
            });
        }
        if(!addedToStack)
        {
            InventoryItem tempItem = Instantiate(templateItem, templateItem.GetComponent<RectTransform>().position, Quaternion.identity, maskTransform);
            tempItem.gameObject.SetActive(true);
            tempItem.item = item;
            tempItem.amount = amount;
            playersInventory.Add(tempItem);
        }

        notifController.CreateNotif("Added " + amount.ToString() + " " + item.itemname + ".");

        CheckSelected();
    }

    private void UpdateInventory()
    {
        try
        {
        int i = 0;
        playersInventory.ForEach(item => {
            Vector3 origPos = item.GetComponent<RectTransform>().position;
            if(selectedItem % 4 == 0 && selectedItem >= 4)
            {
                yoffset = 202f + (135f * (selectedItem + 1 / 4));
            }
            else if (selectedItem < 4)
            {
                yoffset = 202f;
            }
            Debug.Log(yoffset);
            item.GetComponent<RectTransform>().localPosition = new Vector3(0, yoffset - (i * 135), origPos.z);
            bool isActive = false;
            if(i == selectedItem)
                isActive = true;
            item.UpdateGUI(isActive);
            i++;
        });
        }
        catch
        {
            Debug.Log("Item probably removed mid check dunno lol its okay i suppose");
        }
    }
}