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

# 🕒 DateTimeOffset en C#

## 📌 Què és `DateTimeOffset`?

`DateTimeOffset` és una estructura que representa un moment concret en el temps, 
expressat com una data i hora amb un desfasament respecte a UTC (Temps Universal Coordinat).

S’utilitza per representar dates i hores de manera independent dels fusos horaris.

---

## 🔎 Diferència entre `DateTime` i `DateTimeOffset`

### 🟦 DateTime

Barcelona → 18:00  
New York → 12:00  

Les dues hores representen el mateix moment real, però només veiem l’hora local.  
No sabem el desfasament respecte a UTC.

---

### 🟩 DateTimeOffset

Barcelona → 18:00 +01:00  
New York → 12:00 -05:00  

Ara sí sabem el desfasament respecte a UTC.

Conversió a UTC:

Barcelona → 18:00 - 1 hora = 17:00 UTC  
New York → 12:00 + 5 hores = 17:00 UTC  

Això demostra que és el mateix instant real en el temps.

`DateTimeOffset` inclou l’offset.  
`DateTime` no.

---

## 💻 Exemple de codi

```csharp
// DateTimeOffset is a structure that represents a point in time,
// typically expressed as a date and time of day,
// with an offset from Coordinated Universal Time (UTC).
// It is used to represent dates and times in a way
// that is independent of time zones.

/* DateTime vs DateTimeOffset:
 * DateTime -> Barcelona 18:00 / New York 12:00
 * (both times are the same moment, but they are represented differently
 * because they are in different time zones)
 *
 * DateTimeOffset -> Barcelona 18:00 +01:00 / New York 12:00 -05:00
 * (both times are the same moment, but they are represented with their
 * respective offsets from UTC, so we can know the exact time)
 *
 * Barcelona 18:00 - 1 hour (offset) = 17:00 UTC
 * New York 12:00 + 5 hours (offset) = 17:00 UTC
 *
 * Now we can know the exact time in both locations,
 * because DateTimeOffset includes the offset from UTC,
 * while DateTime does not.
 */

DateTimeOffset nowUTC = DateTimeOffset.Now;

Console.WriteLine(nowUTC);
// This will print the current date and time with the offset from UTC

// Create a DateTimeOffset for a specific date and time with a specific offset (Barcelona)
DateTimeOffset specificDateTimeOffsetBarcelona =
    new DateTimeOffset(2026, 02, 26, 14, 30, 0, TimeSpan.FromHours(1));
// 26th February 2026 at 14:30 with an offset of +1 hour from UTC

// Create a DateTimeOffset for a specific date and time with a specific offset (New York)
DateTimeOffset specificDateTimeOffsetNewYork =
    new DateTimeOffset(2026, 02, 26, 14, 30, 0, TimeSpan.FromHours(-5));
// 26th February 2026 at 14:30 with an offset of -5 hours from UTC

Console.WriteLine($"Barcelona: {specificDateTimeOffsetBarcelona}");
Console.WriteLine($"New York: {specificDateTimeOffsetNewYork}");
```

---

## 🎯 Idea clau

`DateTimeOffset` = Data + Hora + Offset → Moment exacte en el temps.

