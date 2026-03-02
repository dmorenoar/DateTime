# 📘 Guia Completa: DateTime i TimeSpan en C#

Aquest programa demostra com treballar amb dates i temps en C# utilitzant:

- `DateTime`
- `TimeSpan`
- Format de dates
- Conversió de string a data
- Comparació de dates
- Simulació d’un cooldown (molt habitual en videojocs)

---

# 🕒 1. Obtenir la data i hora actual

```csharp
DateTime now = DateTime.Now;
```

📌 Obté la data i hora actual del sistema (hora local).

```csharp
Console.WriteLine($"Current date and time: {now}");
```

Mostra la data i hora completes.

---

# ➕ 2. Sumar i restar dies

```csharp
DateTime futureDate = now.AddDays(7);
DateTime pastDate = now.AddDays(-7);
```

- `AddDays(7)` → suma 7 dies
- `AddDays(-7)` → resta 7 dies

💡 Important: `DateTime` és immutable, sempre retorna una nova data.

---

# 📅 3. Crear dates específiques

```csharp
DateTime specificDate = new DateTime(2026, 02, 26, 0, 0, 0, DateTimeKind.Utc);
```

Paràmetres:

```
any, mes, dia, hora, minut, segon, tipus
```

`DateTimeKind.Utc` indica que la data està en format UTC (Temps Universal Coordinat).

Això és molt important en aplicacions que treballen amb diferents zones horàries.

---

# 📆 4. Obtenir només la data actual

```csharp
DateTime today = DateTime.Today;
```

Retorna la data actual amb hora 00:00:00.

---

# 🔎 5. Obtenir parts individuals de la data

```csharp
now.Year
now.Month
now.Day
now.Hour
now.Minute
now.Second
```

Permet accedir a cada component per separat.

---

# ⏳ 6. Diferència entre dates (TimeSpan)

```csharp
TimeSpan difference = endDate - startDate;
```

Quan restem dos `DateTime`, obtenim un `TimeSpan`.

Un `TimeSpan` representa una durada.

Podem accedir a:

```csharp
difference.Days
difference.Hours
difference.TotalHours
```

⚠️ Diferència important:

- `Hours` → només la part visible (0–23)
- `TotalHours` → total acumulat incloent els dies

---

# ⚖️ 7. Comparar dates

### Mètode 1: Operadors

```csharp
now < deadLine
```

### Mètode 2: CompareTo()

```csharp
now.CompareTo(deadLine)
```

Retorna:

- `-1` → menor
- `0` → iguals
- `1` → major

---

# 🎨 8. Donar format a les dates

```csharp
now.ToString("dd/MM/yyyy");
now.ToString("HH:mm");
now.ToString("dd * MMMM * yyyy");
```

Alguns formats habituals:

| Format | Significat |
|----------|------------|
| dd | dia |
| MM | mes |
| yyyy | any |
| HH | hora (24h) |
| mm | minuts |
| MMMM | nom complet del mes |

---

# 🔄 9. Convertir string a DateTime

### Parse normal

```csharp
DateTime.Parse(dateUS, CultureInfo.InvariantCulture);
```

Converteix text a data segons la cultura.

---

### ParseExact

```csharp
DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
```

Exigeix que el format sigui exactament igual.

---

### TryParse (Forma segura)

```csharp
DateTime.TryParse(dateUS, CultureInfo.InvariantCulture, out DateTime tryParseDate)
```

✔️ No llença excepció si falla  
✔️ Retorna `true` o `false`

És la forma recomanada en entorns reals.

---

# ⌛ 10. TimeSpan

```csharp
TimeSpan timeSpan = new TimeSpan(1, 30, 0);
```

Representa:

```
1 hora
30 minuts
0 segons
```

Un `TimeSpan` pot representar:

- Dies
- Hores
- Minuts
- Segons
- Mil·lisegons

---

# 🎮 11. Simulació d’un Cooldown (Exemple pràctic)

```csharp
DateTime lastUseAbility = DateTime.UtcNow.AddSeconds(-22);
```

Simula que l’habilitat es va utilitzar fa 22 segons.

---

```csharp
TimeSpan cooldown = TimeSpan.FromSeconds(90);
```

Cooldown d’1 minut i 30 segons.

---

```csharp
TimeSpan timeSinceLastUse = DateTime.UtcNow - lastUseAbility;
```

Calcula quant temps ha passat.

---

### Lògica del cooldown

```csharp
if (timeSinceLastUse >= cooldown)
```

Si ja ha passat el temps necessari → habilitat disponible.

---

```csharp
TimeSpan timeLeft = cooldown - timeSinceLastUse;
```

Si no, calcula el temps restant.

---

```csharp
Console.WriteLine(
    $"You must wait {timeLeft.Minutes} minutes and {timeLeft.Seconds} seconds."
);
```

Mostra el temps restant dividit en minuts i segons.

---
