# REST-API för CV-hantering

![ER-Diagram](https://github.com/user-attachments/assets/c4f2876d-14d7-4e16-98db-6e3f92f4d84b)

---
# Vad du ska göra

**Databasen**

Du ska designa och skapa en databas som lagrar information om en persons utbildning och arbetslivserfarenhet.

- [x]  **Personlig information**
    - Namn, beskrivning, kontaktuppgifter.
- [x]  **Utbildningar**
    - Skola, examen, start- och slutdatum.
- [x]  **Arbetserfarenhet**
    - Jobbtitel, företag, beskrivning och år.

- [x]  Designa ett **ER-diagram** som visar hur tabellerna är relaterade.
- [x]  Skapa databasen med **Entity Framework Core** genom **Code-First**.
- [x]  Lägg upp en bild av ditt **ER-diagram** i **README-filen** i ditt Git-repo.

---

**Skapa ett REST-API**

Ditt API ska göra det möjligt att hantera information om en persons utbildningar och arbetslivserfarenhet.

Anropen till databasen ska lösas genom Entity Framework.

- [x]  **H�mta all data** (alla personer, utbildningar och jobberfarenheter).
- [x]  **H�mta en specifik post** baserat på dess ID.
- [x]  **L�gga till ny utbildning eller jobberfarenhet**.
- [x]  **Uppdatera befintlig information** (t.ex. ändra jobbtitel eller examensår).
- [x]  **Ta bort en utbildning eller jobberfarenhet**.

---

**Integrera ett externt API**

För att inkludera anrop till externa API:er ska du:

- [x]  Implementera en endpoint där en användare kan **ange sitt GitHub-anv�ndarnamn**.
- [x]  När användarnamnet anges ska API:et hämta **en lista över personens publika GitHub-repositories** via GitHub API.
- [x]  Returnera **minst** följande information:
    - Repository-namn.
    - Språk som används i repot (om inget språk anges, returnera "okänt" som värde).
    - Beskrivning av repot (om finns, annars "saknas" som värde).
    - Länk till repot.

---

**Säkerhet & validering**

För att säkerställa att API:et är robust och säkert ska du:

- [x]  Implementera **validering** för att förhindra att ogiltiga eller tomma fält skickas in.
- [x]  Säkerställ att API:et returnerar **relevanta status koder** vid olika typer av anrop.

