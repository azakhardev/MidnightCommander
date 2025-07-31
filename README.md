# Midnight Commander – Konzolový souborový prohlížeč (OOP projekt)

## 📝 Popis projektu

Tento projekt vznikl jako náš **první větší úkol v objektově orientovaném programování (OOP)**. Cílem bylo vytvořit jednoduchý klon známého nástroje **Midnight Commander**, který běží v příkazové řádce.

Projekt měl sloužit k procvičení návrhu tříd, dědičnosti, práce s událostmi a návrhových principů OOP. Každý prvek rozhraní byl vykreslen pomocí znaků v konzoli.

---

## 🧠 Architektura a principy

Program byl rozdělen do několika klíčových částí:

- **`Application`** – hlavní objekt zajišťující běh aplikace. Uchovával GUI.
- **`Window`** – základní třída pro jednotlivá okna. Obsahovala logiku vykreslování a obsluhu kláves.
- **Hotkeys** – každé okno mělo vlastní seznam tlačítek reprezentujících různé akce (kopírování, mazání, atd.).  
  Tlačítka implementovala společné rozhraní, které obsahovalo jednu metodu – každé tlačítko ji přepisovalo dle své funkce.
- **Editor textových souborů** – nejtěžší část projektu. Dědil také z `Window` a obsahoval metody pro manipulaci s textem (výběr, kopírování, ukládání, apod.).

> Ne všechny funkce se podařilo dokončit a v některých případech aplikace selhávala (např. při pohybu kurzoru mimo hranice textu).

---

## 📅 Průběh práce

Na projekt jsme měli **1,5 měsíce**, s týdenními checkpointy, kde nám vyučující určoval nové cíle a hodnotil pokrok.

- Celkový čas práce: cca **150 hodin**
- Práce probíhala **ve spolupráci se spolužáky** – např. při pochopení konceptu událostí jsme si navzájem pomáhali.

---

## 💭 Závěrečné zhodnocení

I přes chyby a nedokončené funkce hodnotím projekt jako velmi přínosný. OOP jsem díky němu **prakticky pochopil** a naučil se základy správné struktury větších aplikací.

---
