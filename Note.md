Construction_Summary
Update

https://notebooklm.google.com/notebook/a737ade8-2d7e-4871-91f2-59fb8dbbf9a3?addSource=true
machinations.io

done flow addressable data (đang hoàn thiện ability modifier 60%)
done ui (simple navigator), game flow (playtest), ai,...
done game design (còn enemy behaviour) polish save load
full workflow document optimize
puzzle porfolio.

Schedule:
Addressable (tạm thời vừa làm vừa update và edit doc, follow rule cũ). Ưu tiên update lại các file này để setup addressable trong project nhanh hơn
DataSpec, SO (tạo SO mẫu cùng các prefab/SO/Script trươc trong project sau đó test import trước khi update toàn bộ flow vào Data Binding)
Update MD/HTML, Unlock_Timeline,..
GDD

Details: 
# Crop Shooter — Development Timeline
> Version 010526 · FPS Farming Survival · Target: Playable Build

---

## ✅ Completed

| Group | Features | Status |
|---|---|---|
| Group 1 — Bug Fixes | Modifier timer, VFX memory leak, Pickup destroy, TargetingStrategy refactor | ✅ |
| Group 1 — Stat Pipeline | AbilityCastContext struct, IEffectFactory in keyword, CachedCtx, OnCacheInvalidated event, float migration | ✅ |
| Group 2 — ScriptableObject | BottleStat, AbilityBaseStat, PlayerStat, EnemyStat, GlobalAbilityConfig, BottleSlotManager | ✅ |
| Group 2 — Entity Setup | PlayerAbilityController, PlayerHealthController (IDamageable + IHealable), EnemyAbilityManager, EnemyHealthController, EnemyController refactor | ✅ |
| Group 3 — Effects (partial) | HealEffect, RegenEffect, BuffStatEffect, DamageOneShotEffect, DamageOverTimeEffect, KnockbackEffect — all migrated to IEffectApplicable | ✅ |
| Group 3 — Interface Design | IEffectApplicable, IHealable, IDamageable separation, TakeEffectDamage pipeline | ✅ |
| Group 3 — Crit | Removed CritEffect — crit handled via BuffStatEffect(CritChance + CritMultiplier) | ✅ |
| Systems | UI (simple navigator), Game flow, Basic AI, Save/Load (partial) | ✅ |

---

## 🗓️ Pre-Deadline: Target xxx

### xxx — AI Foundation + Map
- [ ] NavMesh bake on existing map asset
- [ ] Brute AI: NavMesh chase + melee attack (simple FSM)
- [ ] Animator sync — prevent slide
- [ ] **Unlocks:** SlowEffect + FreezeEffect testable

### xxx — Group 3 Complete
- [ ] `SlowEffect` + Factory — reduce `NavMeshAgent.speed` by `slowPercent`, restore on expire
- [ ] `FreezeEffect` + Factory — set speed = 0, disable AI, restore after `freezeDuration`
- [ ] `BottleSlotManager` duration tracking — bottle auto-expire after `activeDuration`

### xxx — Construction System

| Construction | Priority | Reason |
|---|---|---|
| Gear Upgrades (Heart / Boost / Energy / Backpack / Water) | 🔴 Highest | Uses existing modifier pipeline — wire SO only |
| Farm House (Sleep + speed buff) | 🔴 High | BuffStatEffect + HealEffect already done |
| Med Station | 🟡 Medium | HealEffect done, add proximity trigger |
| Farm Market (simple fixed price) | 🟡 Medium | Simple economy first, Perlin Noise later |
| Crafting Station upgrades (queue expand, craft speed) | 🟡 Medium | Logic exists, add slot count modifier |
| Silo | 🟠 Low | New storage system |
| Garden upgrades (Sprinkler, Auto Harvest) | 🟠 Low | Farming loop |
| Water Purifier upgrades | 🟠 Low | Farming loop |
| Pond | 🟠 Low | Farming loop |
| Coop | 🔵 Post-deadline | Animal AI required |
| Crop Turret | 🔵 Post-deadline | Enemy system must be complete |
| WarpTech (Refinery Link / Turret Link / Market Link) | 🔵 Post-deadline | Late-game feature |
| Builder's Shop | 🔵 Post-deadline | Blueprint unlock system |
| Treasure Pod | 🔵 Post-deadline | Level design dependent |
| Fabricate Gadget | 🔵 Post-deadline | Gadget system |
| Refinery | 🔵 Post-deadline | Storage system |

