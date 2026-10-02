# Theorie und Anleitung – Blazor-Komponenten

Die drei Projekte führen die Kommunikation schrittweise ein. Die ausführliche Theorie steht jeweils direkt bei der Aufgabe und verwendet **eigene Beispiele**, damit du das Prinzip auf den Startercode übertragen kannst:

1. [Parameter, EventCallback und Geschwister](01_Farbwahl/THEORIE_UND_ANLEITUNG.md)
2. [Callback-Werte über eine Zwischenkomponente](02_Temperaturregler/THEORIE_UND_ANLEITUNG.md)
3. [Objekte, Listen, Formulare und Karten](03_LernaufgabenTracker/THEORIE_UND_ANLEITUNG.md)

Grundregel: Ein Elternteil besitzt dauerhaften Zustand. Parameter geben Daten an Kinder; `EventCallback<T>` meldet Aktionen und Werte nach oben. Bei mehreren Ebenen kann eine mittlere Komponente den Callback-Wert an ihren Elternteil weiterreichen.
