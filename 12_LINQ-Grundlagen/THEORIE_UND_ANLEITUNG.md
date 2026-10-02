# 12 – LINQ-Grundlagen

## Lernziel

Du kannst eine bestehende Liste mit LINQ zählen, filtern und sortieren, ohne ihre ursprüngliche Reihenfolge oder ihren Inhalt zu verändern.

## Was ist LINQ?

LINQ steht für **Language Integrated Query**. Es stellt Methoden bereit, mit denen Sammlungen beschrieben und ausgewertet werden können:

- `Count(...)` zählt passende Elemente.
- `Where(...)` filtert Elemente.
- `OrderBy(...)` sortiert aufsteigend.
- `ToList()` erzeugt aus dem Ergebnis eine neue Liste.

In modernen Konsolenprojekten ist der benötigte Namespace `System.Linq` normalerweise über implizite `using`-Anweisungen verfügbar.

Für die Beispiele wird eine vorhandene `List<TaskItem> aufgaben` verwendet.

## Alle Elemente mit `Count` zählen

`Count` ohne runde Klammern ist eine Property der Liste:

```csharp
int gesamt = aufgaben.Count;
```

Sie liefert die Anzahl aller Listenelemente.

## Passende Elemente mit `Count(...)` zählen

Die LINQ-Methode `Count(...)` kann eine Bedingung erhalten:

```csharp
int erledigt = aufgaben.Count(
    aufgabe => aufgabe.Status == AufgabenStatus.Erledigt
);
```

Das bedeutet: Zähle jedes Element, dessen Status `Erledigt` ist.

Der Unterschied:

| Schreibweise | Ergebnis |
|---|---|
| `aufgaben.Count` | Anzahl aller Elemente |
| `aufgaben.Count(bedingung)` | Anzahl der Elemente, die die Bedingung erfüllen |

Für verschiedene Statuswerte verwendest du dieselbe Struktur mit einer jeweils passenden Vergleichsbedingung.

## Lambda-Ausdrücke lesen

```csharp
aufgabe => aufgabe.Status == AufgabenStatus.Offen
```

Ein Lambda-Ausdruck ist hier eine kurze Prüffunktion:

- Das erste `aufgabe` ist ein frei gewählter Name für jeweils ein Listenelement.
- `=>` kann als „wird geprüft mit“ gelesen werden.
- Rechts steht eine Bedingung, die `true` oder `false` ergibt.

In Worten: „Nimm eine Aufgabe und prüfe, ob ihr Status offen ist.“

Die Lambda-Variable existiert nur innerhalb dieses Ausdrucks. Sie muss vorher nicht deklariert werden.

## Mit `Where` filtern

`Where` behält nur Elemente, für die die Bedingung `true` liefert:

```csharp
List<TaskItem> offeneAufgaben = aufgaben
    .Where(aufgabe => aufgabe.Status == AufgabenStatus.Offen)
    .ToList();
```

`Where` verändert `aufgaben` nicht. Es liefert eine gefilterte Folge. `ToList()` macht daraus eine neue `List<TaskItem>`, die in der Variable gespeichert wird.

## Mehrere Statuswerte filtern

Beide Seiten von `||` müssen vollständige Bedingungen sein:

```csharp
List<TaskItem> aktiveAufgaben = aufgaben
    .Where(aufgabe =>
        aufgabe.Status == AufgabenStatus.Offen
        || aufgabe.Status == AufgabenStatus.InArbeit)
    .ToList();
```

Diese verkürzte Schreibweise ist ungültig:

```csharp
// Falsch:
// aufgabe.Status == AufgabenStatus.Offen
// || AufgabenStatus.InArbeit
```

`AufgabenStatus.InArbeit` ist ein Enum-Wert und für sich allein keine Bedingung. Links und rechts von `||` muss jeweils ein Ausdruck stehen, der `bool` ergibt.

Wenn „nicht erledigt“ genau die beiden gewünschten Statuswerte umfasst, ist diese Bedingung kürzer:

```csharp
List<TaskItem> nichtErledigteAufgaben = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .ToList();
```

Der Variablenname sollte den tatsächlichen Inhalt beschreiben. Eine Liste mit offenen **und** in Arbeit befindlichen Aufgaben sollte nicht nur `offeneAufgaben` heißen.

## Mit `OrderBy` sortieren

```csharp
List<TaskItem> alphabetisch = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Der Lambda-Ausdruck hinter `OrderBy` wählt den Sortierschlüssel. Hier wird nach der Property `Titel` aufsteigend sortiert.

`OrderBy` sortiert nicht die ursprüngliche Liste um. Durch `ToList()` entsteht eine neue Liste in sortierter Reihenfolge.

## Filtern und Sortieren verketten

LINQ-Methoden können hintereinander ausgeführt werden:

```csharp
List<TaskItem> aktiveAufgabenAlphabetisch = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Der Datenfluss lautet:

