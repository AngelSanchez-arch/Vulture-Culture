using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{



    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (transform.childCount != 0)
        {
            Transform oldChild = transform.GetChild(0);

            oldChild.SetParent(draggableItem.parentAfterDrag);
            oldChild.SetAsLastSibling();
            oldChild.GetComponent<DraggableItem>().parentAfterDrag = draggableItem.parentAfterDrag;

            FindAnyObjectByType<ToggleMask>().gameObject.GetComponentInChildren<SpriteRenderer>().sprite = oldChild.GetComponent<DraggableItem>().image.sprite;

            if (oldChild.GetComponent<DraggableItem>().currentMask)
            {
                FindAnyObjectByType<ToggleMask>().gameObject.GetComponent<Animator>().runtimeAnimatorController = oldChild.GetComponent<DraggableItem>().currentMask.playerAnimator;
            }
        }

        draggableItem.transform.SetParent(transform);
        draggableItem.transform.SetAsLastSibling();
        draggableItem.parentAfterDrag = transform;
    }
}