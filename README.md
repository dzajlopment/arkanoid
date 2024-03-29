# Arkanoid

Jest to nasza wersja gry Arkanoid, stworzona w silniku Unity. Gra polega na niszczeniu kolorowych bloków za pomocą piłeczki odbijanej od platformy, sterowanej przez użytkownika. W skład gry wchodzą 32 poziomy + poziom specjalny oraz edytor poziomów.

## Proces budowania aplikacji
Do zbudowania aplikacji potrzebne jest środowisko Unity, dostępne przez platformę Unity Hub. Unity Hub jest dostępne do pobrania za darmo pod [tym adresem](https://unity.com/download) (należy nacisnąć przycisk "Download for Windows"). Następnie należy uruchomić instalator. Po zaakceptowaniu umowy licencyjnej można wybrać folder docelowy instalacji Unity Hub, a następnie wcisnąć przycisk "Zainstaluj". Po uruchomieniu Unity Hub należy wejść w zakładkę "Installs" po lewej stronie. W prawym gónym rogu pojawi się przycisk "Add". Po naciśnięciu na niego, program poprosi nas o wybranie wersji Unity, którą chcemy zainstalować. Wybieramy wersję Unity 2021.3.13f1, następnie naciskamy przycisk "Next". W następnym menu możemy odznaczyć wszystkie opcje poza "Windows Build Support (IL2CPP)" oraz wcisnąć przycisk "Done". Rozpocznie się instalacja Unity.

Po zainstalowaniu Unity należy wrócić do zakładki "Projects" (po lewej stronie). W prawym górnym rogu znajduje się przycisk "Add". Po wciśnięciu go program poprosi nas o wybranie folderu. Podajemy folder, w którym znajduje się kod źródłowy Arkanoida. Na liście projektów pojawi się nowy projekt o nazwie "arkanoid". Otwieramy go przez kliknięcie.

Po otwarciu projektu wchodzimy w menu "File" widoczne w lewym górnym rogu, a następnie wybieramy "Build And Run". Alternatywnie można zastosować skrót klawiszowy **Ctrl + B**. Podajemy folder, do którego ma zostać zbudowana aplikacja. Po zbudowaniu, aplikacja uruchomi sie automatycznie. Plik wykonywalny o nazwie "arkanoid version 1.exe" znajdzie się w wybranym folderze.

## Sterowanie

Gra obsługuje wejście z klawiatury oraz myszki.

|              Akcja              | Sterowanie na klawiaturze |
|:-------------------------------:|:-------------------------:|
|          Poruszanie się         | Strzałki / AD / Poziomy ruch myszy |
|          Oderwanie piłki        |           Spacja          |

## Bloki
Celem gry jest zniszczenie wszystkich bloków na planszy. Bloki można zniszczyć trafiając w nie piłką lub pociskami (przy aktywnym powerupie lasera). Piłka odbija się od każdej rzeczy, którą uderzy. Każdy blok ma swoją wartość punktową. Od tej wartości zależy ile punktów zostanie przyznane graczowi po zniszczeniu bloku. W grze występują bloki, które są możliwe do zniszczenia (w niektóre bloki trzeba trafić więcej razy aby zniszczyć blok) oraz bloki niezniszczalne.

Bloki występujące w grze:
- Biały - 50 pkt
- Pomarańczowy - 60 pkt
- Błękitny - 70 pkt
- Zielony - 80 pkt
- Czerwony - 90 pkt
- Niebieski - 100 pkt
- Fioletowy - 110 pkt
- Żółty - 120 pkt
- Srebny - 50 * numer etapu
- Złoty - niezniszczalne

## Ulepszenia

Na każdym z poziomów gracz po zniszczeniu bloku, ma szansę na trafienie kapsuły ulepszenia, którą będzie musiał złapać platformą. Ulepszenia będą dostępne tylko przez 1 rundę, do utraty piłki lub podniesienia innego ulepszenia.
 
 Dostępne ulepszenia w grze:
 - Dodatkowe życie (gracz zyskuje dodatkowe życie)
 - Lepek (piłka za każdym razem gdy spadnie na platformę, zostanie do niej przyklejona. Gracz może wystrzelić tę piłkę za pomocą spacji)
 - Laser (platforma gracza zmienia styl na platformę bojową. Z dział platformy będą samoistnie wystrzeliwywane lasery, które potrafią niszczyć bloki i odbijać piłkę)
 - Drzwi (na bokach poziomu pojawiają się drzwi, w które gracz może wejść platformą aby przejść na następny poziom)
 - Rozciągacz (platforma gracza staje się szersza)
 - Dodatkowa piłka (gracz dostaje dodatkową piłkę) (NIEDOSTĘPNE)
 - Anioł Stróż (na dole planszy pojawia się na 10 sekund bariera, przez którą piłki nie mogą wypaść poza planszę)
 - Super strzał (moc piłki zostaje zwiększona przez gorącą aurę wokół niej)

## Platforma
Ważnym elementem gry jest platforma. Gracz potrafi sterować platformą za pomocą myszki, strzałek lub AD. Platforma ma za zadanie odbijanie piłki aby utrzymać ją w granicach planszy. W przypadku wypadnięcia piłki poza planszę, gracz traci jedno życie, piłka pojawia się z powrotem nieruchomo na platformie. Aby wznowić ruch piłki należy kliknąć spację. Platforma ma tryb bojowy (po złapaniu uplepszenia laserowego). Platforma w trybie bojowym zmienia swój wygląd oraz samoistnie strzela laserami, które niszczą bloki i odbijają piłkę.

## Level Editor
https://github.com/Lord-Prinz-Team/leveleditor

Level Editor został zaimplementowany w NEXT.JS za pomocą web socketów. Ekran jest podzielony na planszę gry oraz zasobnik. Z zasobnika można wybierać bloki i przenosić je na planszę. Zmiany są zapisywane po 10 sekundach, wysyłane i zapisywane do pliku binarnego.

Aby otworzyć level editor potrzebna jest jedna z najnowszych przegądarek internetowych oraz zainstalowane środowisko node na komputerze.

Aby uruchomić aplikację należy w folderze z aplikacją należy napisać `npm run dev`.
