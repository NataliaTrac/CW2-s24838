# ⚓️ Container Ship Manager 🛳️

Ahoy! Welcome aboard the **Container Ship Manager**, a C# console application that lets you command fleets, load cargo, and manage a whole container terminal like a true sea captain.  
This project was created for CW2 (Object-Oriented Programming coursework) at PJATK.

---

## 🗺️ Features – Your Ship’s Arsenal

🚢 Manage ships and containers like a modern port terminal:

### 📦 Container Types:
- 🧃 **LiquidContainer**  
  Carries hazardous and non-hazardous liquids. Enforces load limits:  
  - 50% max for hazardous cargo  
  - 90% for regular liquid cargo  
  Throws `OverfillException` and sends hazard alerts if rules are broken.

- 💨 **GasContainer**  
  Stores pressurized gas. Leaves 5% of load during unloading for safety.

- ❄️ **RefrigeratedContainer**  
  Handles temperature-sensitive products like bananas, milk, and helium.  
  Enforces temperature requirements based on product type.

---

## 🧭 Console Menu (Captain’s Interface)

```text
=== MENU ===
1. Add Container Ship
2. Add Container
3. Show Container Ships
4. Show Containers
5. Load Container onto Ship
6. Unload Container from Ship
7. Remove Container from Ship
8. Replace Container on Ship
9. Move Container Between Ships
0. Exit
```

- Dynamic prompts for user input  
- Real-time validation, hazard warnings, and exceptions  
- Add, view, and manipulate ships & containers

---

## ⚙️ Tech Specs

- Language: **C#**
- Platform: **.NET Console App**
- IDE: **JetBrains Rider**
- Version control: **Git + GitHub**

---

## 🔍 Project Structure

```bash
ContainerShipManager/
├── Models/
│   ├── Container.cs
│   ├── LiquidContainer.cs
│   ├── GasContainer.cs
│   ├── RefrigeratedContainer.cs
│   ├── ContainerShip.cs
│   └── ProductType.cs
├── Interfaces/
│   └── IHazardNotifier.cs
├── Exceptions/
│   └── OverfillException.cs
└── Program.cs  ← Main menu + app logic
```

---

## 🚨 Error & Exception Handling

- `OverfillException` — when cargo exceeds max load  
- Hazard alerts — triggered during risky operations  
- Temperature & safety validations for sensitive containers

---

## 🧪 Example Voyage

- Create a ship (`Poseidon`)
- Add a refrigerated container for bananas at 13°C
- Try loading helium at -200°C → ❌ Boom! Hazard alert!
- Successfully move containers between ships

---

## 👩‍✈️ Captain of This Ship

**Natalia Trączewska**  
Student ID: s24838  
Polish-Japanese Academy of Information Technology (PJAIT)  
Course: APBD
