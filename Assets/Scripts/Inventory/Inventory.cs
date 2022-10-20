using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count;
        
        public int maxAllowed;

        public Sprite icon;

        
        public Item itemSlot;
        

        public Slot()
        {
            itemName = ""; //inicializa o nome do slot string vasia
            count = 0;
            
            maxAllowed = 5; //maximo permitido por slots
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            ///TESTE
            this.itemSlot = item;
            ///TESTE
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if (count == 0)
                {
                    icon = null;
                    itemName = "";
                    itemSlot = null;
                }
            }

        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots) //cria o inventario com NUMSLOTS de capacidade
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();// inicializa todos os slots com Enum do tipo NONE de acordo com o construtor da classe slot
            slots.Add(slot); 
        }
    }

    public void Add(Item item)
    {
        foreach(Slot slot in slots) //adiciona o item no slot que ja existe e verifica se o limite de itens nao foi ultrapassado
        {
            if(slot.itemName == item.data.itemName && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            } 
        }

        foreach (Slot slot in slots) //adiciona o item pela primeira vez
        {
            if (slot.itemName == "")
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    public bool RemoveByName(string name)///////////////////////////////////TESTE
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].itemName == name)
            {
                Remove(i);
                return true;
            }
        }
        return false;
    }

    public int getIndexByName(string _itemName)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].itemName == _itemName)
            {
                Debug.Log(i);
                return i;
            }
        }
        return -1;
        
    }
}
