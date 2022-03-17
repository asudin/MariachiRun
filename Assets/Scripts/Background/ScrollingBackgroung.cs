using UnityEngine;

public class ScrollingBackgroung : MonoBehaviour
{
    [SerializeField]
    private float _backgroundSpeed;
    public Renderer bgRend;

    private void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(_backgroundSpeed * Time.deltaTime, 0f);
    }
}
