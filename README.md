## Tim14-VisokaSimbolika
**Visoka Simbolika
Članovi Tima:**

1. Škulj Dženita
2. Šikić Haris
3. Šero Nermin

### Opis teme
--- 

Aplikacija  TutorFinder za svrhu ima lakšu organizaciju razmjene znanja i lakše povezivanje ljudi kojima je potrebno znanje iz određene oblasti i ljudi koji prenose znanje iz određene oblasti. Aplikacija će imati za mogućnost biranja statusa korisnika tj. instruktor ili klijent. Korisnik klijent će imati uvid u kvalitet održavanje instrukcija određenog instruktora i na osnovu toga može da bira instruktora što će mu pomoći u bespotrebom gubljenju vremena, a korisnik instruktor će moći da promovira svoj rad na osnovu kvaliteta održanih instrukcija sticanjem dobrog rejtinga. Korisnik klijent će moći da bira instruktora u svom neposrednom okruženju što je još jedna od prednosti aplikacije. A korisnik instruktor će moći da postavlja određene materijale na svoj profil vezano za određene predmete.

### Procesi
---

#### Registracija korisnika na aplikaciju

 * Na početnom prikazu aplikacije javlja se mogućnost registracije i osoba koja želi da koristi tu aplikaciju mora se registrovati. Korisnik se registruje sa osnovnim podacima o sebi, a to su :
-	Ime 
-	Prezime
-	E-mail
-	Password
-	Lokacija
-	Biranje statusa: 
       1.	Klijent
       2.	Instruktor 
       
Ukoliko korisnik odabere stavku *klijent* proces registracije se završava slanjem mail-a čime se klijent mora verifikovati da bi se obavio proces dosljednosti. Time je registracija za klijenta završena.
Ukoliko je korisnik *instruktor*, on mora da obavi dodatni unos podataka, a to znači da mora odabrati predmete, ukoliko postoje, ili unijeti predmete, ukoliko predmeti nisu u sistemu, iz čega drži instrukcije . 
S tim da korisnici mogu naknadno vršiti uređivanje profila i to instruktori mogu mijenjati spisak predmeta iz kojih drže instrukcije i lokaciju, a klijent može da mijenja samo lokaciju i obje strane korisnika mogu dodavati svoju fotografiju na profil.

#### Proces kreiranja termina i prijava na iste 

 * Proces kreiranja termina za određeni predmet se vrši tako što korisnik instruktor može da odabere dane u sedmici i tačno vrijeme termina u kojima može da održi instrukcije. Termini traju 7 dana, te se svake sedmice moraju ažurirati.
Korisnik klijent  se tada može prijaviti na neki od navedenih termina pri čemu se instruktor obavještava o prijavi klijenta. 
Ukoliko dođe do izmjene da instruktor ili klijent zbog nekog razloga treba da otkaže instrukcije, obavještenje se šalje drugoj strani uz komentar sa navedenim razlogom otkazivanja. 

#### Proces ocjenjivanja instruktora 

 * Korisnik klijent po završetku instrukcija mora da ocijeni instruktora sa ocjenom od 1 do 5. 
(ovo nije dovršeno, treba još razraditi)

#### Upload radnih materijala
 * Korisnik iz reda instruktora može otvoriti stranicu za upload radnih materijala. Sistem mu pruža izbornik sa predmetima iz kojih navedeni korisnik nudi instrukcije te opciju za uploadnavedenih dokumenata. Dozvoljeno je uploadovati samo specifične tipove datoteka (doc, 	pdf i sl.) iz sigurnosnih i praktičnih razloga. Nakon uploada administrator (eventualno neki automatizovani sistem) vrši provjeru ispravnosti i validnosti datoteka te odobrava pristup klijentima navedenim datotekama.

#### Odabir predmeta iz kojeg klijent zahtijeva uslugu
 * Korisnik ima mogućnost dobijanja spiska svih raspoloživih predmeta. Nakon izbora određenog predmeta klijentu se nudi izbornik u kojem može dobiti spisak instruktora na osnovu klijentove lokacije ili spisak svih raspoloživih instruktora

#### Traženje instruktora na osnovu navedene lokacije klijenta
 * Tom prilikom klijent dobija spisak instruktora koji nude usluge instrukcije iz odabranog predmeta a koji se nalaze unutar unaprijed definirane okoline u odnosu na lokaciju klijenta (i odabranog predmeta). Iz tog izbornika klijent može pristupiti svakom od datih profila instruktora te obaviti ranije navedeni postupak ugovaranja termina održavanja instrukcija.



### Funkcionalnosti
---
 
 * Mogućnost postavljanja termina od strane instruktora i zakazivanje odgovarajucih termina od strane korisnika
 * Mogućnost potvrde održavanja instrukcija od strane klijenta, skeniranjem nfc-koda instruktora, čime dobiva mogućnost za ocjenjivanje             odgovarajućeg instruktora
 * Mogućnost pregleda informacija o instruktoru ( broj telefona, ocjena, predmet, cijena po satu)
 * Mogućnost postavljanja materijala od strane instruktora
 * Mogućnost odabira instruktora koji je u neposrednom okruzenju (na osnovu lokacije korisnika)
 * Mogućnost otkazivavnja termina uz navođenje razloga

### Akteri
---

* **Globalni administrator** je osoba na vrhu hijerarhije korisnika navedenog sistema, preciznije vlasnik i kreator datog sistema. 
	* Njegov korisnički račun je anoniman (iz praktičnih i sigurnosnih razloga)
	* Vrši nadgledanje kompletnog u potrazi sa sumnjivim aktivnostima
	* Ima pravo odstraniti pojedine korisnike (botove i problematične korisnike)
	* Vrši verifikaciju korisnika prilikom registracije i validaciju postavljenih radnih materijala

* **Instruktori** su korisnici sistema koji pružaju usluge instrukcija korisnicima iz reda klijenata
	* Posjeduju korisnički račun koji je javan
	* Mogu urediti vlastiti profil po volji (lični podaci, profilna slika, predmeti iz kojih drže 	 	    instrukcije, lokacija, dodatne informacije)
	* Imaju mogućnost kreiranja i otkazivanja  termina u kojima su na raspolaganju klijentima
	* Imaju mogućnost postavljanja različitih radnih materijala (uz naknadno odobravanje 		   globalnog administratora)
	* Profil instruktora pored osnovnih informacija o samom instruktoru sadrži rubriku sa 	    	   rejtingom datog instruktora koji govori o kvalitetu usluga koje pruža

* **Klijenti** su korisnici sistema koji traže uslugu pružanja instrukcija iz određenih predmeta
	* Posjeduju profil koji nije vidljiv drugim klijentima dok je instruktorima koji im pružaju 	  	   usluge vidljiv
	* Na instruktorovom profilu mogu birati odnosno otkazivati ponuđene termine za određeni 	   predmet
	* Imaju pristup određenim radnim materijalima instruktora koji im pružaju uslugu
	* Imaju mogućnost ocjenjivanja kvaliteta pruženih usluga

