# REST-API f�r CV-hantering

![ER-Diagram](c:\Users\rasmu\source\repos\Cv-handling\ER-Diagram.png)

---
# Vad du ska g�ra

**Databasen**

Du ska designa och skapa en databas som lagrar information om en persons utbildning och arbetslivserfarenhet.

- [x]  **Personlig information**
    - Namn, beskrivning, kontaktuppgifter.
- [x]  **Utbildningar**
    - Skola, examen, start- och slutdatum.
- [x]  **Arbetserfarenhet**
    - Jobbtitel, f�retag, beskrivning och �r.

- [x]  Designa ett **ER-diagram** som visar hur tabellerna �r relaterade.
- [x]  Skapa databasen med **Entity Framework Core** genom **Code-First**.
- [x]  L�gg upp en bild av ditt **ER-diagram** i **README-filen** i ditt Git-repo.

---

**Skapa ett REST-API**

Ditt API ska g�ra det m�jligt att hantera information om en persons utbildningar och arbetslivserfarenhet.

Anropen till databasen ska l�sas genom Entity Framework.

- [x]  **H�mta all data** (alla personer, utbildningar och jobberfarenheter).
- [x]  **H�mta en specifik post** baserat p� dess ID.
- [x]  **L�gga till ny utbildning eller jobberfarenhet**.
- [x]  **Uppdatera befintlig information** (t.ex. �ndra jobbtitel eller examens�r).
- [x]  **Ta bort en utbildning eller jobberfarenhet**.

---

**Integrera ett externt API**

F�r att inkludera anrop till externa API:er ska du:

- [x]  Implementera en endpoint d�r en anv�ndare kan **ange sitt GitHub-anv�ndarnamn**.
- [x]  N�r anv�ndarnamnet anges ska API:et h�mta **en lista �ver personens publika GitHub-repositories** via GitHub API.
- [x]  Returnera **minst** f�ljande information:
    - Repository-namn.
    - Spr�k som anv�nds i repot (om inget spr�k anges, returnera �ok�nt� som v�rde).
    - Beskrivning av repot (om finns, annars �saknas� som v�rde).
    - L�nk till repot.

---

**S�kerhet & validering**

F�r att s�kerst�lla att API:et �r robust och s�kert ska du:

- [x]  Implementera **validering** f�r att f�rhindra att ogiltiga eller tomma f�lt skickas in.
- [x]  S�kerst�ll att API:et returnerar **relevanta status koder** vid olika typer av anrop.

