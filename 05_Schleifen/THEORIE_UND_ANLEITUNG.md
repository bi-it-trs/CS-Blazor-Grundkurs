# 05 – Schleifen

## Lernziel

Du kannst Code wiederholen, mehrere Werte nacheinander verarbeiten und eine Eingabe so lange wiederholen, bis sie gültig ist.

## Welche Schleife passt wann?

| Schleife | Geeignet, wenn ... |
|---|---|
| `foreach` | jedes Element einer Sammlung einmal verarbeitet werden soll |
| `for` | die Anzahl der Wiederholungen bekannt ist oder ein Zähler benötigt wird |
| `while` | vorher nicht bekannt ist, wie oft wiederholt werden muss |
| `do-while` | der Block mindestens einmal ausgeführt werden muss |

## Mehrere Werte in einem Array speichern

Ein Array speichert mehrere Werte desselben Typs. Ein `string[]` ist ein Array aus Texten:

```csharp
string[] lernThemen =
{
    "Variablen",
    "Operatoren",
    "Bedingungen",
    "Schleifen"
};
```

Die Werte werden durch Kommas getrennt. `lernThemen.Length` enthält die Anzahl der Elemente, hier also `4`.

Array-Positionen beginnen bei `0`:

```csharp
Console.WriteLine(lernThemen[0]); // Variablen
Console.WriteLine(lernThemen[1]); // Operatoren
```

Für die Aufgabe genügt meistens `foreach`; du musst die Positionen dann nicht selbst verwalten.

## `foreach`: jedes Element verarbeiten

```csharp
foreach (string thema in lernThemen)
{
    Console.WriteLine($"Thema: {thema}");
}
```

Bei jedem Durchlauf erhält `thema` den nächsten Wert aus `lernThemen`. Die Variable `thema` wird im Kopf der Schleife deklariert und existiert nur innerhalb des Schleifenblocks. Du musst sie vorher nicht anlegen.

Der Name ist frei wählbar. Ein Einzahlname für das einzelne Element und ein Mehrzahlname für die Sammlung machen den Code leichter lesbar.

## `for`: mit einem Zähler wiederholen

```csharp
for (int runde = 1; runde <= 5; runde++)
{
    Console.WriteLine($"Lernrunde {runde}");
}
```

Der Kopf besteht aus drei Teilen:

1. `int runde = 1` legt den Startwert einmalig fest.
2. `runde <= 5` wird vor jedem Durchlauf geprüft.
3. `runde++` erhöht den Wert nach jedem Durchlauf um eins.

`runde++` ist eine Kurzform für `runde = runde + 1`. Die Schleife läuft hier für die Werte `1`, `2`, `3`, `4` und `5`.

## `while`: wiederholen, solange etwas zutrifft

Die Bedingung einer `while`-Schleife wird vor jedem Durchlauf geprüft:

```csharp
int erledigt = 0;
int ziel = 4;

while (erledigt < ziel)
{
    erledigt++;
    Console.WriteLine($"Erledigt: {erledigt} von {ziel}");
}
```

Für eine sicher endende `while`-Schleife brauchst du:

1. einen sinnvollen Startwert vor der Schleife,
2. eine Bedingung, die anfangs zutrifft,
3. eine Veränderung im Schleifenblock, durch die die Bedingung irgendwann `false` wird.

Ohne `erledigt++` bliebe `erledigt < ziel` immer wahr und die Schleife würde endlos laufen.

## Eingaben mit `Console.ReadLine`

```csharp
Console.Write("Eingabe: ");
string? eingabe = Console.ReadLine();
```

`Console.ReadLine()` wartet auf eine Eingabe und liefert den eingegebenen Text. Der Typ ist `string?`, weil theoretisch auch gar kein Textwert (`null`) zurückgegeben werden kann. Das Fragezeichen bedeutet: Diese Variable darf einen Text oder `null` enthalten.

