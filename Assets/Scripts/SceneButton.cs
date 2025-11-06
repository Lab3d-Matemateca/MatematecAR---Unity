using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public GameObject modelPrefab;
    private GameObject currentModel;

    public void OnButtonClicked()
    {
        if (currentModel != null) Destroy(currentModel);
        currentModel = Instantiate(modelPrefab, transform.parent.position + Vector3.up * 0.05f, Quaternion.identity, transform.parent);
    }
}
