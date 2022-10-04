using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "S0_itemList", menuName = "Scriptable Object/Item/ItemList")]
public class SO_itemList : ScriptableObject
{
    [SerializeField]
    public List<itemDetails> itemDetails;
}