### xxx — CV-Critical Features
- [ ] **Save/Load** — JSON-based, covers player progression + settings
- [ ] **Addressable** — basic asset loading pipeline setup
- [ ] **Simple Guide** — in-game UI page or HTML doc

---

## 🗓️ Extended: Target xxx

### xxx — AI + Economy + Tools
- [ ] Swarm AI — clone Brute, tweak speed/HP, validate AOE effects
- [ ] Farm Market dynamic pricing — Perlin Noise + supply/demand differential
- [ ] Remote Config — balance values via Addressable remote (no hardcode)
- [ ] CSV ↔ SO Importer/Exporter — `Assets/Editor/Tools/SOImporter/` (after SO structure is frozen)

### xxx — Polish + Optimize
- [ ] GPU/CPU profiler pass — identify bottlenecks
- [ ] Object Pool audit (Group 5) — VFX + Projectile pooling
- [ ] `StealthEffect` + Factory — pending enemy AI perception
- [ ] Necromancer AI — ranged + summon behavior (if time permits)
- [ ] Save/Load full — inventory, bottle slots, construction state
- [ ] Game polish — juice, VFX, SFX pass

---

## 📋 CV Checklist

| Feature | Status | Notes |
|---|---|---|
| Ability system — Effect / Modifier / SO pipeline | ✅ Done | Factory, Strategy, Observer, Visitor patterns |
| Stat system — Query, Mediator, Cache | ✅ Done | Float migration, nullable cache |
| Interface design — IDamageable, IEffectApplicable, IHealable | ✅ Done | Bidirectional player ↔ enemy |
| ScriptableObject data pipeline | ✅ Done | BottleStat, AbilityBaseStat, GlobalAbilityConfig |
| NavMesh AI | 📅 xxx | Brute + Swarm |
| Construction system | 📅 xxx | Gear Upgrades priority |
| Save / Load | 📅 xxx | JSON-based |
| Addressable | 📅 xxx | Basic setup |
| Remote Config | 📅 xxx | Balance values |
| CSV ↔ SO Import / Export | 📅 xxx | Editor tool, post SO freeze |
| GPU / CPU Optimization | 📅 xxx | Profiler pass |
| Object Pooling (Group 5) | 📅 xxx | VFX + Projectile |
| Economy — Dynamic pricing | 📅 xxx | Perlin Noise + supply/demand |
| Simple Guide | 📅 xxx | In-game or HTML |

---

## ⏳ Pending — Blocked by Dependencies

| Feature | Blocked by |
|---|---|
| `SlowEffect` / `FreezeEffect` | NavMesh AI (xxx) |
| `StealthEffect` | Enemy AI perception system |
| Crop Turret | Enemy system complete |
| Necromancer AI | Tactical AI research (Part 27, 29, 41) |
| Turret Link / Market Link | Crop Turret + Farm Market done |
| Full Save/Load | Construction system state |

---

## 🏗️ Architecture Notes

- **AI Plan (by group):**
  - Core Navigation: Part 1, 32, 33 before xxx — Part 2, 25 after
  - Animation: Part 3 before xxx — Part 42, 39 after
  - Decision Making: Simple FSM or Part 48 BT before xxx — GOAP, Unity Behavior after
  - Tactical AI: All post-deadline (Part 27, 29, 40, 41, 44)

- **CSV ↔ SO Importer location:** `Assets/Editor/Tools/SOImporter/`
  - Build after SO structure is frozen (post xxx)
  - Pipeline: CSV → SO assets → Addressable Groups → Runtime load

- **Construction fast-track:** Gear Upgrades, Farm House, Med Station reuse existing
  `AbilityStatModifier` + `HealEffect` pipeline — no new systems required

> ⚠️ Confirm before starting AI implementation.
