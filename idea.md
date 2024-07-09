Ants Wars (Mravenčí války)

Hra byla vytvořena jako závěřečný projekt do předmětu AK8PO na Fakultě aplikované informatiky
Univerzitě Tomáše Bati ve Zlíně. Tato hra je inspirována hrou mravenci, která vznikla začátkem 
milénia.

1. Stručný popis

Jedná se o jednoduchou karetní hru, která se skládá ze dvou týmů. Prvním týmem je tým černých maravenců,
tento tým je ovládán uživatelem. Druhý tým se skládá z červených mravenců a je řízen počítačem.
Hráči pro útok na protihráče nebo na vlastní obranu používají vygenerovanou paletu karet. 
Cílem hry je zničit hrad soupeře.

1.1. Zahájení hry

Spuštění je vyvoláno kliknutím na tlačítko "Nová hra" umístěné mezi dvěmi hromádky karet.
Při zahájení hry má každý hráč k dispozici 10 ks od každé suroviny (zbraň, kámen a magie),
a také každý hráč vlastní 2 řemeslníky každého typu (cvičitel, stavitel a kouzelník).
Hrad je vždy nastaven na 25 polí a zeď je nastavena na 15 polí.

1.2. Opětovný start hry

Opětovné spuštění je vyvoláno kliknutím na tlačítko "Nová hra" umístěné mezi dvěmi hromádkami karet.

1.3. Vítězství

Vítězným týmem je ten, který jako první zníčí hrad soupeře.

1.4. Použití karty

Kartu lze použít, když na ni hráč klikne levým tlačítkem myši. Po použití karta způsobí útok na protihráče
nebo vyvolá specifickou obranou událost.

Hráč může kartu použít za těchto podmínek:
- hráč je zrovna na tahu
- cena karty je nižší nebo rovna počtu odpovídajích surovin vlastněných hráčem.

1.5. Odložení karty

Kartu lze odložit, když na ni hráč klikne pravým tlačítkem myši. Po odložení je karta přesunuta na hromádku
použitých karet a neovlivní průběh hry. V případě, že nelze v daném tahu použít žádnou kartu, pak hráč musí
jednu ze svých karet odložit.

1.6. Ukončení kola

Po ukončení daného kola (teda po odehrátí hráče a počítače) je vždy do inventáře obou hráčů přičten počet
surovin odpovídající počtu řemeslníků, které kařdý hráč vlastní.

2. Herní komponenty

2.1. Hrad

Hrad je nejdůležitější komponenta hry. Pokud soupeř zničí Váš hrad, pak jste prohráli hru!
Hrad je na začátku hry nastaven na hodnotu 25 polí. Hrad se skládá celkem z 5ti obrázků. 
V případě zobrazení kompletního hradu musí platit, že je jeho velikost 25 polí a vyšší, 
a naopak v případě že je velikost hradu 0, pak není zobrazen žádný obrázek.
Maximální velikost hradu není omezena, ale minimální velikost je omezena na 0.

2.2. Hradba

Účelem hradby je obrana hradu před základními typy útoků. V případě použití základního útoku
je nejdříve ničena hradba a nikoli samotný hrad.
Hradba je na začátku nastavena na hodnotu 15 polí. Hradba se skládá celkem z 5ti obrázků. 
Maximální hradba je zobrazena od velikosti 25 polí a pro hodnotu 0 není zobrazena žádná hradba.
Pokud je útok silnější než aktuální hradba, pak je útokem zničena hradba a i část hradu.
Maximální hodnota hradby není omezena, ale minimální velikost je omezena na 0.

2.3. Zdroje

Zdroje jsou suroviny, které hráč vlastní v inventáři. Při startu hry každný hráč vlastní 10 ks
od každé suroviny. Suroviny lze získat po ukončení kola od řemeslníků nebo speciálními kartami.
Suroviny se odeberou po použití karty, kdy se odečte od dané suroviny cena karty nebo mohou být
surovny zničeny specifickou kartou vyvolanou protihráčem.

2.3.1. Zbraně

Zbraň je základní surovina, která je nutná k vyvolání útočných karet. Zdraně jsou zobrazeny vedle
symbolu "meče".

2.3.2. Kámen

