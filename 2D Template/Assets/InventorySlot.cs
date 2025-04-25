using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool _isMainSlot;

    public void OnDrop(PointerEventData eventData)
    {
        ToggleMask toggleMask = FindFirstObjectByType<ToggleMask>();

        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (transform.childCount != 0)
        {
            Transform oldChild = transform.GetChild(0);

            oldChild.SetParent(draggableItem.parentAfterDrag);
            oldChild.SetAsLastSibling();

            DraggableItem oldDraggable = oldChild.GetComponent<DraggableItem>();
            oldDraggable.parentAfterDrag = draggableItem.parentAfterDrag;

            oldDraggable.GetComponent<MaskAbilities>().enabled = false;

            if (toggleMask && draggableItem.parentAfterDrag.GetComponent<InventorySlot>()._isMainSlot)
            {
                toggleMask.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = oldDraggable.image.sprite;

                if (oldDraggable.currentMask)
                {
                    toggleMask.gameObject.GetComponent<Animator>().runtimeAnimatorController = oldDraggable.currentMask.playerAnimator;
                    oldDraggable.GetComponent<MaskAbilities>().enabled = true;

                }
            }
        }

        draggableItem.transform.SetParent(transform);
        draggableItem.transform.SetAsLastSibling();
        draggableItem.parentAfterDrag = transform;

        if (_isMainSlot && toggleMask)
        {
            toggleMask.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = draggableItem.image.sprite;
            toggleMask.gameObject.GetComponent<Animator>().runtimeAnimatorController = draggableItem.currentMask.playerAnimator;

            draggableItem.GetComponent<MaskAbilities>().enabled = true;
        }
        else
        {
            draggableItem.GetComponent<MaskAbilities>().enabled = false;
        }
    }
}