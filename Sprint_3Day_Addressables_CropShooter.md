# 🗓️ Sprint 3 Ngày — Addressables Setup · Crop Shooter
> Dựa trên TODO v3.0 · GDD v300326 · DataSpec v3.0

---

## Ngày 1 — Foundation: Dọn dẹp & Cấu hình Addressables

> **Mục tiêu:** Project sạch, Addressables + SmartAddresser sẵn sàng nhận asset.

### 0. Folder Cleanup

- [x] Gộp `Prefabs/Product/` vào `Prefabs/Products/`
- [x] Đổi `Art/Resources/` → `Art/NaturalResourcesArt/`
- [x] Đổi `Art/Sprites/Icons/Potions/` → `Icons/Bottles/`
- [x] Tạo folder còn thiếu:
  - [x] `Prefabs/Gadgets/`
  - [x] `Prefabs/VFX/`
  - [x] `GameData/Gadget/`
  - [x] `GameData/Construction/{***}/Upgrade/`
  - [x] `GameData/Construction/{***}/Upgrade/Options` (optional)
  - [ ] `GameData/Registry/`
  - [x] `Audio/SoundEffects/`
  - [x] `Audio/Soundtrack/`

### 1. Addressables Groups

- [x] Tạo **LocalCore** — Local · Pack Together · Prevent Updates: ON
- [x] Tạo **SharedAssets** — Local · Pack Together · Prevent Updates: ON
- [x] Tạo **Remote_Day5_6** — Pack Together · Prevent Updates: OFF
- [x] Tạo **Remote_Day7_9**
- [x] Tạo **Remote_Day10_12**
- [x] Tạo **Remote_Day13_16**
- [x] Tạo **Remote_Day17_Plus**
- [x] Tạo **OTA_Events** — Pack Separately · Prevent Updates: OFF
- [x] Tạo **OTA_LiveConfig** — Pack Separately · Prevent Updates: OFF
- [ ] Configure Remote Load Path: `https://cdn.cropshooter.com/[BuildTarget]/[hash]`

### 2. SmartAddresser — Group Rules

**LocalCore:**
- [ ] `Assets/Prefabs/Construction/Shared/**` → LocalCore
- [ ] `Assets/GameData/Resource/Farming Product/**` + SO.unlockDay ≤ 4 → LocalCore
- [ ] `Assets/GameData/Resource/Natural/**` + SO.unlockDay ≤ 4 → LocalCore
- [ ] `Assets/GameData/Resource/Crafting Product/**` + SO.unlockDay ≤ 4 → LocalCore
- [ ] `Assets/GameData/Construction/**` + SO.unlockDay ≤ 4 → LocalCore
- [ ] `Assets/Prefabs/Crops/Day1_3/**` → LocalCore
- [ ] `Assets/GameData/Registry/**` → LocalCore
- [ ] `Assets/Prefabs/UI/**` → LocalCore
- [ ] Scene files → LocalCore

**Remote theo Day:**
- [ ] `Assets/Prefabs/Crops/Day5_6/**` → Remote_Day5_6
- [ ] `Assets/Prefabs/Crops/Day7_9/**` → Remote_Day7_9
- [ ] `Assets/Prefabs/Crops/Day10_12/**` → Remote_Day10_12
- [ ] `Assets/Prefabs/Crops/Day13_16/**` → Remote_Day13_16
- [ ] `Assets/Prefabs/Crops/Day17_Plus/**` → Remote_Day17_Plus
- [ ] SO unlockDay 5–6 → Remote_Day5_6
- [ ] SO unlockDay 7–9 → Remote_Day7_9
- [ ] SO unlockDay 10–12 → Remote_Day10_12
- [ ] SO unlockDay 13–16 → Remote_Day13_16
- [ ] SO unlockDay ≥ 17 → Remote_Day17_Plus
- [ ] `Prefabs/Construction/Pond/**` + `Coop/**` → Remote_Day7_9
- [ ] `Prefabs/Gadgets/**` + SO.unlockDay range → Remote tương ứng

**OTA:**
- [ ] `GameData/OTA/LiveConfig/**` → OTA_LiveConfig · label: `live_config`
- [ ] `**/OTA/Events/{eventName}/**` → OTA_Events · label: `seasonal_{eventName}`

### 3. SmartAddresser — Label Rules

