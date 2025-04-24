using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using Unity.VisualScripting;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public Masks currentMask;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        //OnCollisionEnter2D();
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        //if (collider.gameObject.CompareTag("EquipedMask"))
        { 
            // Right now it sets the player sprite and animation regardless if wether or not the item is parented to the inventory slot. Simple fix I just can't get. Find object to work so that it only switches once its parented
            //FindAnyObjectByType<ToggleMask>().gameObject.GetComponentInChildren<SpriteRenderer>().sprite = image.sprite;
            //FindAnyObjectByType<ToggleMask>().gameObject.GetComponent<Animator>().runtimeAnimatorController = currentMask.playerAnimator;
        }
    }
}
