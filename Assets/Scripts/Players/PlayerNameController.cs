using TMPro;
using UnityEngine;
public class PlayerNameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameP1;
    [SerializeField] private PlayerController _p1;
    [Space]
    [SerializeField] private TextMeshProUGUI _nameP2;
    [SerializeField] private PlayerController _p2;
    [Space]
    [SerializeField] private Vector3 _textOffset;

    private void Update()
    {
        _nameP1.transform.position = Camera.main.WorldToScreenPoint(_p1.transform.position + _textOffset);
        _nameP2.transform.position = Camera.main.WorldToScreenPoint(_p2.transform.position + _textOffset);
    }

}
