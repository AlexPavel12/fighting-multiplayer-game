using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private Text HPText;

    private int hp;

    public int HP
    {
        get { return hp; }
        set { hp = value;
            HPText.text = value.ToString();
        }
    }
}