`Console.Write` eignet sich für die Aufforderung, weil die Eingabe dann in derselben Zeile erfolgt.

## Leere Eingaben erkennen

`string.IsNullOrWhiteSpace(eingabe)` ergibt `true`, wenn die Eingabe:

- `null` ist,
- leer ist (`""`), oder
- nur aus Leerzeichen und ähnlichen Leerraumzeichen besteht.

Damit werden sowohl eine direkt bestätigte leere Eingabe als auch mehrere Leerzeichen abgelehnt.

## `do-while`: mindestens einmal fragen

Die Variable wird vor der Schleife deklariert, damit sie sowohl im Block als auch in der Bedingung verfügbar ist:

```csharp
string? eingabe;

do
{
    Console.Write("Gib einen Begriff ein: ");
    eingabe = Console.ReadLine();
}
while (string.IsNullOrWhiteSpace(eingabe));

Console.WriteLine($"Gültige Eingabe: {eingabe}");
```

Ablauf:

1. Der `do`-Block läuft ohne vorherige Prüfung mindestens einmal.
2. Danach prüft `while`, ob die Eingabe ungültig ist.
3. Bei `true` beginnt ein neuer Durchlauf.
4. Bei `false` endet die Schleife.

Beachte das Semikolon nach der `while`-Bedingung einer `do-while`-Schleife.

Würde `eingabe` erst innerhalb der geschweiften Klammern mit `string? eingabe = ...` deklariert, wäre sie in der anschließenden `while`-Bedingung nicht mehr sichtbar.

## Alternative mit `while`

Mit einer normalen `while`-Schleife brauchst du bereits vor der ersten Prüfung einen Anfangswert:

```csharp
Console.Write("Gib einen Begriff ein: ");
string? eingabe = Console.ReadLine();

while (string.IsNullOrWhiteSpace(eingabe))
{
    Console.Write("Eingabe war leer. Erneut: ");
    eingabe = Console.ReadLine();
}
```

Beide Varianten sind korrekt. Für eine Eingabe, die auf jeden Fall mindestens einmal erfolgen muss, ist `do-while` oft übersichtlicher.

## `continue` und `break`

- `continue` überspringt den Rest des aktuellen Durchlaufs und beginnt den nächsten.
- `break` beendet die Schleife vollständig.

Für die Grundaufgaben sind beide Schlüsselwörter nicht nötig. Eine klare Schleifenbedingung ist dort leichter nachzuvollziehen.

## Geführtes Vorgehen für die Aufgaben

1. Lege das Array vor den Schleifen an.
2. Verwende in `foreach` einen neuen Namen für jeweils ein Element und gib diesen Namen im Block aus.
3. Lege beim `for`-Kopf Startwert, Endbedingung und Erhöhung fest.
4. Lege den Zähler der `while`-Schleife vorher an, gib jeden Stand aus und erhöhe ihn in jedem Durchlauf.
5. Deklariere die Eingabevariable bei `do-while` vor dem Block.
6. Lies die Eingabe innerhalb der Schleife neu ein.
7. Wiederhole, solange `string.IsNullOrWhiteSpace(...)` `true` ergibt.

## Häufige Fehler

- Im Array fehlen Kommas zwischen den Elementen.
- In `foreach` wird statt des einzelnen Elements versehentlich das ganze Array ausgegeben.
- Beim `for`-Kopf ist die Grenze falsch, sodass ein Durchlauf fehlt oder zu viel ausgeführt wird.
- Der Zähler einer `while`-Schleife wird nicht verändert und die Schleife endet nie.
- Die Eingabe wird nur vor der Schleife gelesen und innerhalb der Schleife nicht aktualisiert.
- Die Eingabevariable wird innerhalb des `do`-Blocks deklariert und ist in der `while`-Bedingung nicht mehr sichtbar.
- Bei `do-while` fehlt das Semikolon nach der abschließenden Bedingung.