Kámen je základní surovina, která je nutná k defenzivním stavitelským účelům. Kámen je zobrazen vedle
symbolu "kamene".

2.3.3. Magie

Magie je suroviny využívaná jak pro defenzivní tak ofenzivní praktiky. Magie je zobrazena vedle symbolu 
"lektvaru".

2.4. Řemeslníci

Řemeslníci po každém ukončeném kole přidají suroviny do inventáře každého hráče. Počet přidaných surovin
odpovídá počtu řemeslníků daného druhu, které hráč vlastní. Řemeslníky lze přidat pomocí speciálních karet
nebo je lze i zničit vyvoláním útočné karty. Maximální počet řemeslníků není omezen, minimální počet je 
vždy 1.

2.4.1 Cvičitel

Cvičitel přidává zbraně do inventáře. Počet cvičitelů je možné vidět za sympolem "/" u zbraně.

2.4.2. Stavebník

Stavebník přidává kámen do inventáře. Počet stavebníků je vidět za symbolem "/" u kamene.

2.4.3. Kouzelník

Kouzelník přidává magii do inventáře. Počet kouzelníků je možné vidět za symbolem "/" u magie.

2.5. Balíček použitých karet

Balíček použitých karet je vidět ve středu obrazovky v horní části. Na začátku každé hry je první
kartou zadní strana balíčku. Po použití nebo odložení karty je tato karta přesunuta na balíček 
použitých karet.

2.6. Karty

Karty jsou základní ofenzivní a defenzivní prvky hry. Každá karta je reprezentována symbolem suroviny
(v levém horním rohu), symbolem počtu (v pravém horním rohu - počet suroviny daného typu nutný k 
aktivování dané karty) a funkcí, která je uvedena na středu karty.

2.6.1. - Útok 5

Cena karty: Zbraň/3 (typ suroviny/počet)
Účinek: zničí hradbu/hrad protihráče o 5 polí

2.6.2. - Útok 10

Cena karty: Zbraň/5
Účinek: zničí hradbu/hrad protihráče o 10 polí

2.6.3. - Znič hradbu 5

Cena karty: Zbraň/1
Účinek: zničí hradbu protihráče o 5 polí

2.6.4. - Znič hradbu 10

Cena karty: Zbraň/2
Účinek: zničí hradbu protihráče o 10 polí

2.6.5. - Znič hrad 5

Cena karty: Zbraň/5
Účinek: zničí hrad protihráče o 5 polí

2.6.6. - Znič hrad 10

Cena karty: Zbraň/10
Účinek: zničí hrad protihráče o 10 polí

2.6.7. - Znič zbraně 5

Cena karty: Magie/3
Účinek: zničí zbraně protihráče o 5 surovin

2.6.8. - Znič kámen 5 

Cena karty: Magie/3
Účinek: zničí kámen protihráče o 5 surovin

2.6.9. - Znič magii 5

Cena karty: Magie/3
Účinek: zničí magii protihráče o 5 surovin

2.6.10. - Postav hrad 5

Cena karty: Kámen/5
Účinek: Zvýší hrad o 5 polí

2.6.11. - Postav hradbu 5

Cena karty: Kámen/3
Účinek: Zvýší hradbu o 5 polí

2.6.12. - Přidej cvičitele 1

Cena karty: Zbraň/8
Účinek: zvýší počet cvičitelů o 1 

2.6.13. - Přidej stavebníka 1 

Cena karty: Kámen/8
Účinek: zvýší počet stavebníků o 1

2.6.14. - Přidej kouzelníka 1

Cena karty: Magie/8
Účinek: zvýší počet kouzelníků o 1

2.6.15. Přidej zbraně 8 

Cena karty: Magie/3
Účinek: zvýší počet zbraní o 8

2.6.16. - Přidej kamení 8

Cena karty: Magie/3
Účinek: zvýši počet kamení o 8

2.6.17. - Přidej magii 8

Cena karty: Magie/3
Účinek: zvýší počet magie o 8

2.6.18. Znič stavebníka, kouzelníka, cvičitele

Cena karty: Zbraň/8
Účinek: zničí protihráči jednoho stavebníka, kouzelníka a cvičitele 
