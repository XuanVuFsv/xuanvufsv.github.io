# Recipe Diagram — Crop Shooter Survival

> **Legend:** 🟢 Crop · 🔵 Natural / Coop · 🟣 Ingredient · 🔴 Food · 🔵⬜ Bottle · 🟡 Special Craft

---

## Table of Contents
1. [Crops](#crops)
2. [Natural & Coop Drops](#natural--coop-drops)
3. [Ingredients](#ingredients)
4. [Food Recipes](#food-recipes)
5. [Consumable Summary — Food & Bottles](#consumable-summary--food--bottles)
6. [Bottles](#bottles)
7. [Special Crafts](#special-crafts)
8. [Recipe Progression by Day](#recipe-progression-by-day)
9. [Use Cases — Ammo Reference](#use-cases--ammo-reference)
10. [Usage Balance](#usage-balance)

---

## Recipe Slot Rules (3 slots)

- Quy tắc ingame: **Mọi recipe luôn phải có đúng 3 slot** (3 cụm `Item ×N`).
- Nếu recipe chỉ có **2 thành phần** `A×m + B×n`, hãy **tách 1 thành phần** thành 2 slot để đủ 3:
    - `A×m + B×n` → `A×a + B×n + A×(m−a)` (với `1 ≤ a < m`)
- Ưu tiên tách thành phần có số lượng lớn hơn / dễ chia hơn.
- Ví dụ:
    - `🍇 Grape ×16 + 🍬 Sugar ×1` → `🍇 Grape ×8 + 🍬 Sugar ×1 + 🍇 Grape ×8`
    - `🛢️ Bean Oil ×3 + 🧴 Coconut Oil ×1` → `🛢️ Bean Oil ×2 + 🧴 Coconut Oil ×1 + 🛢️ Bean Oil ×1`
    - `🧪 Vial Lv1 ×2 + 💎 Ruby ×2` → `🧪 Vial Lv1 ×1 + 💎 Ruby ×2 + 🧪 Vial Lv1 ×1` (hoặc tách Ruby tương tự)

---

## Crops

| Icon | Name | Unlock Day | Unlock Trigger |
|------|------|-----------|----------------|
| 🫐 | Berry | Day 1 | — |
| 🌾 | Wheat | Day 1 | — |
| 🌱 | Bean | Day 3 | — |
| 🥕 | Carrot | Day 3 | — |
| 🥬 | Cabbage | Day 3 | — |
| 🥥 | Coconut | Day 3 | — |
| 🫚 | Beetroot | Day 5 | — |
| 🍅 | Tomato | Day 6 | 🗡 Kill 300 monsters *(can unlock earlier)* |
| 🍇 | Grape | Day 8 | 📦 Open a Treasure Pod |
| ⭐ | Carambola | Day 10 | ⚔️ Defeat first Boss |
| 🌶️ | Chili | Day 10 | — |
| 🍎 | Apple | Day 15 | — |
| 🫑 | Pepper | Day 15 | — |
| 🌵 | Durian *(WIP)* | Day 20 | — |
| 🍈 | Noni Fruit *(WIP)* | Day 20 | — |

---

## Natural & Coop Drops

| Icon | Name | Type | Day | Source |
|------|------|------|-----|--------|
| 💀 | Monster Meat | Natural | Day 1 | 👾 Night wave drop |
| 🔧 | Metal Scrap | Natural | Day 1 | ⛏ Mine — Ruins |
| 🟡 | Sand | Natural | Day 1 | ⛏ Mine — Beach |
| 🗑️ | Trash | Natural | Day 1 | ⛏ Mine — Ruins |
| 🔩 | Iron | Natural | Day 1 | ⛏ Mine — Surface |
| ⚡ | Power Shard | Natural | Day 1 | ⛏ Mine — Surface |
| 🟤 | Copper | Natural | Day 1 | ⛏ Mine — Surface |
| 🌲 | Wood | Natural | Day 1 | 🌲 Chop trees *(Builder's Shop — WIP)* |
| 🪨 | Stone | Natural | Day 1 | ⛏ Mine — Surface *(Builder's Shop — WIP)* |
| 🥚 | Egg | Coop | Day 7 | 🐔 Coop reproduction *(Trigger: 🏗 Build Coop)* |
| 🍯 | Honey | Natural | Day 7 | 🤖 Apiary Gadget *(Trigger: Place first Apiary Gadget)* |
| 🖤 | Coal | Natural | Day 10 | ⛏ Mine — Caves |
| 💎 | Ruby | Natural | Day 15 | ⛏ Mine — Deep Caves |
| 💛 | Gold Crystal | Natural | Day 20 | ⛏ Mine — Mountains |

---

## Ingredients

All crafted at ⚗️ Crafting Station.

| Icon | Name | Day | Recipe |
|------|------|-----|--------|
| 🥐 | Flour | Day 1 | 🌾 Wheat ×9 (3×3) |
| 🔋 | Power Core | Day 1 | ⚡ Power Shard ×1 + 🔧 Metal Scrap ×1 + 🔩 Iron ×1 |
| 💡 | Circuit | Day 1 | ⚡ Power Shard ×1 + 🔧 Metal Scrap ×1 + 🟤 Copper ×1 |
| 🛢️ | Bean Oil | Day 3 | 🌱 Bean ×9 (3×3) |
| 🧴 | Coconut Oil | Day 3 | 🥥 Coconut ×9 (3×3) |
| 🥛 | Coconut Milk | Day 3 | 🥥 Coconut ×9 (3×3) |
| 🧈 | Margarine | Day 3 | 🛢️ Bean Oil ×3 + 🧴 Coconut Oil ×1 |
| 🍬 | Sugar | Day 5 | 🫚 Beetroot ×9 (3×3) |
| 🧪 | Glass Vial Lv1 | Day 5 | 🟡 Sand ×9 (3×3) |
| 🥣 | Cabbage Sauce | Day 6 | 🥬 Cabbage ×8 + 🍬 Sugar ×1 |
| 🍦 | Cream | Day 10 | 🥛 Coconut Milk ×3 + 🍬 Sugar ×1 + 🥚 Egg ×6 |
| 🔬 | Glass Vial Lv2 | Day 15 | 🧪 Vial Lv1 ×2 + 💎 Ruby ×2 |
| ☠️ | Poison Shard | Day 15 | 🗑️ Trash ×6 + 🟡 Sand ×3 |
| 💧 | Acid Shard | Day 15 | 🗑️ Trash ×6 + 🔧 Metal Scrap ×3 |
| ⚗️ | Glass Vial Lv3 | Day 20 | 🔬 Vial Lv2 ×2 + 💛 Gold Crystal ×2 |

---

## Food Recipes

All crafted at ⚗️ Crafting Station.

| Icon | Name | Day | HP | Mechanic | Recipe |
|------|------|-----|----|----------|--------|
| 🍞 | Bread | Day 5 | +5 HP | Heal | 🥐 Flour ×1 + 🍬 Sugar ×1 + 🥐 Flour ×1 |
| 🍳 | Omelet | Day 7 | +25 HP | **REGEN** — +HP regen after eating | 🥚 Egg ×18 (3×6) |
| 🥖 | Soggy Bread | Day 5 | +30 HP | **STEALTH** — Monsters ignore you temporarily | 🥐 Flour ×1 + 💀 Monster Meat ×4 |
| 🎂 | Berry Cake | Day 5 | +20 HP | **BOTTLE** → Frost Bottle | 🥐 Flour ×1 + 🫐 Berry ×8 + 🍬 Sugar ×1 |
| 🍔 | Burger Berry | Day 6 | +25 HP | **BOTTLE** → Rapidfire Bottle | 🥐 Flour ×1 + 🥬 Cabbage ×4 + 🫐 Berry ×8 |
| 🍡 | Sweet Grapeball | Day 8 | +20 HP | **BOTTLE** → Cluster Bottle | 🍇 Grape ×8 + 🍬 Sugar ×1 + 🍇 Grape ×8 |
| 🥪 | Hot Bunny | Day 8 | +15 HP | **CRAFT** — Ap-pleClear Ca-Rotket (1/3) | 🥕 Carrot ×4 + 🧈 Margarine ×1 + 🥕 Carrot ×4 |
| 🧁 | Carrot Cake | Day 8 | +40 HP | **CRAFT** — Ap-pleClear Ca-Rotket (2/3) | 🥕 Carrot ×5 + 🥛 Coconut Milk ×3 + 🍬 Sugar ×1 |
| 🍲 | Tomato Soup | Day 10 | +75 HP ↑ | **BOTTLE** → Crit Bottle | 🍅 Tomato ×8 + 🧈 Margarine ×1 + 🍬 Sugar ×1 |
| 🌭 | Burnwich | Day 13 | +35 HP | **BOTTLE** → Blaze Bottle | 🥐 Flour ×1 + 🌶️ Chili ×8 + 🥣 Cabbage Sauce ×1 |
| 🔥 | Red Alert Salad | Day 13 | +50 HP | **BOTTLE** → Venom Bottle | 🌶️ Chili ×8 + 🍅 Tomato ×8 + 🥕 Carrot ×4 |
| 🌟 | Carambola Cake | Day 13 | +60 HP | **BOTTLE** → Arc Bottle | ⭐ Carambola ×10 + 🥛 Coconut Milk ×3 + 🥣 Cabbage Sauce ×1 |
| 🥧 | Apple Pie | Day 16 | +100 HP | **CRAFT** — Ap-pleClear Ca-Rotket (3/3) | 🍎 Apple ×10 + 🥐 Flour ×1 + 🍦 Cream ×1 |
| 🥗 | Fresh Salad | Day 16 | +150 HP ↑ | **BOTTLE** → Corrosion Bottle | 🍅 Tomato ×8 + ⭐ Carambola ×10 + 🫑 Pepper ×10 |
| 🍰 | Honey Cake | Day 16 | +80 HP | **BOTTLE** → Miasma Bottle | 🍯 Honey ×6 + 🥐 Flour ×1 + 🥛 Coconut Milk ×3 |

> ↑ = includes HP regeneration effect

---

## Consumable Summary — Food & Bottles

Danh sách tất cả items có thể tiêu thụ trực tiếp, kèm hiệu ứng nhận được.

### 🍽️ Food — Ăn trực tiếp để hồi máu / nhận buff

| Icon | Name | Day | HP Restored | Bonus Effect |
|------|------|-----|------------|--------------|
| 🍞 | Bread | Day 5 | +5 HP | — |
| 🥖 | Soggy Bread | Day 5 | +30 HP | **Stealth** — quái vật bỏ qua bạn tạm thời |
| 🎂 | Berry Cake | Day 5 | +20 HP | — *(nguyên liệu Frost Bottle)* |
| 🍔 | Burger Berry | Day 6 | +25 HP | — *(nguyên liệu Rapidfire Bottle)* |
| 🍳 | Omelet | Day 7 | +25 HP | **Regen** — hồi HP liên tục sau khi ăn |
| 🍡 | Sweet Grapeball | Day 8 | +20 HP | — *(nguyên liệu Cluster Bottle)* |
| 🥪 | Hot Bunny | Day 8 | +15 HP | — *(craft step 1/3)* |
| 🧁 | Carrot Cake | Day 8 | +40 HP | — *(craft step 2/3)* |
| 🍲 | Tomato Soup | Day 10 | +75 HP ↑ | **Regen** — hồi HP liên tục *(nguyên liệu Crit Bottle)* |
| 🌭 | Burnwich | Day 13 | +35 HP | — *(nguyên liệu Blaze Bottle)* |
| 🔥 | Red Alert Salad | Day 13 | +50 HP | — *(nguyên liệu Venom Bottle)* |
| 🌟 | Carambola Cake | Day 13 | +60 HP | — *(nguyên liệu Arc Bottle)* |
| 🥧 | Apple Pie | Day 16 | +100 HP | — *(craft step 3/3)* |
| 🥗 | Fresh Salad | Day 16 | +150 HP ↑ | **Regen** — hồi HP liên tục *(nguyên liệu Corrosion Bottle)* |
| 🍰 | Honey Cake | Day 16 | +80 HP | — *(nguyên liệu Miasma Bottle)* |

> **Lưu ý:** Food đánh dấu *(nguyên liệu Bottle)* vẫn có thể ăn trực tiếp để hồi máu — nhưng tiêu thụ nguồn cung bottle. Cân nhắc ưu tiên trước khi ăn.

### 🧪 Bottles — Sử dụng trên vũ khí để kích hoạt hiệu ứng chiến đấu

Xem chi tiết hiệu ứng tại [mục Bottles](#bottles) bên dưới.

| Icon | Name | Tier | Duration | Effect tóm tắt |
|------|------|------|----------|----------------|
| 🧊 | Frost Bottle | T1 | 12s | Làm chậm · đóng băng · tăng dmg nhận |
| ⚡ | Rapidfire Bottle | T1 | 7s | Tăng tốc độ bắn, trade-off độ chính xác |
| 🎯 | Crit Bottle | T2 | 10s | Crit 100% · ×2.5 dmg · headshot bonus |
| 🔆 | Blaze Bottle | T3 | 10s | Tăng dmg · fire trail visual · rocket proc |
| 🐍 | Venom Bottle | T3 | 12s | Stack độc tối đa 7 lần, reset khi đổi target |
| 💥 | Cluster Bottle | T3 | 8s | Proc bom gắn lên enemy, nổ AoE sau delay |
| 🟢 | Corrosion Bottle | T3 | 10s | Xuyên giáp 50% + stack dmg tăng dần |
| 🌩️ | Arc Bottle | T4 | 8s | Chain điện 4 mục tiêu |
| ☁️ | Miasma Bottle | T4 | 12s | Cloud độc AoE · drop buff khi giết enemy |

---

## Bottles

All crafted at ⚗️ Crafting Station.

---

### Tier 1 (Day 5–8)

#### 🧊 Frost Bottle — *"Chill & Punish"*
> **Day 5 · Duration: 12s · Compatible: SMG · AR**

| Attribute | Value |
|-----------|-------|
| Recipe | 🎂 Berry Cake ×8 + 🧪 Vial Lv1 ×1 + 🔩 Iron ×2 |
| Slow | 30–70% movement speed reduction |
| Freeze | 25% chance → frozen for **1.5s** |
| Damage amp | Enemy nhận +**40%** dmg khi đang bị Slow/Freeze |

**Cơ chế:** Đạn bắn trúng làm chậm enemy. Mỗi phát có 25% cơ hội kích hoạt Freeze cứng người trong 1.5s — trong thời gian đó enemy nhận thêm 40% dmg từ mọi nguồn.

**🎯 Best against:**
- 🏃 **Sprinter** *(cận chiến tốc độ cao)* — Frost kéo giảm tốc độ lao vào, cho thời gian xử lý
- 🛡️ **Armored Charger** *(cận chiến giáp dày)* — Freeze 1.5s tạo cửa sổ burst dmg qua giáp
- 🐝 **Swarm** *(bay theo bầy, nhỏ)* — SMG spread bắn nhiều, nhiều con bị Slow cùng lúc

---

#### ⚡ Rapidfire Bottle — *"Speed or Accuracy"*
> **Day 6 · Duration: 7s · Compatible: AR · SMG · Shotgun**

| Attribute | Value |
|-----------|-------|
| Recipe | 🍔 Burger Berry ×8 + 🧪 Vial Lv1 ×1 + 🔩 Iron ×2 |
| Fire rate | +50% |
| Spread penalty | +25% bullet spread (trade-off) |

**Cơ chế:** Tăng tốc độ bắn đáng kể nhưng súng bị giãn đạn. Hiệu quả nhất khi áp sát hoặc bắn vào nhóm đông — kém hiệu quả ở xa do spread.

**🎯 Best against:**
- 👥 **Horde** *(nhóm đông, cận đến trung)* — Fire rate cao + spread rộng phủ nhiều mục tiêu
- 🪲 **Crawler** *(cận chiến mặt đất, nhỏ)* — Di chuyển nhanh khó aim, bù bằng số lượng đạn
- 🦇 **Bat Swarm** *(bay, di chuyển loạn)* — Shotgun rapidfire đặc biệt hiệu quả ở tầm gần

---

### Tier 2 (Day 10–12)

#### 🎯 Crit Bottle — *"Precision Pays Off"*
> **Day 11 · Duration: 10s · Compatible: AR · Shotgun · Sniper**

| Attribute | Value |
|-----------|-------|
| Recipe | 🍲 Tomato Soup ×8 + 🧪 Vial Lv1 ×1 + 🔩 Iron ×2 |
| Crit rate | 100% (mọi phát đều crit) |
| Crit multiplier | ×**2.5** base damage |
| Headshot bonus | Headshot thêm ×**1.5** trên nền crit → tổng ×**3.75** |

**Cơ chế:** Trong thời gian hiệu lực, mọi phát đạn đều critical. Nhắm đầu nhận thêm headshot multiplier — tổng damage lên tới 3.75× base. Reward trực tiếp cho kỹ năng aim.

**🎯 Best against:**
- 🧟 **Elite Zombie** *(cận chiến, HP cao)* — Crit burst rút ngắn thời gian hạ
- 🦅 **Aerial Sniper** *(bay, tấn công từ xa)* — Sniper + Crit headshot = one-shot potential
- 🐉 **Mini-Boss** *(bất kỳ loại)* — Window 10s crit lý tưởng để burst phase boss

---

### Tier 3 (Day 13–16)

#### 🔆 Blaze Bottle — *"Fire & Rockets"*
> **Day 13 · Duration: 10s · Compatible: Flamethrower · AR**

| Attribute | Value |
|-----------|-------|
| Recipe | 🌭 Burnwich ×8 + 🧪 Vial Lv1 ×1 + 🖤 Coal ×2 |
| Damage bonus | +30% base damage |
| Fire trail | Visual effect — vệt lửa theo đường đạn *(không gây dmg, chỉ effect)* |
| Rocket proc | **8% chance** mỗi phát → bắn thêm rocket mini gây **250% base dmg** |

**Cơ chế:** Mỗi viên đạn có 8% xác suất spawn thêm một rocket mini theo sau, gây 250% base damage khi trúng mục tiêu. Không thể kiểm soát nhưng tạo burst damage bất ngờ. Fire trail chỉ là hiệu ứng hình ảnh ấn tượng — không stack dmg.

**🎯 Best against:**
- 🧱 **Tanky Ground** *(cận chiến, giáp trung)* — Rocket proc xuyên qua HP pool dày
- 🐛 **Tunneler** *(cận chiến, nổi lên đất)* — Flamethrower phủ vùng xung quanh điểm xuất hiện
- 🚁 **Hoverer** *(bay thấp, tiếp cận dần)* — AR + 30% dmg + rocket proc hạ nhanh trước khi vào tầm

---

#### 🐍 Venom Bottle — *"Commit or Reset"*
> **Day 13 · Duration: 12s · Compatible: Toxic Grenade**

| Attribute | Value |
|-----------|-------|
| Recipe | 🔥 Red Alert Salad ×8 + 🧪 Vial Lv1 ×1 + 🖤 Coal ×2 |
| Stack damage | +20% base dmg mỗi stack (tối đa **7 stack = +140%**) |
| Stack reset | Đổi sang mục tiêu khác → stack **归零 ngay lập tức** |
| Auto-reset | Không bắn trúng enemy trong **4s** → stack tự giảm về 0 |

**Cơ chế:** Bắn liên tục vào cùng một enemy để stack độc. Chuyển sang enemy khác hoặc ngừng bắn quá 4s sẽ reset toàn bộ stack. Yêu cầu focus mục tiêu — càng commit càng mạnh.

> **Ví dụ:** Bắn E1 đủ 5 stack → quay sang E2 → E1 mất hết stack. Nếu quay lại E1 sau 4s → phải build lại từ đầu.

**🎯 Best against:**
- 🐘 **Brute** *(cận chiến, HP rất cao, chậm)* — Di chuyển chậm → dễ duy trì stack
- 🕷️ **Spitter** *(tầm xa, đứng yên khi bắn)* — Ít di chuyển → stack tích lũy nhanh
- 🧱 **Armored Walker** *(cận chiến, tiến thẳng)* — Hướng di chuyển dự đoán được → dễ focus

---

#### 💥 Cluster Bottle — *"Tag & Detonate"*
> **Day 15 · Duration: 8s · Compatible: Grenade · Shotgun**

| Attribute | Value |
|-----------|-------|
| Recipe | 🍡 Sweet Grapeball ×8 + 🔬 Vial Lv2 ×1 + 💎 Ruby ×2 |
| Bomb proc | **8% chance** mỗi phát → gắn bom lên enemy |
| Bomb detonation | Sau **1.5s** → nổ AoE **150% base dmg**, bán kính **3m** |
| Max bombs | Một enemy chỉ mang **1 bom** tại một thời điểm |

**Cơ chế:** Khi bắn trúng, có 8% cơ hội gắn bom vào enemy. Sau 1.5s bom phát nổ gây AoE sát thương — có thể chain nếu các enemy đứng gần nhau. Delay tạo cơ hội tactical: đẩy enemy vào đám đông trước khi nổ.

**🎯 Best against:**
- 👥 **Clustered Horde** *(nhóm đông đứng gần nhau)* — AoE chain tối đa hiệu quả
- 🐢 **Slow Tank** *(cận chiến, chậm)* — Delay 1.5s không ảnh hưởng khi enemy chậm
- 🦴 **Skeleton Archer** *(tầm xa, đứng tụ lại)* — Shotgun tầm trung gắn bom, AoE phủ cả nhóm

---

#### 🟢 Corrosion Bottle — *"Strip the Armor"*
> **Day 16 · Duration: 10s · Compatible: Shotgun · Sniper**

| Attribute | Value |
|-----------|-------|
| Recipe | 🥗 Fresh Salad ×10 + 🔬 Vial Lv2 ×1 + 💎 Ruby ×2 |
| Armor penetration | Bỏ qua **50%** chỉ số phòng thủ của enemy |
| Stack damage | Mỗi phát bắn trúng: +**5 flat dmg** (tích lũy, không giới hạn trong duration) |

**Cơ chế:** Mọi viên đạn tự động xuyên qua 50% armor của mục tiêu — đặc biệt hiệu quả với enemy giáp dày. Đồng thời mỗi phát tích lũy thêm 5 flat dmg không phụ thuộc vào phòng thủ. Không cần quản lý stack — bắn liên tục và damage tăng dần.

**🎯 Best against:**
- 🛡️ **Heavy Armored** *(cận/xa, phòng thủ cao)* — Armor pen 50% là counter trực tiếp
- 🦖 **Boss-type** *(mọi kiểu di chuyển, HP và armor đều cao)* — Kết hợp armor pen + flat stack = DPS bền
- 🤖 **Mech Enemy** *(tấn công từ xa, giáp cứng)* — Sniper + Corrosion = burst xuyên giáp

---

### Tier 4 (Day 20+)

#### 🌩️ Arc Bottle — *"Chain Reaction"*
> **Day 20 · Duration: 8s · Compatible: SMG**

| Attribute | Value |
|-----------|-------|
| Recipe | 🌟 Carambola Cake ×10 + ⚗️ Vial Lv3 ×1 + 💛 Gold Crystal ×2 |
| Chain targets | Phóng điện chain sang **4** mục tiêu gần nhau |
| Chain damage | **60% base dmg** mỗi bước chain |
| Chain range | ~4m giữa các mục tiêu |

**Cơ chế:** Mỗi viên đạn trúng mục tiêu đầu tiên sẽ chain điện sang tối đa 3 enemy xung quanh (tổng 4 mục tiêu gồm target gốc), mỗi chain giảm 60% base dmg. Hiệu quả nhất khi enemy đứng gần nhau.

**🎯 Best against:**
- 🐝 **Flying Swarm** *(bay theo bầy, di chuyển cụm)* — Chain điện lý tưởng khi chúng bay sát nhau
- 🧟 **Zombie Horde** *(cận chiến, đi thành nhóm)* — SMG rapid fire + chain = clear nhóm nhanh
- 🦇 **Bat Colony** *(bay, cụm dày)* — Tầm chain 4m đủ phủ toàn bộ đàn

---

#### ☁️ Miasma Bottle — *"Plague & Plunder"*
> **Day 21 · Duration: 12s · Compatible: Grenade**

| Attribute | Value |
|-----------|-------|
| Recipe | 🍰 Honey Cake ×8 + ⚗️ Vial Lv3 ×1 + ☠️ Poison Shard ×2 |
| Cloud damage | **10 dmg/s**, bán kính **5m AoE**, mật độ 60% |
| Kill drop | Enemy chết trong cloud → **60% chance** rơi **Buff Fragment** ngẫu nhiên |
| Buff Fragment | Chọn ngẫu nhiên: **+15% dmg** / **+20% atk speed** / **+15% move speed** — kéo dài **5s** |
| Kill bonus | Enemy bị tiêu diệt **hoàn toàn bởi cloud** (không nguồn dmg khác) → **+10 HP** heal ngay lập tức |

**Cơ chế:** Ném lựu đạn tạo vùng khí độc 5m. Mọi enemy trong cloud nhận 10 dmg/s. Khi enemy chết trong cloud, 60% cơ hội rơi mảnh buff nhặt được — mảnh buff cho hiệu ứng ngẫu nhiên 5s. Nếu cloud "last hit" enemy (không có đạn hay nguồn dmg khác đóng góp), nhận ngay 10 HP.

**🎯 Best against:**
- 🐌 **Slow Brute** *(cận chiến, chậm, HP cao)* — Ở lâu trong cloud → nhận đủ dmg/s để kill bonus kích hoạt
- 🦟 **Insect Swarm** *(bay thấp, HP thấp, đông)* — HP thấp chết nhanh trong cloud → nhiều buff fragment rơi
- 🧙 **Necromancer** *(tầm xa, triệu hồi đám đông)* — Đặt cloud chặn điểm triệu hồi, diệt minion + farm buff

---

## Special Crafts

| Icon | Name | Day | Recipe | Effect |
|------|------|-----|--------|--------|
| 🚀 | Ap-pleClear Ca-Rotket | Day 16 | 🥪 Hot Bunny ×1 + 🧁 Carrot Cake ×1 + 🥧 Apple Pie ×1 | Summon a giant carrot rocket carrying apple bombs. Massive AoE — destroys all enemies in range. One-use per night, long cooldown. |

> **Unlock path:** Hot Bunny (1/3) → Carrot Cake (2/3) → Apple Pie (3/3)

---

## Recipe Progression by Day

```
DAY 1
  Crops:       🫐 Berry · 🌾 Wheat
  Natural:     💀 Monster Meat · 🔩 Iron · 🟡 Sand · 🗑️ Trash · 🔧 Metal Scrap · ⚡ Power Shard · 🟤 Copper · 🌲 Wood (WIP) · 🪨 Stone (WIP)
  Ingredients: 🥐 Flour · 🔋 Power Core · 💡 Circuit

DAY 3
  Crops:       🌱 Bean · 🥕 Carrot · 🥬 Cabbage · 🥥 Coconut
  Ingredients: 🛢️ Bean Oil · 🧴 Coconut Oil · 🧈 Margarine · 🥛 Coconut Milk

DAY 5
  Crops:       🫚 Beetroot
  Ingredients: 🍬 Sugar · 🧪 Glass Vial Lv1
  Food:        🍞 Bread · 🥖 Soggy Bread · 🎂 Berry Cake
  Bottle:      🧊 Frost Bottle

DAY 6
  Crops:       🍅 Tomato  [Trigger: Kill 300 monsters]
  Ingredients: 🥣 Cabbage Sauce
  Food:        🍔 Burger Berry
  Bottle:      ⚡ Rapidfire Bottle

DAY 7
  Natural:     🍯 Honey  [Trigger: Place first Apiary Gadget]
  Natural:     🥚 Egg  [Trigger: Build Coop]
  Food:        🍳 Omelet

DAY 8
  Crops:       🍇 Grape  [Trigger: Open a Treasure Pod]
  Food:        🍡 Sweet Grapeball · 🥪 Hot Bunny · 🧁 Carrot Cake

DAY 10
  Crops:       ⭐ Carambola  [Trigger: Defeat first Boss] · 🌶️ Chili
  Natural:     🖤 Coal
  Ingredients: 🍦 Cream
  Food:        🍲 Tomato Soup

DAY 11
  Bottle:      🎯 Crit Bottle

DAY 13
  Food:        🌭 Burnwich · 🔥 Red Alert Salad · 🌟 Carambola Cake
  Bottle:      🔆 Blaze Bottle · 🐍 Venom Bottle

DAY 15
  Crops:       🍎 Apple · 🫑 Pepper
  Natural:     💎 Ruby
  Ingredients: 🔬 Glass Vial Lv2 · ☠️ Poison Shard · 💧 Acid Shard
  Bottle:      💥 Cluster Bottle

DAY 16
  Food:        🥧 Apple Pie · 🥗 Fresh Salad · 🍰 Honey Cake
  Bottle:      🟢 Corrosion Bottle
  Special:     🚀 Ap-pleClear Ca-Rotket

DAY 20
  Crops:       🌵 Durian (WIP) · 🍈 Noni Fruit (WIP)
  Natural:     💛 Gold Crystal
  Ingredients: ⚗️ Glass Vial Lv3
  Bottle:      🌩️ Arc Bottle

DAY 21
  Bottle:      ☁️ Miasma Bottle
```

---

## Use Cases — Ammo Reference

Crops can be used directly as ammunition:

| Crop | Gun Type |
|------|----------|
| 🫐 Berry | AR |
| 🌾 Wheat | SMG |
| 🍅 Tomato | Shotgun |
| 🌱 Bean | SMG |
| 🥥 Coconut | Grenade (Apple-type) |
| ⭐ Carambola | Sniper |
| 🌶️ Chili | Flamethrower |
| 🍎 Apple | Grenade |
| 🫑 Pepper | Toxic Grenade |
| 🍇 | *(special)* |
| 🌵 Durian | TBD |
| 🍈 Noni Fruit | TBD |

---

## Usage Balance

Total quantity of each item consumed across all recipes.

| Tier | Quantity | Notes |
|------|----------|-------|
| **Staple** | 50+ | Core staple — ensure stable farm supply |
| **Common** | 20–49 | Versatile mid-tier. Balanced across recipes |
| **Mid** | 8–19 | Healthy usage — no bottleneck expected |
| **Niche** | < 8 | Late-game or specific use — scarcity via grow time is intentional |

**Key balance notes:**
- 🟢 **Staple (50+):** High demand items — ensure stable farm supply.
- 🔵 **Common (20–49):** Versatile mid-tier. Balanced across recipes.
- 🟡 **Mid (8–19):** Healthy usage — no bottleneck expected.
- ⬛ **Niche (<8):** Late-game or specific use — scarcity via grow time is intentional.

> Notable high-demand items based on recipe frequency: **Flour**, **Sugar**, **Coconut Milk**, **Carrot**, **Tomato**, **Berry**, **Egg** — ensure steady farm production of these from early game.
