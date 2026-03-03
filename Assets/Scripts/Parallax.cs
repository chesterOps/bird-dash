using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Parallax : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] private float _animationSpeed = 1f;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed, 0) * Time.deltaTime;
    }
}
