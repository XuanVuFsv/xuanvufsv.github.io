# 🌾 Crop Shooter — Working Context & Progress Tracker
> Pass file này + code liên quan vào đầu mỗi phiên làm việc để tiếp tục không bị miss.
> **Repo:** https://github.com/xuanvufsv/FSV.Crop-Shooter-SP
> **GDD Version:** 180426 | **Engine:** Unity | **Namespace root:** `VitsehLand`

---

## 🎮 Game Concept (TL;DR)

FPS + Farming kết hợp theo kiểu Slime Rancher nhưng với crop:
- **Core loop:** Farm → Process → Prepare → Fight → Upgrade
- **Ammo = Crop:** 1 harvest = 1 ammo. Crop cũng là nguyên liệu nấu ăn, craft Bottle, bán lấy Granumz
- **Bottle system:** Addon per-shot effect lên weapon, tối đa **2 bottle active cùng lúc**, duration-based
- **Day/Night:** Ban ngày farm/craft, ban đêm defend monster wave
- **Tiến trình:** Unlock crops/recipes/bottles theo ngày + trigger (kill X, open pod, defeat boss)

---

## 🏗️ Architecture Overview

```
AbilityEntity (MonoBehaviour, IVisitable)
    └── AbilityStat
            └── AbilityStatMediator  ← modifier pipeline, event-driven cache invalidation
                    └── AbilityStatModifier (timed, strategy pattern)

Ability (plain class, serializable)
    ├── List<IEffectFactory<IDamageable>>  ← factory pattern, [SerializeReference]
    ├── TargetingStrategy  ← plain abstract class, [SerializeReference]
    └── HandleVFX()

TargetingStrategy (abstract plain class)
    ├── SelfTargetingStrategy
    ├── ProjectileTargeting
    └── AOEStrategyTargeting

IEffectFactory<T> → IEffect<T>
    ├── DamageOneShotEffect / Factory
    └── DamageOverTimeEffect / Factory

AbilityPickup (MonoBehaviour, IVisitor)
    └── AbilityStatModifierPickup

AbilityEntity subclasses:
    └── EnemyAbilityController
```

### Key Patterns Used
- **Visitor** — Pickup → Entity interaction
- **Mediator + Observer** — Stat cache invalidation (`OnCacheInvalidated`)
- **Factory** — Effect creation, Stat creation, Modifier creation
- **Strategy** — Stat modifier application order, Operation (Add/Multiply)
- **[SerializeReference]** — Polymorphic serialization cho Effect factories và TargetingStrategy

---

## 📁 File Map

