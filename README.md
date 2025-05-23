# 3D 어드벤처 게임

---

> Unity & C#을 활용한 3D 어드벤처 게임 프로젝트입니다.

## 목차

1. [게임 소개](#게임-소개)
2. [주요 시스템](#주요-시스템)

   * [플레이어 이동 & 점프](#플레이어-이동--점프)
   * [카메라 컨트롤](#카메라-컨트롤)
   * [아이템 상호작용](#아이템-상호작용)
   * [낙하 데미지](#낙하-데미지) (구현 중)
3. [폴더 구조](#폴더-구조)
4. [컨트롤](#컨트롤)
6. [스크립트 개요](#스크립트-개요)

---

## 게임 소개

팀스파르타 유니티 숙련 단계 3D게임 개인 과제입니다.
게임은 기본적인 기능만 구현되어 점프를 할 수 있는 점프대와 일반 발판, 그리고 스피드를 올릴 수 있는 당근 아이템이 있습니다.

---

## 주요 시스템

### 플레이어 이동 & 점프

* **이동**: WASD 
* **점프**: Space
* **구현**: `PlayerController.cs`에서 Rigidbody 기반 이동 및 점프 로직 사용

### 카메라 컨트롤

* **시점 조절**: 마우스 이동
* **구현**: `PlayerController.cs`의 `CameraLook()` 메서드

### 체력 & 스태미나 시스템

* **UI 연동**: `UICondition.cs`
* **낙하 데미지**: 일정 높이 이상에서 착지 시 데미지 계산 (추후 추가 예정)
* **관련 스크립트**: `PlayerCondition.cs`, `UICondition.cs`

### 아이템 상호작용

* **사용 방식**: 화면 중앙을 기준으로 아이템을 바라보고 E 키 입력
* **즉시 사용**: 인벤토리 없이 바로 사용
* **효과 예시**: 속도 버프 (SpeedBoost)
* **관련 스크립트**: `ItemObject.cs`, `ItemManager.cs`

### 낙하 데미지 (구현 중)


---

## 폴더 구조

```plaintext
Assets/
├─ Scenes/            # 씬 파일
├─ Scripts/
│  ├─ Player/         # PlayerController, PlayerCondition
│  ├─ UI/             # UICondition
│  └─ Gameplay/       # ItemManager, ItemObject
├─ Prefabs/           # 프리팹
├─ Materials/         # 머티리얼
└─ ...
```

---

## 컨트롤

| 동작    | 입력             |
| ----- | -------------- |
| 이동    | W/A/S/D 또는 방향키 |
| 점프    | Space          |
| 상호작용  | E              |
| 시점 조절 | 마우스 이동         |

---

## 스크립트 개요

| 스크립트                | 설명                               |
| ------------------- | -------------------------------- |
| PlayerController.cs | 이동, 점프, 카메라 컨트롤 구현               |
| PlayerCondition.cs  | 체력/스태미나 관리, 낙하 데미지, 사망 처리        |
| UICondition.cs      | 체력/스태미나 UI 갱신                    |
| ItemObject.cs       | 아이템 데이터 정의 및 OnInteract 구현       |
| ItemManager.cs      | Raycast 기반 아이템 사용, SpeedBoost 적용 |