- [ ] `GameData/Resource/Farming Product/**` → label: `crop`
- [ ] `GameData/Ammo/**` → label: `crop`
- [ ] `GameData/Resource/Crafting Product/Ingredients/` → label: `ingredient`
- [ ] `GameData/Resource/Crafting Product/Food/` → label: `food`
- [ ] `GameData/Resource/Crafting Product/Bottles/` → label: `bottle`
- [ ] `GameData/Resource/Natural/**` → label: `natural`
- [ ] `GameData/Construction/**` → label: `building`
- [ ] `GameData/Gadget/**` → label: `gadget`
- [ ] `GameData/Registry/**` → label: `ui_registry`
- [ ] `Audio/SoundEffects/**` → label: `sfx`
- [ ] `Audio/Soundtrack/**` → label: `music`
- [ ] `Prefabs/VFX/**` → label: `vfx`

### 4. SmartAddresser — Address Rules

- [ ] Address = filename không extension (`Berry.asset` → `"Berry"`)
- [ ] Validate toàn bộ rule → 0 warning
- [ ] Test với `Beetroot` → verify group + label + address đúng

---

## Ngày 2 — Data: ScriptableObjects & Icons

> **Mục tiêu:** Toàn bộ SO data và icon hoàn chỉnh. Registry SO sẵn sàng.

### 5. Crop SO (15 total) — `GameData/Crops`

- [ ] Berry, Wheat, Bean, Carrot, Cabbage, Coconut *(Day 1–3)*
- [ ] Beetroot, Tomato *(Day 5–6)*
- [ ] Grape *(Day 7–9)*
- [ ] Carambola, Chili *(Day 10–12)*
- [ ] Apple, Pepper *(Day 13–16)*
- [ ] Durian, NoniFruit *(Day 17+ · WIP)*

### 6. Crafting Product SO — `GameData/Resource/Crafting Product/`

**Ingredients (14):** — `Ingredients/`
- [ ] Flour, PowerCore, Circuit, BeanOil, CoconutOil, Margarine, Sugar, GlassVialLv1, CabbageSauce, Cream, GlassVialLv2, PoisonShard, AcidShard, GlassVialLv3

**Food (15):** — `Food/`
- [ ] Bread, SoggyBread, BerryCake, BurgerBerry, Omelet, HotBunny, CarrotCake, SweetGrapeball, TomatoSoup, Burnwich, RedAlertSalad, CarambolaCake, ApplePie, FreshSalad, HoneyCake

**Bottles (9):** — `Bottles/`
- [ ] Tạo SO còn thiếu

### 7. Gadget SO (8) — `GameData/Gadget/`

- [ ] Drill, WaterPump, Apiary, CropTurret, MedStation, RefinaryLink, TurretLink, MarketLink

### 8. Upgrade SO

- [ ] `GameData/Upgrade/Gear/` → GearUpgradeInfo SO
- [ ] `GameData/Upgrade/Options/{BuildingName}/` → UpgradeOptionInfo per building

### 9. Fix Data Corruption

- [ ] Fix fireRate, lifeTime, reloadSpeed: Carambola, Durian, Wheat, Grape, Bean, Tomato, Chili, Noni
- [ ] Fix durabilityModifier: Iron → 1.5 · GoldCrystal → 2.0

### 10. Registry SO — `GameData/Registry/`

- [ ] `CropRegistry.asset`
- [ ] `BottleRegistry.asset`
- [ ] `BuildingRegistry.asset`
- [ ] `SharedUIData.asset`

### 11. Icons — `Art/Sprites/Icons/`

> Import settings: Sprite · Max Size 128px · Crunch Compression

- [ ] `Icons/Crops/` — 15 icon: Berry, Wheat, Bean, Carrot, Cabbage, Coconut, Beetroot, Tomato, Grape, Carambola, Chili, Apple, Pepper, Durian, NoniFruit
- [ ] `Icons/NaturalResources/` — 16 icon: MonsterMeat, MetalScrap, Sand, Trash, Iron, PowerShard, Copper, Wood, Stone, Coal, Egg, CoconutMilk, Honey, Ruby, GoldCrystal, CoalShallow
- [ ] `Icons/Food/` — 15 icon: Bread, SoggyBread, BerryCake, BurgerBerry, Omelet, HotBunny, CarrotCake, SweetGrapeball, TomatoSoup, Burnwich, RedAlertSalad, CarambolaCake, ApplePie, FreshSalad, HoneyCake
- [ ] `Icons/Gadgets/` — 8 icon: Drill, WaterPump, Apiary, CropTurret, MedStation, RefinaryLink, TurretLink, MarketLink
- [ ] `Icons/Ingredients/` — 14 icon: Flour, PowerCore, Circuit, BeanOil, CoconutOil, Margarine, Sugar, GlassVialLv1, CabbageSauce, Cream, GlassVialLv2, PoisonShard, AcidShard, GlassVialLv3
- [ ] Assign icon vào Registry SO tương ứng

