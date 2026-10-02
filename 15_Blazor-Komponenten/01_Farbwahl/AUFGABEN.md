# 01 – Farbwahl: Geschwisterkomponenten

## Start

Dieses Verzeichnis ist ein eigenständiges Blazor-Projekt. Starte es hier mit:

```powershell
dotnet run --launch-profile http
```

Öffne die angezeigte Adresse. Anfangs steht überall **Blau**; die drei Knöpfe tun noch nichts. Die Vorlage soll bereits bauen. Lies bei Bedarf zuerst [THEORIE_UND_ANLEITUNG.md](THEORIE_UND_ANLEITUNG.md). Deren Beispiele verwenden eine andere Anwendung.

## Ziel

Ein Klick auf **Grün**, **Orange** oder **Blau** aktualisiert den Zustand in `Home` und die Vorschau auf denselben Wert. Die beiden Kinder kommunizieren nur über `Home`.

## Bearbeite diese Dateien

1. `Components/Uebung/FarbAuswahl.razor`: Ergänze einen `EventCallback<string>` als öffentlichen `[Parameter]`. Beim Klick auf einen Knopf soll der Wert der jeweiligen `foreach`-Variablen gemeldet werden. Die Auswahlkomponente speichert die gewählte Farbe nicht dauerhaft.
2. `Components/Pages/Home.razor`: Verbinde diesen Callback mit einer Methode, die einen `string` empfängt und `ausgewaehlteFarbe` aktualisiert. Übergib den aktuellen Zustand an die Vorschau.
3. `Components/Uebung/FarbVorschau.razor`: Ersetze die private, fest auf Blau gesetzte Property durch einen öffentlichen `[Parameter]` vom Typ `string`. Die Vorschau liest den Wert nur.

Die Komponentennamen werden durch `Components/_Imports.razor` verfügbar gemacht. `Program.cs`, CSS und die Projektdatei sind bereits vorbereitet.

## Vor dem Coden

Beantworte für dich: Welche Komponente besitzt die ausgewählte Farbe? Welche Komponente meldet einen Klick? Welche Komponente zeigt den gespeicherten Wert? Was steht im Komponenten-Tag jeweils links und rechts vom `=`?

## Selbsttest

- Start: Elternzustand und Vorschau zeigen **Blau**.
- Klick auf **Grün**: beide Texte zeigen Grün und das Farbfeld wird grün.
- Danach **Orange**, dann **Blau**: beide Anzeigen folgen jedem Klick.
- Ein wiederholter Klick auf dieselbe Farbe erzeugt keinen falschen Zustand.
- `dotnet build` endet ohne Fehler.

Falls nur der Elternzustand wechselt, prüfe den Parameter der Vorschau. Falls sich gar nichts ändert, prüfe den `@onclick` und die Verbindung des `EventCallback<string>` mit der Elternmethode.
