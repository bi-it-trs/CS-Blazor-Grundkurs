# Prüfung am 15.10.2026

Geprüft mit .NET 10 und im lokalen Brave-Browser auf http://localhost:5104.

## Kompilierung

`dotnet build`: erfolgreich, 0 Fehler und 0 Warnungen.

## Interaktive Prüfung

- Parameter: veränderlicher Elterntext, Zahl und feste bzw. Standardwerte im zweiten Kind.
- Callback: string-Nutzdaten, Ereignis ohne Nutzdaten und nicht zugewiesener Handler.
- Lambda: Methodenreferenz, feste und empfangene Argumente, drei Schleifenwerte, MouseEventArgs
  und Textübergabe durch eine asynchrone Lambda nach await.
- Methoden: string und Task<string> beim Aufrufer; synchrone und asynchrone Func-Abfragen im Kind.
- Rückgabewerte: ohne Zuweisung kein neuer Anzeigewert.
- Async: gesperrter Ladebutton, Reihenfolge vor und nach await, absichtlicher Fehler bei Eltern und Kind,
  freigegebener Button und anschließend wieder erfolgreiches Laden.
- Binding: Eingabe in beide Kinder und Zurücksetzen von den Eltern aus.
- Geschwister: lokaler Entwurf; erst Senden aktualisiert Eltern und zweites Kind.
- Referenz: Kind erhöhen, Rückgabewert abfragen, Kind zurücksetzen; Elternwert bleibt Momentaufnahme.
- Kaskade: Änderung erreicht das Enkelkind ohne Parameter auf der Zwischenebene.
- Zustandsdienst: zwei Anzeigen, Erhalt beim Navigieren und Zurücksetzen beim vollständigen Neuladen.
- Objekte: Entwurf bleibt bei einem Rendern der Eltern erhalten; Name und Alter per Callback übergeben;
  direkte Mutation wird bei den Eltern erst nach erneutem Rendern sichtbar, ohne neuen Speicher-Callback.
- Aktualisierung: Signal aus dem Hintergrund über InvokeAsync; normaler Klick aktualisiert den Zwischenstand.

Die Prüfungen verwenden die sichtbaren Werte und Bedienelemente der App.
Die auskommentierten Gegenbeispiele sind absichtlich nicht Teil des erfolgreichen Builds.
