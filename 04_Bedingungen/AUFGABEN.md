# Aufgaben – Bedingungen

## Aufgabe: Aufgabenstatus bestimmen

Lege folgende Informationen an:

- Aufgabentitel
- Statusauswahl als Zahl
- Dringlichkeit als `bool`
- Statustext als `string`

Übersetze die Statusauswahl mit `switch`:

- `1` → Offen
- `2` → In Arbeit
- `3` → Erledigt
- andere Zahl → Unbekannt

Verwende danach `if`, `else if` und `else`:

- Erledigt: Abschlussmeldung
- dringend und nicht erledigt: Prioritätsmeldung
- sonst: normale Bearbeitung

Anforderungen:

- Teste alle drei gültigen Werte und mindestens einen ungültigen Wert.
- Verwende mindestens einmal `&&` oder `!`.
- Gib Titel, Status und Entscheidung aus.

