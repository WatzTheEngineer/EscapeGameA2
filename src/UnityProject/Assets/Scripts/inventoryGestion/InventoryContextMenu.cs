using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InventoryContextMenu : MonoBehaviour
{
      private Inventory inventory;
      [SerializeField] private Button buttonDrop,buttonEquip,buttonConsume,buttonUse, buttonClose;
      private int targetSlotID;

      public void Awake()
      {
          buttonDrop.onClick.AddListener(drop); 
          buttonUse.onClick.AddListener(use);
          buttonEquip.onClick.AddListener(equip);
          buttonConsume.onClick.AddListener(consume);
          buttonClose.onClick.AddListener(close);
          
      }

      public void initialyze(Inventory _inventory)
      {
          inventory = _inventory;
      }

      public void Select(int slotId, IventorySlot slot)
      {
          Item slotItem = inventory.Data[slotId];
          ItemData data = slotItem.Data;
          
          if(slotItem.Empty)
          {
              close();
              return;
          };
          
          gameObject.SetActive(true);
          transform.position = slot.transform.position;
          targetSlotID = slotId;
          
          buttonEquip.gameObject.SetActive(data is IEquipable);
          buttonConsume.gameObject.SetActive(data is IConsumable); 
          buttonUse.gameObject.SetActive(data is IUsable);

      }
      
      
      #region Input

      private void drop()
      {
          inventory.PickItem(targetSlotID);
          close();
      }
      
      
      private void close()
      {
          gameObject.SetActive(false);
      }
      
      
      private void equip()
      {
          IEquipable item = inventory.Data[targetSlotID].Data as IEquipable;
          item.OnEquip(inventory.Context);
          close();
      }
      
      private void consume()
      {
          IConsumable item = inventory.Data[targetSlotID].Data as IConsumable;
          item.OnConsume(inventory.Context);
          close();
      }
      
      private void use()
      {
          IUsable item = inventory.Data[targetSlotID].Data as IUsable;
          item.OnUse(inventory.Context);
          close();
      }
      
      #endregion
}
