using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [Header("Interaction Settings")]
    [Tooltip("바닥 아이템 레이어")]
    public LayerMask groundItemLayer;
    [Tooltip("최대 상호작용 거리")]
    public float interactRange = 3f;
    [Tooltip("사용 프롬프트 텍스트 (E 사용하기)")]
    public TextMeshProUGUI usePromptText;

    [Header("Speed Boost Settings")]
    [Tooltip("플레이어 컨트롤러 참조")]
    public PlayerController playerController;

    private ItemObject _focusedItem;

    void Awake()
    {
        // 시작할 때 프롬프트 숨기기
        if (usePromptText != null)
            usePromptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // 매 프레임 시야 중앙으로 아이템 탐색
        ScanForGroundItem();
    }

    private void ScanForGroundItem()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, groundItemLayer)
            && hit.collider.TryGetComponent<ItemObject>(out var itemObj))
        {
            // 아이템 감지 시
            _focusedItem = itemObj;
            if (usePromptText != null)
            {
                usePromptText.text = $"[E] 사용하기: {itemObj.Data.displayName}";
                usePromptText.gameObject.SetActive(true);
            }
        }
        else
        {
            // 없으면 해제
            _focusedItem = null;
            if (usePromptText != null)
                usePromptText.gameObject.SetActive(false);
        }
    }

    // PlayerInput → Invoke Unity Events로 바인딩
    public void OnUse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _focusedItem != null)
        {
            // SpeedBoost 효과 코루틴 실행
            StartCoroutine(ApplySpeedBoost(_focusedItem.Data));

            // 사용 즉시 아이템 제거
            Destroy(_focusedItem.gameObject);
            _focusedItem = null;

            // 프롬프트 숨기기
            usePromptText.gameObject.SetActive(false);
        }
    }

    private IEnumerator ApplySpeedBoost(ItemData data)
    {
        // 원래 속도 저장
        float originalSpeed = playerController.moveSpeed;

        // effectValue 만큼 속도 증가
        playerController.moveSpeed += data.effectValue;

        // duration 만큼 대기
        yield return new WaitForSeconds(data.duration);

        // 원상복구
        playerController.moveSpeed = originalSpeed;
    }
}