---

## Ngày 3 — Prefabs & Build Verification

> **Mục tiêu:** Prefab hoàn chỉnh, build sạch, không duplicate, không warning.

### 12. Crop Prefabs

**Day 1–3 → LocalCore** — `Prefabs/Crops/Day1_3/`
- [ ] Berry, Wheat, Bean, Carrot, Cabbage, Coconut
- [ ] Batch setup bằng `CropPrefabSetup` tool
- [ ] Assign vào `FarmingCropStat.growingBody` + `defaultModelPlant`

**Day 5–6 → Remote_Day5_6** — `Prefabs/Crops/Day5_6/`
- [ ] Beetroot, Tomato

**Day 7–9 → Remote_Day7_9** — `Prefabs/Crops/Day7_9/`
- [ ] Grape

**Day 10–12 → Remote_Day10_12** — `Prefabs/Crops/Day10_12/`
- [ ] Carambola, Chili

**Day 13–16 → Remote_Day13_16** — `Prefabs/Crops/Day13_16/`
- [ ] Apple, Pepper

**Day 17+ → Remote_Day17_Plus** — `Prefabs/Crops/Day17_Plus/`
- [ ] Durian, NoniFruit *(WIP)*

### 13. Ammo Prefabs — `Prefabs/Ammo/Normal/`

- [ ] Berry, Wheat, Bean, Tomato, Grape, Carambola, Chili, Apple, Pepper
- [ ] Assign vào `AttackingCropStat` tương ứng
> Carrot, Cabbage, Coconut — bỏ qua, không có AttackingCropStat.

### 14. Building Prefabs — `Prefabs/Construction/`

**LocalCore (Day 1–4):**
- [ ] Garden, WaterPurifier, FarmHouse, FarmMarket, Refinery, BuildersShop, FabricateGadget, Silo, TreasurePod
- [ ] Assign SO + tạo `UpgradeOptionInfo` tại `GameData/Upgrade/Options/{BuildingName}/`
- [ ] Cập nhật `BuildingRegistry.asset`

**Remote_Day7_9:**
- [ ] Pond, Coop

### 15. Gadget Prefabs — `Prefabs/Gadgets/`

- [ ] Drill *(Day 4 · LocalCore)*
- [ ] WaterPump, Apiary *(Day 7–9)*
- [ ] CropTurret *(Day 10–12)*
- [ ] MedStation, RefinaryLink, TurretLink *(Day 13–16)*
- [ ] MarketLink *(Day 17+)*

### 16. VFX Prefabs — `VFX/Prefabs/`

- [ ] SeedEffect, GrowEffect, HarvestEffect *(shared, tất cả crop)*
- [ ] Trail: AR, SMG, Shotgun, Sniper, Grenade, Flamethrower, ToxicGrenade
- [ ] HitEffect: AR, Shotgun, Grenade, Flamethrower
- [ ] Assign vào `AttackingCropStat.trailTracer` + `hitEffectPrefab`

### 17. Natural Resource & Product Prefabs

- [ ] `Prefabs/NaturalResources/` — IronOre_Node, CopperOre_Node, SandDeposit_Node, CoalVein_Node, RubyDeposit_Node, GoldCrystal_Node
- [ ] Assign vào `NaturalResourceStat` tương ứng
- [ ] `Prefabs/Products/Normal/` + `Products/Pack/` — tạo còn thiếu

### 18. Shared Assets & Build

- [ ] Build Addressables *(Play Mode = Use Asset Database)*
- [ ] Chạy **Analyze → Check Duplicate Bundle Dependencies**
- [ ] Move duplicate vào `SharedAssets` group
- [ ] Rebuild → Analyze lại → 0 warning

### 19. Checklist Release

- [ ] SmartAddresser Validate — 0 warning
- [ ] Tất cả Registry SO không có null entry
- [ ] Tất cả RecipeData đủ slot
- [ ] Không có asset trong `Resources/` folder
- [ ] Internal Asset Naming: **Dynamic**
- [ ] Compression: Local **LZ4** · Remote/OTA **LZMA**
- [ ] Catalog Update on Startup: **enabled**
- [ ] Remote groups: Prevent Updates **OFF** · Local: **ON**
- [ ] CRC: Local Disabled · Remote/OTA Enabled Excluding Cached
- [ ] Max Concurrent Web Requests: **5–8**
- [ ] Build Addressables → Build Player

---

*Sprint 3 Ngày · Crop Shooter Addressables · 06/04/2026*