| File | Namespace | Ghi chú |
|------|-----------|---------|
| `Ability.cs` | `VitsehLand.Game.Ability` | Data bag + Execute + HandleVFX |
| `AbilityEntity.cs` | `VitsehLand.Game.Ability` | Base MB, owns AbilityStat, calls Mediator.Update |
| `AbilityPickup.cs` | `VitsehLand.Game.Ability` | Base pickup, Visitor pattern |
| `AbilityStatModifierPickup.cs` | `VitsehLand.Game.Ability` | Concrete pickup, TODO: move config to SO |
| `AbilityDestroyHandler.cs` | `VitsehLand.Game.Ability` | VFX lifetime, OnEnable (pool-ready) |
| `AbilityStat.cs` | `VitsehLand.Game.Ability` | Cache per-stat, invalidated by Mediator |
| `AbilityStatMediator.cs` | `VitsehLand.Game.Ability` | Modifier pipeline, Query pattern |
| `AbilityStatModifier.cs` | `VitsehLand.Game.Ability` | Timed modifier, CountdownTimer (ImprovedTimers) |
| `AbilityStatModifierApplicationOrder.cs` | `VitsehLand.Game.Ability` | Add trước, Multiply sau |
| `AbilityStatModifierFactory.cs` | `VitsehLand.Game.Ability` | Add/Multiply strategy factory |
| `AbilityStatFactory.cs` | `VitsehLand.Game.Ability` | Generic factory cho AbilityStat subclass |
| `TargetingStrategy.cs` | `VitsehLand.Game.Ability` | Abstract plain class, CachedCtx, MarkDirty pattern |
| `TargetingManager.cs` | `VitsehLand.Game.Ability` | MB, owns camera + current strategy |
| `SelfTargetingStrategy.cs` | `VitsehLand.Game.Ability` | Apply lên owner |
| `ProjectileTargeting.cs` | `VitsehLand.Game.Ability` | Spawn projectile hướng camera |
| `AOEStrategyTargeting.cs` | `VitsehLand.Game.Ability` | Preview + OverlapSphere |
| `ExampleProjectileController.cs` | `VitsehLand.Game.Ability` | Projectile snapshot ctx, OnTriggerEnter |
| `IEffectFactory.cs` | `VitsehLand.Game.Ability` | Interface Create() / Create(ctx) |
| `DamageOneShotEffect.cs` | `VitsehLand.Game.Ability` | Instant damage |
| `DamageOneShotEffectFactory.cs` | `VitsehLand.Game.Ability` | |
| `DamageOverTimeEffect.cs` | `VitsehLand.Game.Ability` | IntervalTimer DOT |
| `DamageOverTimeEffectFactory.cs` | `VitsehLand.Game.Ability` | |
| `ExampleDealDamageEffect.cs` | `VitsehLand.Game.Ability` | Hotbar test MonoBehaviour |
| `AbilityBaseStat.cs` | `VitsehLand.Game.Stat.Ability` | SO: attack, defense |
| `EnemyStat.cs` | `VitsehLand.Game.Stat` | SO: full enemy config + NavMesh params |
| `PlayerStat.cs` | `VitsehLand.Game.Stat` | SO: health, movement, stamina |
| `EnemyAbilityController.cs` | `VitsehLand.Game.Enemy` | Extends AbilityEntity (empty shell) |
| `EnemyHealthController.cs` | `VitsehLand.Game.Enemy` | Standalone health, chưa implement IDamageable |
| `HealthController.cs` | `VitsehLand.Game.Player` | Singleton, GameEvent observer, scene reload |

---

## ✅ NHÓM 1 — BUG FIXES (DONE)

### 1.1 Modifier timer không tick ✅
- `AbilityEntity.Update()` gọi `Stat.AbilityStatMediator.Update(Time.deltaTime)` ✅
- `AbilityStatMediator.Update()` loop + dispose `MarkedForRemoval` ✅
- ⚠️ **Note:** `AbilityStatModifier.Update(deltaTime)` gọi `timer?.Tick()` nhưng không truyền `deltaTime` vào — OK nếu `ImprovedTimers.CountdownTimer.Tick()` tự dùng `Time.deltaTime`. **Cần verify khi có vấn đề timeScale.**

### 1.2 runningVfx memory leak ✅
- `AbilityDestroyHandler` dùng `OnEnable` thay `Start` → pool-ready ✅
- ⚠️ **Known TODO:** `lifetime` mặc định `3f` cứng, chưa nhận `duration` từ Ability/Bottle. Cần fix khi implement `BottleAbilitySO`.

### 1.3 Pickup destroy trước khi Visit ✅
- `if (visitable == null) return` guard đã có ✅
- `Destroy(gameObject)` chỉ gọi sau `Accept` thành công ✅

### 1.4 TargetingStrategy là MonoBehaviour ✅
- `TargetingStrategy` là plain abstract C# class ✅
- `[SerializeReference]` trong `Ability.cs` serialize đúng ✅

### Extra: Lambda unsubscribe leak ✅ FIXED
**Pattern đúng đã apply:**
```csharp
// TargetingStrategy.cs
Action<AbilityStatType> MarkDirty = _ => _ctxDirty = true;  // _ parameter bắt buộc

// Handle()
targetingManager.owner.Stat.AbilityStatMediator.OnCacheInvalidated += MarkDirty;

// Cancel()
targetingManager.owner.Stat.AbilityStatMediator.OnCacheInvalidated -= MarkDirty;
```
- `OnDispose` lambda trong `AbilityStatMediator.AddModifier()` — **không cần unsubscribe**, fire-once khi Dispose ✅
- **Không dùng** `OnCacheInvalidated = null` vì sẽ xóa luôn subscription của `AbilityStat.InvalidateStatCache` ✅

