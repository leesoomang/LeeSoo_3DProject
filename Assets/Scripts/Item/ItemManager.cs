using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [Header("Interaction Settings")]
    [Tooltip("�ٴ� ������ ���̾�")]
    public LayerMask groundItemLayer;
    [Tooltip("�ִ� ��ȣ�ۿ� �Ÿ�")]
    public float interactRange = 3f;
    [Tooltip("��� ������Ʈ �ؽ�Ʈ (E ����ϱ�)")]
    public TextMeshProUGUI usePromptText;

    [Header("Speed Boost Settings")]
    [Tooltip("�÷��̾� ��Ʈ�ѷ� ����")]
    public PlayerController playerController;

    private ItemObject _focusedItem;

    void Awake()
    {
        // ������ �� ������Ʈ �����
        if (usePromptText != null)
            usePromptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // �� ������ �þ� �߾����� ������ Ž��
        ScanForGroundItem();
    }

    private void ScanForGroundItem()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, groundItemLayer)
            && hit.collider.TryGetComponent<ItemObject>(out var itemObj))
        {
            // ������ ���� ��
            _focusedItem = itemObj;
            if (usePromptText != null)
            {
                usePromptText.text = $"[E] ����ϱ�: {itemObj.Data.displayName}";
                usePromptText.gameObject.SetActive(true);
            }
        }
        else
        {
            // ������ ����
            _focusedItem = null;
            if (usePromptText != null)
                usePromptText.gameObject.SetActive(false);
        }
    }

    // PlayerInput �� Invoke Unity Events�� ���ε�
    public void OnUse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _focusedItem != null)
        {
            // SpeedBoost ȿ�� �ڷ�ƾ ����
            StartCoroutine(ApplySpeedBoost(_focusedItem.Data));

            // ��� ��� ������ ����
            Destroy(_focusedItem.gameObject);
            _focusedItem = null;

            // ������Ʈ �����
            usePromptText.gameObject.SetActive(false);
        }
    }

    private IEnumerator ApplySpeedBoost(ItemData data)
    {
        // ���� �ӵ� ����
        float originalSpeed = playerController.moveSpeed;

        // effectValue ��ŭ �ӵ� ����
        playerController.moveSpeed += data.effectValue;

        // duration ��ŭ ���
        yield return new WaitForSeconds(data.duration);

        // ���󺹱�
        playerController.moveSpeed = originalSpeed;
    }
}
