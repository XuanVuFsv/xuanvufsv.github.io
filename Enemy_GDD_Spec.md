# Enemy GDD Spec — VitsehLand
> Dựa trên cấu trúc `EnemyStat.cs`, `EnemyController.cs`, `EnemyAbilityManager.cs`, HSM framework.
> Phiên bản enemy mới nhất (6 loại: 3 Normal + 1 Flying + 1 Elite + 1 Boss).

---

## Quy ước đọc tài liệu

| Ký hiệu | Ý nghĩa |
|---|---|
| `EnemyStat field` | Trường có sẵn trong `EnemyStat.cs` |
| `⚠️ NEW FIELD` | Đề xuất thêm mới vào `EnemyStat` |
| `[Controller]` | Mô tả thuộc về `EnemyController` / `EnemyAbilityManager` |
| `[HSM]` | Mô tả sơ đồ trạng thái AI (HSM State Tree) |

---

## EnemyStat — Đề xuất bổ sung field mới

```
// Thêm vào EnemyStat.cs

[Header("Armor")]
public float armorValue;              // ⚠️ NEW — Điểm giáp vật lý (0 = không có giáp)
public float armorCoverageAngle;      // ⚠️ NEW — Góc bảo vệ phía trước (độ, VD: 90f, 180f)

[Header("Weakspot")]
public float weakspotDamageMultiplier; // ⚠️ NEW — Hệ số sát thương vào điểm yếu (VD: 3.0f = 300%)

[Header("Phase / Boss")]
public bool isBoss;                   // ⚠️ NEW — Đánh dấu là Boss (kích hoạt phase logic)
public float shieldPool;              // ⚠️ NEW — Lượng Shield riêng (dùng cho Boss phase 2)
public float shieldRegenDelay;        // ⚠️ NEW — Giây không nhận dmg trước khi Shield tự hồi
public float shieldRegenRate;         // ⚠️ NEW — Shield hồi mỗi giây

[Header("Status Effects")]
public float slowResistance;          // ⚠️ NEW — 0 = bị slow bình thường, 1 = miễn slow
public float freezeResistance;        // ⚠️ NEW — 0 = bị freeze bình thường, 1 = miễn freeze
public float knockbackResistance;     // ⚠️ NEW — 0 = bị đẩy bình thường, 1 = miễn knockback

[Header("Behavior")]
public float burrowSpeed;             // ⚠️ NEW — Tốc độ dưới đất (Root Voles)
public float stealthDuration;         // ⚠️ NEW — Thời gian tàng hình mỗi lần (Stealth Mantis)
public float flyHeight;               // ⚠️ NEW — Độ cao bay mục tiêu (Flying enemy)
```

---