---

## 🔲 NHÓM 2 — SCRIPTABLE OBJECTS (TODO — bước tiếp theo)

### 2.1 `BottleAbilitySO` ← **Ưu tiên cao nhất**
Cần chứa:
- `List<IEffectFactory<IDamageable>> effects` — serialize với `[SerializeReference]`
- `TargetingType` enum (thay `TargetingStrategy` reference trực tiếp)
- VFX refs (`castVfx`, `runningVfx`)
- `float duration` — truyền vào `AbilityDestroyHandler.lifetime` + `AbilityCastContext`
- `float tickInterval`, `int damagePerTick` — cho DOT effects
- `Sprite icon`
- `int maxSlots` (per bottle type?)
- `WeaponCompatibility` flags (AR, SMG, Shotgun, Sniper, Flamethrower, Grenade)
- Tier enum (T1–T4) theo GDD

### 2.2 `PlayerStatSO` mở rộng
Hiện có: `baseHealth`, `maxHealth`, `moveSpeed`, `runSpeed`, `jumpForce`, `maxStamina`
Cần thêm:
- `int maxBottleSlots = 2` (GDD: tối đa 2 bottle active)
- `int baseAttack` (để `AbilityBaseStat` có thể lấy từ PlayerStat)

### 2.3 `EnemySO` mở rộng
Hiện có: full NavMesh config + combat stats
Cần thêm:
- `EnemyType` enum: `Brute / Swarm / Necromancer`
- `Dictionary<DamageType, float> resistances` (hoặc `[0-1]` float per type)
- `bool implementsIDamageable` → thực ra cần implement thật trong `EnemyHealthController`

### 2.4 `BottleStat` / `AbilityBaseStat` mở rộng
Hiện `AbilityBaseStat` chỉ có `attack`, `defense`.
Cần thêm fields để drive `AbilityCastContext`:
- `float duration`
- `float tickInterval`
- `int damagePerTick`
- `float slowPercent`, `float freezeChance`, `float critMultiplier`...

---

## 🔲 NHÓM 3 — EFFECTS (TODO)

### `AbilityCastContext` cần mở rộng trước:
```csharp
// Hiện tại thiếu:
float slowPercent;
float freezeChance;
float freezeDuration;
bool isCrit;
float critMultiplier;
float knockbackForce;
float armorPenetration;
int stackCount;
```

### Effects cần implement (theo GDD bottles):
| Effect | Bottle dùng | Cơ chế |
|--------|------------|--------|
| `SlowEffect` | Frosteratrol | `AbilityStatModifier` giảm `moveSpeed` |
| `FreezeEffect` | Frosteratrol | Disable movement, % chance |
| `HealEffect` | Food items | Instant HP restore |
| `RegenEffect` | Omelet, Tomato Soup | `IntervalTimer` heal |
| `StealthEffect` | Soggy Bread | Toggle AI ignore |
| `BuffStatEffect` | Burstger (fireRate↑), Capsaicin (dmg↑) | Wrap `AbilityStatModifier` |
| `CritEffect` | Critical Souper | Override damage multiplier |
| `KnockbackEffect` | Dynamite | Physics impulse |
| `AOEOnHitEffect` | Dynamite, Voltaic | Trigger AOE khi projectile hit |
| `ChainLightningEffect` | Voltaic | Chain 4 targets, 60% dmg/chain |
| `SmokeEffect` | Fortunei | AoE 5m, 20s, fragment on kill |
| `ArmorPenEffect` | Phorbol | 50% armor pen + pierce stack |
| `StackDamageEffect` | Atropine | Stack ×7, reset on target swap |

