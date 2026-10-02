# 03 – Operatoren

## Lernziel

Du kannst Werte berechnen, verändern und vergleichen. Ergebnisse speicherst du in eigenen Variablen und berechnest sie nach Änderungen bei Bedarf neu.

## Von Ausgangswerten zu Ergebnissen

Eine Berechnung besteht meistens aus drei Schritten:

1. Ausgangswerte in Variablen speichern.
2. Mit Operatoren ein Ergebnis berechnen und dieses in einer neuen Variable speichern.
3. Das Ergebnis ausgeben.

```csharp
int vorhandeneSeiten = 12;
int geleseneSeiten = 5;
int offeneSeiten = vorhandeneSeiten - geleseneSeiten;

Console.WriteLine($"Noch offen: {offeneSeiten}");
```

## Rechenoperatoren

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition | `gesamt = alt + neu` |
| `-` | Subtraktion | `offen = gesamt - fertig` |
| `*` | Multiplikation | `minuten = anzahl * minutenProEinheit` |
| `/` | Division | `stunden = minuten / 60.0` |
| `%` | Rest einer Division | `rest = anzahl % 2` |

## Reihenfolge der Berechnung

Multiplikation und Division werden vor Addition und Subtraktion ausgeführt. Klammern machen eine andere Reihenfolge ausdrücklich sichtbar:

```csharp
int ohneKlammern = 2 + 3 * 4;    // 14
int mitKlammern = (2 + 3) * 4;   // 20
```

Wenn eine Rechnung schwer auf einen Blick zu lesen ist, helfen Klammern auch dann, wenn das Ergebnis ohne sie gleich wäre.

## Ganzzahlige und genaue Division

Sind beide Operanden `int`, führt C# eine Ganzzahldivision aus. Nachkommastellen gehen verloren:

```csharp
int ganzzahlig = 10 / 3;       // 3
double genau = 10.0 / 3;       // ungefähr 3.333
```

Für die Umrechnung von Minuten in Stunden sollte mindestens eine Zahl ein `double` sein:

```csharp
int gesamtMinuten = 95;
double gesamtStunden = gesamtMinuten / 60.0;
```

`60.0` sorgt dafür, dass die Nachkommastellen erhalten bleiben. Das Ergebnis kann deshalb in einer `double`-Variable gespeichert werden.

## Vergleiche liefern einen Wahrheitswert

Vergleiche ergeben immer `true` oder `false` und können deshalb in einer `bool`-Variable gespeichert werden:

| Operator | Bedeutung |
|---|---|
| `==` | gleich |
| `!=` | ungleich |
| `>` | größer |
| `<` | kleiner |
| `>=` | größer oder gleich |
| `<=` | kleiner oder gleich |

```csharp
int bearbeitet = 6;
int ziel = 5;
bool zielErreicht = bearbeitet >= ziel;

Console.WriteLine($"Ziel erreicht: {zielErreicht}");
```

`=` weist einen Wert zu. `==` vergleicht zwei Werte. Diese Zeichen haben unterschiedliche Aufgaben.

## Werte mit Kurzschreibweisen verändern

```csharp
int punkte = 10;
punkte += 5;  // dasselbe wie: punkte = punkte + 5;
punkte -= 2;  // dasselbe wie: punkte = punkte - 2;
```

Die Variable muss vor `+=` oder `-=` bereits existieren.

## Abhängige Ergebnisse neu berechnen

C# merkt sich in einer Ergebnisvariable nur das Ergebnis der damaligen Rechnung. Die Rechenformel bleibt nicht automatisch mit ihren Ausgangswerten verbunden:

```csharp
int gesamt = 8;
int fertig = 2;
int offen = gesamt - fertig;   // offen ist jetzt 6

fertig += 3;                   // fertig ist jetzt 5
// offen ist weiterhin 6

offen = gesamt - fertig;       // neu berechnet: offen ist jetzt 3
```

Nach einer Änderung musst du alle Ergebnisse, die davon abhängen, erneut zuweisen.

## Restwert mit `%`

Der Modulo-Operator `%` gibt den Rest einer Division zurück:

```csharp
int einheiten = 8;
int rest = einheiten % 2;          // 0
bool gleichmaessigTeilbar = rest == 0;
```

Ein Rest von `0` bedeutet, dass die Zahl ohne Rest teilbar ist. Bei `9 % 2` wäre der Rest `1`.

## Geführtes Vorgehen für eine Berechnungsaufgabe

1. Lege zuerst alle Ausgangswerte an.
2. Berechne jedes verlangte Ergebnis in einer eigenen Variable.
3. Achte bei Stunden auf eine Division durch `60.0` statt durch `60`.
4. Speichere Vergleiche in einer `bool`-Variable.
5. Gib Ausgangswerte und Ergebnisse aus.
6. Ändere einen Ausgangswert mit `+=`.
7. Berechne alle davon abhängigen Ergebnisse erneut und gib sie wieder aus.

## Häufige Fehler

- Minuten werden durch `60` geteilt und Nachkommastellen gehen wegen Ganzzahldivision verloren.
- `=` und `==` werden verwechselt.
- Ein Ausgangswert wird verändert, aber die abhängigen Ergebnisse werden nicht neu berechnet.
- Ein Vergleich wird als Text statt als `bool` gespeichert.
- Bei `%` wird der Rest ausgegeben, aber nicht mit `0` verglichen, obwohl ein Wahrheitswert benötigt wird.

