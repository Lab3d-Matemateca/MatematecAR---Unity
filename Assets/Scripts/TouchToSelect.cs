using UnityEngine;

public class TouchToSelection : MonoBehaviour
{
    private Camera arCamera;

    void Awake()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;
        Ray ray = arCamera.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var btn = hit.collider.GetComponent<SceneButton>();
            if (btn != null) btn.OnButtonClicked();
        }
    }
}