---

## 🔲 NHÓM 4 — BOTTLE SLOT SYSTEM (TODO)

- `BottleSlotManager` — 2–3 slots, enforce limit, Observer → UI
- Equip/Unequip từ inventory
- Duration tracking + countdown UI per slot
- Stack rule: 2 cùng loại → refresh hay stack? **Chưa define**

---

## 🔲 NHÓM 5 — TARGETING + POOLING (TODO)

- `TargetingType` enum trong `BottleAbilitySO` (thay reference MonoBehaviour)
- `runningVfx` → `PoolableObject`
- Projectile → pool thay `Instantiate`
- `BottleVfxPoolSetup` auto-gen

---

## 🔲 NHÓM 6 — ENEMY INTEGRATION (TODO)

- `EnemyHealthController` implement `IDamageable` ← **blocker cho playtest**
- Enemy có `AbilityStatMediator` → nhận slow/freeze/debuff
- Enemy có thể dùng Effect ngược lại (poison player, slow player)
- `EnemyAbilityEntity` extends `AbilityEntity`, có SO riêng

---

## 🗺️ Thứ tự thực hiện đề xuất

```
[DONE] Nhóm 1 (all bugs + extra fixes)
    ↓
[NEXT] 2.1 BottleAbilitySO + 2.4 AbilityBaseStat mở rộng
    ↓
       2.2 PlayerStatSO + 2.3 EnemySO
    ↓
       AbilityCastContext mở rộng
    ↓
       3: SlowEffect, HealEffect, BuffStatEffect (đủ để test Frosteratrol + Burstger)
    ↓
       4.1 BottleSlotManager → 4.2 Equip/Unequip → 4.3 Duration UI
    ↓
       5.1 TargetingType enum → 5.2 VFX Pool
    ↓
       6.1 IDamageable Enemy → 6.2 AbilityStatMediator on Enemy
```

---

## ⚙️ Tech Notes

- **Timer system:** `ImprovedTimers` — `CountdownTimer`, `IntervalTimer`. Verify `Tick()` signature nếu gặp vấn đề timeScale.
- **Serialization:** `[SerializeReference]` cho polymorphic interfaces. Dùng `[MovedFrom]` attribute nếu rename class để tránh mất data SO.
- **Odin Inspector:** `[InlineEditor]`, `[Required]` đang dùng trong `AbilityEntity`.
- **Object Pooling:** Pattern đã note ở `AbilityDestroyHandler.Despawn()` và `ProjectileTargeting`. Chưa implement, dùng Instantiate/Destroy tạm.
- **Namespace convention:** Game logic → `VitsehLand.Game.*` | Stats → `VitsehLand.Game.Stat.*` | Core patterns → `VitsehLand.Core.Pattern.*`
- **IDamageable:** Interface dùng xuyên suốt Effect system. Enemy chưa implement — blocker lớn nhất cho playtest.

---

## 💡 Decisions & Notes

| Quyết định | Lý do |
|-----------|-------|
| `TargetingStrategy` là plain class, không MonoBehaviour | Để `[SerializeReference]` serialize được vào SO |
| `AbilityCastContext` là struct | Copy by value → snapshot an toàn khi fire projectile |
| Effect factory pattern thay hardcode | Extensible, không cần sửa `Ability.Execute` khi thêm effect mới |
| `OnCacheInvalidated` event thay poll | Tránh O(n) PerformQuery mỗi frame, cache hit O(1) |
| `MarkDirty` field thay lambda ẩn danh | Unsubscribe đúng, tránh event leak |
| Không dùng `OnCacheInvalidated = null` | Sẽ xóa luôn `AbilityStat.InvalidateStatCache` subscription |
| `OnDispose` lambda trong AddModifier không cần unsubscribe | Fire-once pattern, modifier bị remove sau khi fire |

---

*Last updated: Nhóm 1 hoàn thành. Bước tiếp: Nhóm 2 — BottleAbilitySO.*
