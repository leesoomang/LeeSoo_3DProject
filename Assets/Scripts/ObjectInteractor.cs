using UnityEngine;

public interface IInteractable
{
    string DisplayName { get; }
    string Description { get; }
}

public class ObjectInteractor : MonoBehaviour
{
    public float interactDistance = 5f;
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Text descText;

    void Update()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1.5f, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            var ih = hit.collider.GetComponent<IInteractable>();
            if (ih != null)
            {
                nameText.text = ih.DisplayName;
                descText.text = ih.Description;
                return;
            }
        }
        nameText.text = "";
        descText.text = "";
    }
}
