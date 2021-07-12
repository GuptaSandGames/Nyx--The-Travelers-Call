using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/DialogueThingie")]
public class DialogueThingie : ScriptableObject
{
  [SerializeField] [TextArea] private string[] dialogue;

  public string[] Dialogue => dialogue;
}