## 1. Sâu Cắn Rễ — Root Biter
**Type:** `EnemyType.Swarm` | **Day:** 1 | **Ref:** Horned Beetle (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Root Biter"` | |
| `enemyType` | `Swarm` | |
| `health` | `30` | |
| `damage` | `5` | Mỗi đòn Leap Attack |
| `detectRange` | `12f` | Bắt đầu chase |
| `attackRange` | `2f` | Khoảng cách kích hoạt Leap |
| `speedAttack` | `1.0f` | 1 đòn/giây sau cooldown Leap |
| `speed` | `4.0f` | m/s |
| `acceleration` | `12f` | Tăng tốc nhanh để tạo cảm giác lao tới |
| `stoppingDistance` | `1.5f` | |
| `shieldDecreaseDamage` | `1.0f` | Không có shield |
| `gemRewardForPlayerWhenKilled` | `2` | |
| `armorValue` ⚠️ | `0` | |
| `knockbackResistance` ⚠️ | `0f` | Có thể bị đẩy bình thường |
| **Resistances** | | |
| `physical` | `1.2f` | Yếu vật lý |
| `fire` | `1.0f` | |
| `ice` | `1.5f` | Đặc biệt yếu Ice (Frosteratrol) |
| `poison` | `0.8f` | Hơi kháng độc |
| `lightning` | `1.3f` | Yếu điện (Voltaic chain tốt) |

### [Controller] — Cơ chế gây sát thương

| Thuộc tính | Giá trị |
|---|---|
| `attacker` | `Attacker.Normal` (cận chiến trực tiếp) |
| `defender` | `Defender.None` |
| **Target type** | Single |
| **Damage type** | Instant |
| **Hiệu ứng** | Không có |

### [HSM] — Sơ đồ trạng thái

```
RootBiterRoot
├── Alive
│   ├── Idle          (đứng yên, chờ detect)
│   ├── Chase         (NavMesh → Player, zig-zag offset nhẹ)
│   └── LeapAttack    (dừng 0.5s → Leap → cooldown 1.2s → về Chase)
│       transition: attackRange đạt → LeapAttack
│       transition: Leap xong → Chase
└── Dead
    (animation Die → Destroy)

Transitions:
  Idle      → Chase       : distanceToPlayer < detectRange
  Chase     → LeapAttack  : distanceToPlayer < attackRange
  LeapAttack→ Chase       : sau khi đòn kết thúc
  Anywhere  → Dead        : currentHealth <= 0
```

---

## 2. Bọ Cánh Cứng Bọc Giáp — Shielded Beetle
**Type:** `EnemyType.Brute` | **Day:** 3 | **Ref:** Horsehead (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Shielded Beetle"` | |
| `enemyType` | `Brute` | |
| `health` | `70` | |
| `damage` | `12` | Đòn chém càng |
| `detectRange` | `14f` | |
| `attackRange` | `2.5f` | |
| `speedAttack` | `0.7f` | Đánh chậm hơn Root Biter |
| `speed` | `2.5f` | Chậm nhưng ổn định |
| `acceleration` | `6f` | |
| `stoppingDistance` | `2.0f` | |
| `shieldDecreaseDamage` | `0.0f` | Không xuyên qua khiên lá (100% block) |
| `gemRewardForPlayerWhenKilled` | `8` | |
| `armorValue` ⚠️ | `0` | Không phải armor stat — dùng `shieldDecreaseDamage` |
| `armorCoverageAngle` ⚠️ | `90f` | Block 100% trong 90° phía trước |
| `knockbackResistance` ⚠️ | `0.5f` | Hơi kháng knockback |
| **Resistances** | | |
| `physical` | `0.5f` | Kháng vật lý (giáp khiên) |
| `fire` | `1.2f` | Yếu lửa (Capsaicin tốt) |
| `ice` | `0.8f` | Hơi kháng |
| `poison` | `1.0f` | |
| `lightning` | `1.0f` | |

### [Controller] — Cơ chế gây sát thương

| Thuộc tính | Giá trị |
|---|---|
| `attacker` | `Attacker.Normal` |
| `defender` | `Defender.Shield` |
| **Target type** | Single |
| **Damage type** | Instant |
| **Hiệu ứng** | Không có |
| **Shield logic** | Khi `armorCoverageAngle` bị vi phạm (đạn đến từ sau > 90°) → bỏ qua `shieldDecreaseDamage`, gây dmg bình thường |

### [HSM] — Sơ đồ trạng thái

```
ShieldedBeetleRoot
├── Alive
│   ├── Idle
│   ├── Advance         (tiến tới Player, luôn face-toward-player)
│   │   └── [Activity] FacePlayer — liên tục rotate về phía Player
│   └── MeleeSwipe      (hạ khiên 0.8s → chém → nâng khiên)
│       └── [SubState]
│           ├── WindUp      (hạ khiên, mất armor coverage)
│           ├── Strike      (gây damage)
│           └── Recover     (nâng khiên lại)
└── Dead

Transitions:
  Idle    → Advance    : distanceToPlayer < detectRange
  Advance → MeleeSwipe : distanceToPlayer < attackRange
  MeleeSwipe → Advance : Recover kết thúc

⚠️ Key mechanic: Trong WindUp và Strike, armorCoverageAngle = 0
   → Player có cửa sổ ngắn để bắn trực diện mà không bị block.
```

---

## 3. Bọ Xít Tàng Hình — Stealth Mantis
**Type:** `EnemyType.Brute` | **Day:** 5 | **Ref:** Bandit Hermit (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Stealth Mantis"` | |
| `enemyType` | `Brute` | |
| `health` | `90` | |
| `damage` | `8` | Mỗi viên đạn axit |
| `detectRange` | `15f` | |
| `attackRange` | `10f` | Tầm bắn xa |
| `speedAttack` | `0.5f` | Bắn mỗi 2s |
| `speed` | `3.0f` | Di chuyển vừa phải |
| `stoppingDistance` | `8f` | Giữ khoảng cách |
| `bulletForce` | `600` | |
| `stealthDuration` ⚠️ | `3f` | Tàng hình 3 giây |
| `freezeResistance` ⚠️ | `0f` | Hoàn toàn bị freeze (Frosteratrol counter) |
| `gemRewardForPlayerWhenKilled` | `10` | |
| **Resistances** | | |
| `physical` | `1.0f` | |
| `fire` | `1.0f` | |
| `ice` | `1.8f` | Cực yếu Ice → Frosteratrol là hard counter |
| `poison` | `1.2f` | |
| `lightning` | `1.0f` | |

### [Controller] — Cơ chế gây sát thương

| Thuộc tính | Giá trị |
|---|---|
| `attacker` | `Attacker.Bullet` |
| `defender` | `Defender.None` |
| **Target type** | Single |
| **Damage type** | Instant (đạn axit chạm mục tiêu) |
| **Hiệu ứng** | ⚠️ NEW: Acid DoT — gây thêm 2 dmg/s trong 3s sau khi trúng |

### [HSM] — Sơ đồ trạng thái

```
StealthMantisRoot
├── Alive
│   ├── Idle
│   ├── Reposition     (NavMesh dịch sang vị trí mới khi bị phát hiện/sau stealth)
│   ├── Strafe         (duy trì khoảng cách 8-12m, di chuyển ngang quanh Player)
│   ├── RangedAttack   (bắn 2 viên, đếm shotCount)
│   └── Stealth        (tàng hình 3s, NavMesh đến vị trí random xung quanh)
│       └── [Activity] StealthActivity — ẩn renderer, NavMesh tắt collide với đạn
└── Dead

Transitions:
  Idle         → Strafe       : distanceToPlayer < detectRange
  Strafe       → RangedAttack : attackRange đạt + canAttack
  RangedAttack → Stealth      : shotCount >= 2
  Stealth      → Reposition   : stealthDuration hết
  Reposition   → Strafe       : đến vị trí mới

⚠️ Stealth Interrupt (IInterruptState):
  Nếu Player dùng Soggy Bread → AI mất target
  → Stealth bị cancel sớm, chuyển sang Confused (đứng im 2s)
  Nếu Freeze proc → Stealth bị cancel, lock tại chỗ 2.5s
```

---

## 4. Ruồi Vàng Hút Nhựa — Sap Fly
**Type:** Flying Enemy | **Day:** 3 | **Ref:** Desert Fly (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Sap Fly"` | |
| `enemyType` | `Swarm` | Xử lý như swarm nhưng single target damage |
| `health` | `40` | |
| `damage` | `6` | |
| `detectRange` | `16f` | |
| `attackRange` | `8f` | |
| `speedAttack` | `0.33f` | 1 viên / 3s |
| `speed` | `4.5f` | Bay nhanh hơn ground |
| `flyHeight` ⚠️ | `2.5f` | Độ cao hover mục tiêu |
| `bulletForce` | `500` | Đạn bay chậm, không self-aim |
| `gemRewardForPlayerWhenKilled` | `5` | |
| `knockbackResistance` ⚠️ | `0.3f` | Nhẹ, dễ bị đẩy |
| **Resistances** | | |
| `physical` | `1.5f` | Cực yếu — HP giấy |
| `fire` | `0.8f` | Hơi kháng |
| `ice` | `1.2f` | |
| `poison` | `1.0f` | |
| `lightning` | `2.0f` | Đặc biệt yếu điện (Voltaic chain bầy) |

### [Controller] — Cơ chế gây sát thương

| Thuộc tính | Giá trị |
|---|---|
| `attacker` | `Attacker.Bullet` |
| `defender` | `Defender.None` |
| **Target type** | Single |
| **Damage type** | Instant |
| **Hiệu ứng** | ⚠️ NEW: WebDebuff — trúng đạn axit giảm 25% Atk Speed Player trong 4s |
| **Note** | Đạn bay theo đường thẳng, không tracking |

### [HSM] — Sơ đồ trạng thái

```
SapFlyRoot
├── Alive
│   ├── Hover          (duy trì flyHeight=2.5m, lượn vòng cung quanh Player)
│   │   └── [Activity] HoverActivity — NavMesh trên NavMesh Layer "Flying"
│   │                  Offset vị trí target = Player.pos + Vector3.up * flyHeight
│   └── SpitAttack     (dừng lại 0.5s, phun 1 viên đạn thẳng hướng Player)
│       transition: cooldown 3s → Hover → SpitAttack
└── Dead

Transitions:
  Hover      → SpitAttack : attackTimer >= 3f && distanceToPlayer < attackRange
  SpitAttack → Hover      : projectile đã spawn xong

⚠️ Design note: SapFly KHÔNG đáp đất.
   Shotgun và Grenade gần như vô dụng ở tầm 2.5m cao.
   Buộc Player dùng AR (Berry ammo) để xử lý hiệu quả.
```

---

## 5. Elite Bọ Hung Cỗ Xe Tăng — Elite Dung Beetle
**Type:** `EnemyType.Brute` | **Day:** 3 (unlock sau 100 kills) | **Ref:** Elite Beetle (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Elite Dung Beetle"` | |
| `enemyType` | `Brute` | |
| `health` | `500` | |
| `damage` | `35` | Charge impact |
| `detectRange` | `18f` | |
| `attackRange` | `12f` | Khoảng cách kích hoạt Charge (xa) |
| `speedAttack` | `0.3f` | Charge cooldown ~3.3s |
| `speed` | `3.0f` | Di chuyển thường |
| `acceleration` | `20f` | Tăng tốc cực nhanh khi Charge |
| `stoppingDistance` | `1.0f` | |
| `armorValue` ⚠️ | `150` | |
| `armorCoverageAngle` ⚠️ | `180f` | Block mặt trước + hai bên |
| `weakspotDamageMultiplier` ⚠️ | `3.0f` | Bắn Weakspot sau lưng = 300% dmg |
| `slowResistance` ⚠️ | `0.5f` | Slow chỉ giảm 50% (Frosteratrol vẫn có tác dụng) |
| `freezeResistance` ⚠️ | `0f` | Freeze = Cancel Charge hoàn toàn |
| `knockbackResistance` ⚠️ | `0.8f` | Gần như không bị đẩy |
| `gemRewardForPlayerWhenKilled` | `35` | |
| **Resistances** | | |
| `physical` | `0.4f` | Giáp dày, kháng vật lý cao |
| `fire` | `0.8f` | |
| `ice` | `1.5f` | Yếu Ice → Freeze = win |
| `poison` | `1.3f` | Yếu độc (Atropine stack hiệu quả) |
| `lightning` | `1.0f` | |

### [Controller] — Cơ chế gây sát thương

| Thuộc tính | Giá trị |
|---|---|
| `attacker` | `Attacker.Normal` |
| `defender` | `Defender.Shield` (đại diện cho lớp giáp trước) |
| **Target type** | Single → AoE khi Charge hit tường |
| **Damage type** | Instant (impact) |
| **Hiệu ứng** | ⚠️ NEW: ChargeStun — trúng Charge gây Stun 1.5s lên Player |
| **Charge speed** | `8.0f` m/s (ghi override NavMesh speed tạm thời) |

### [HSM] — Sơ đồ trạng thái

```
EliteDungBeetleRoot
├── Alive
│   ├── Patrol / Aggro  (NavMesh đến target: Turret > Player)
│   ├── ChargeWindUp    (đứng im 1.5s, hiện telegraph đỏ)
│   │   └── [Activity] TelegraphActivity — vẽ line đỏ trên đất
│   ├── Charging        (lao thẳng tốc độ 8m/s, NavMesh bị override)
│   │   └── [Activity] ChargeActivity — disable steering, force velocity
│   └── RecoverStunned  (bị stun 3s sau khi hụt/va vật cản, lộ Weakspot)
│       └── [Activity] WeakspotExpose — enable weakspot collider sau lưng
└── Dead

Transitions:
  Aggro        → ChargeWindUp  : distanceToPlayer < attackRange && lineOfSight
  ChargeWindUp → Charging      : windUpTimer >= 1.5f
  ChargeWindUp → RecoverStunned: Freeze proc trong WindUp → cancel ngay
  Charging     → RecoverStunned: hit obstacle hoặc miss Player
  RecoverStunned→ Aggro        : stunTimer >= 3f

⚠️ Bottle interaction:
  - Frosteratrol Slow (30%): ChargeWindUp kéo dài hơn → Player dễ né hơn
  - Frosteratrol Freeze (2.5s): Cancel Charge, force → RecoverStunned ngay
  - Crit Souper 7s window: phải dùng trong RecoverStunned khi Weakspot lộ
```

---

## 6. Đại Vương Châu Chấu — Locust Monarch *(Boss)*
**Type:** Boss | **Day:** 6 (cuối ngày) | **Ref:** Lu Wu (GFR)

### EnemyStat Values

| Field | Giá trị | Ghi chú |
|---|---|---|
| `enemyName` | `"Locust Monarch"` | |
| `enemyType` | `Brute` | Custom logic qua isBoss |
| `isBoss` ⚠️ | `true` | |
| `health` | `2500` | |
| `shieldPool` ⚠️ | `600` | Shield Phase 2 |
| `shieldRegenDelay` ⚠️ | `6f` | Sau 6s không nhận dmg → tự hồi |
| `shieldRegenRate` ⚠️ | `50f` | 50 shield/giây |
| `damage` | `50` | Đòn Vồ Chớp Nhoáng |
| `detectRange` | `999f` | Boss luôn nhận thức Player |
| `attackRange` | `5f` | Leap trigger range |
| `speedAttack` | `0.4f` | |
| `speed` | `4.0f` | Phase 1 bay, Phase 2 ground |
| `flyHeight` ⚠️ | `5.0f` | Phase 1 |
| `freezeResistance` ⚠️ | `1.0f` | **Miễn Freeze khi Shield còn sống** |
| `slowResistance` ⚠️ | `1.0f` | **Miễn Slow khi Shield còn sống** |
| `knockbackResistance` ⚠️ | `1.0f` | Không thể knockback Boss |
| `gemRewardForPlayerWhenKilled` | `200` | |
| **Resistances** | | |
| `physical` | `0.7f` | |
| `fire` | `0.8f` | |
| `ice` | `1.3f` | Yếu Ice khi Shield đã vỡ |
| `poison` | `1.0f` | |
| `lightning` | `1.0f` | |

### [Controller] — Cơ chế gây sát thương

| Skill | Target | Damage Type | Hiệu ứng |
|---|---|---|---|
| Vồ Chớp Nhoáng (Leap) | Single (Player) | Instant | Knockback nhẹ |
| Quạt Năng Lượng (Energy Orbs) | Multi — 3 projectiles | Instant, soft-tracking | Không |
| Đại Chấn Nện Đất (Slam AoE) | AoE radius 6m | Instant | ⚠️ NEW: GroundShock — Player trúng nếu không Jump |
| Hú Kích Động (Enrage Roar) | AoE buff toàn bộ minion | — | +30% Speed & AtkSpeed minion 6s |
| Khạc Trứng Swarm | — | — | Spawn 6 Root Biter |

### [HSM] — Sơ đồ trạng thái

```
LocustMonarchRoot
├── Phase1 (100% → 50% HP) — Bay trên không flyHeight=5m
│   ├── AirHover        (lượn đổi vị trí sau mỗi skill)
│   ├── LeapStrike      (báo hiệu 1s → Leap xuống vị trí Player → bật lên lại)
│   ├── SpawnEggs       (thả 3 quả trứng → nở 6 Root Biter sau 2s)
│   └── WindBlade       (vỗ cánh → 3 luồng gió lưỡi liềm quét dọc sân)
│       SkillRotation: LeapStrike → WindBlade → SpawnEggs → lặp lại
│
├── PhaseTransition     (HP về 50% → rơi xuống đất → vụ nổ chấn động đẩy Player)
│   └── [Activity] ShieldActivate — bật shieldPool = 600, đổi freezeResistance = 1.0
│
├── Phase2 (50% → 0% HP) — Dưới đất, có Shield
│   ├── Ground Idle     (chờ skill CD)
│   ├── SlamAttack      (nện 2 càng → GroundShock AoE 6m, Player phải Jump)
│   ├── EnrageRoar      (Hú → buff minion 6s)
│   ├── ShieldRecharge  (khi Shield = 0 và 6s không nhận dmg → tự hồi 50/s)
│   │   └── ⚠️ Nếu Player phá Shield → freezeResistance = 0, slowResistance = 0
│   └── (tiếp tục Spawn Biter nếu số lượng trên sân < 4)
│
└── Dead
    (animation chết Boss → trigger Unlock Tomato 🍅 event)

Transitions:
  Phase1      → PhaseTransition : currentHealth <= health * 0.5f
  PhaseTransition → Phase2     : landing animation xong
  Anywhere    → Dead           : currentHealth <= 0

⚠️ Damage Check — Bottle combo bắt buộc Phase 2:
  1. ⚡ Burstger (+50% Fire Rate) → phá 600 Shield trước khi SlamAttack
  2. Shield vỡ → freezeResistance = 0 → 🧊 Frosteratrol kích hoạt
     Freeze 2.5s → SlamAttack bị Cancel → window burst dứt điểm
```

---

## Tổng hợp — EnemyStat Fields mới cần thêm

| Field | Kiểu | Dùng cho |
|---|---|---|
| `armorValue` | `float` | Shielded Beetle, Elite Dung Beetle |
| `armorCoverageAngle` | `float` | Shielded Beetle (directional armor) |
| `weakspotDamageMultiplier` | `float` | Elite Dung Beetle |
| `isBoss` | `bool` | Locust Monarch |
| `shieldPool` | `float` | Boss Phase 2 |
| `shieldRegenDelay` | `float` | Boss Shield regen |
| `shieldRegenRate` | `float` | Boss Shield regen |
| `slowResistance` | `float` | Elite + Boss |
| `freezeResistance` | `float` | Elite + Boss |
| `knockbackResistance` | `float` | Tất cả |
| `burrowSpeed` | `float` | (Dự phòng Root Voles nếu implement sau) |
| `stealthDuration` | `float` | Stealth Mantis |
| `flyHeight` | `float` | Sap Fly + Boss Phase 1 |

---

## Ghi chú triển khai

- `armorCoverageAngle` nên được xử lý trong `EnemyAbilityManager.TakeEffectDamage()` bằng cách tính góc giữa hướng đạn và `transform.forward` của enemy.
- `freezeResistance` và `slowResistance` nên là runtime-modifiable (không phải readonly) vì Boss Phase 2 thay đổi chúng động trong game.
- Weakspot nên là một Collider riêng (child GameObject) với tag `"Weakspot"`, được enable/disable theo state (ví dụ: chỉ bật trong `RecoverStunned`).
- Boss Shield nên là một component riêng `BossShieldController` thay vì nhét vào `EnemyHealthController`, để tách biệt logic hồi shield khỏi HP.
