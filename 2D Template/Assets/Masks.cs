using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Masks", menuName = "Scriptable Objects/Masks")]
public class Masks : ScriptableObject
{
    public Image Mask;
    public string MaskName;
    public AnimatorController playerAnimator;

}