```text
ursprüngliche Liste
    → Where behält passende Elemente
    → OrderBy ordnet diese Elemente
    → ToList erzeugt eine neue Liste
```

Jede Methode arbeitet auf dem Ergebnis der vorherigen Methode.

## `Where().OrderBy()` gegenüber `OrderBy().Where()`

Beide Varianten können denselben sichtbaren Inhalt liefern:

```csharp
List<TaskItem> varianteA = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();

List<TaskItem> varianteB = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .ToList();
```

Warum ist das Ergebnis hier gleich?

- Variante A entfernt zuerst erledigte Aufgaben und sortiert die verbleibenden Titel.
- Variante B sortiert zuerst alle Aufgaben und entfernt anschließend die erledigten.
- Das Filtern verändert die Reihenfolge der übrig gebliebenen Elemente nicht.

Variante A ist meist sinnvoller, weil `OrderBy` nur die bereits verkleinerte Menge sortieren muss. Allgemein darf die Reihenfolge verketteter Methoden aber nicht beliebig vertauscht werden; andere Methodenfolgen können unterschiedliche Ergebnisse liefern.

## Eine separat sortierte Gesamtliste

Wenn sowohl eine gefilterte als auch eine vollständig sortierte Liste benötigt wird, startest du beide Abfragen wieder bei der ursprünglichen Liste:

```csharp
List<TaskItem> gefiltertUndSortiert = aufgaben
    .Where(/* Bedingung */)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();

List<TaskItem> alleSortiert = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Die zweite Abfrage darf nicht versehentlich bei `gefiltertUndSortiert` beginnen, wenn wirklich alle Aufgaben enthalten sein sollen.

## Ergebnisse mit `foreach` ausgeben

Jede Ergebnisliste kann wie eine normale Liste durchlaufen werden:

```csharp
foreach (TaskItem aufgabe in alphabetisch)
{
    Console.WriteLine($"{aufgabe.Titel}: {aufgabe.Status}");
}
```

Eine Überschrift vor jeder Ausgabe hilft dabei, die gefilterte Liste und die Gesamtliste auseinanderzuhalten.

## Prüfen, dass das Original unverändert bleibt

`Where` und `OrderBy` erzeugen Abfrageergebnisse. Sie entfernen keine Objekte aus `aufgaben` und ordnen diese Liste nicht um.

Du kannst zur Kontrolle die ursprüngliche Liste vor und nach den LINQ-Abfragen ausgeben. Anzahl und Reihenfolge müssen gleich bleiben.

Die Ergebnislisten enthalten allerdings weiterhin Referenzen auf dieselben `TaskItem`-Objekte. Würdest du eine Property eines enthaltenen Objekts verändern, wäre diese Änderung auch über die ursprüngliche Liste sichtbar. Für die Aufgabe werden die Objekte nur gelesen.

## Geführtes Vorgehen für die Aufgaben

1. Lege mindestens sechs Objekte mit verschiedenen Statuswerten an.
2. Füge sie in einer bewusst nicht alphabetischen Reihenfolge zur Ursprungsliste hinzu.
3. Ermittle die Gesamtzahl mit der `Count`-Property.
4. Ermittle jede Statusanzahl mit `Count(...)` und einer Lambda-Bedingung.
5. Filtere alle nicht erledigten Aufgaben mit `Where`.
6. Sortiere das gefilterte Ergebnis mit `OrderBy`.
7. Schließe die Abfrage mit `ToList()` ab.
8. Erzeuge eine zweite sortierte Liste direkt aus der Ursprungsliste.
9. Gib beide Ergebnislisten mit klaren Überschriften aus.
10. Gib bei Bedarf das Original erneut aus, um seine unveränderte Reihenfolge zu prüfen.

## Häufige Fehler

- `Count` und `Count(...)` werden verwechselt.
- Hinter `Where` fehlt `ToList()`, obwohl das Ergebnis als `List<TaskItem>` gespeichert werden soll.
- Rechts von `||` steht nur ein Enum-Wert statt eines vollständigen Vergleichs.
- Eine Liste heißt `offeneAufgaben`, enthält aber auch Aufgaben in Arbeit.
- Die Gesamtliste wird versehentlich aus der bereits gefilterten Liste erstellt.
- Statt `OrderBy` wird eine verändernde Sortierung auf der Ursprungsliste verwendet.
- Es wird angenommen, die Ergebnislisten enthielten automatisch Kopien der einzelnen Objekte.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "12_LINQ-Grundlagen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "12_LINQ-Grundlagen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "12_LINQ-Grundlagen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
