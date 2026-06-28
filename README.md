**Wichtiger Hinweis:** asToolkit ist keine schlüsselfertige Endkund:innen-Software und darf nicht ohne eigene Anpassungen im Livebetrieb eingesetzt werden. Das Projekt dient als technische Basis und Werkzeugkasten, auf dem Einzelhändler:innen, Integrator:innen und IT-Dienstleister eigene, individuelle Lösungen aufbauen können.

# asToolkit

asToolkit ist ein kostenloses, quelloffenes Toolkit mit wichtigen, alltagstauglichen Funktionen für den Einzelhandel. Statt eines schwergewichtigen ERP-Systems bündelt asToolkit modulare Bausteine, mit denen sich typische Handelsprozesse – von der Produkt- und Lagerverwaltung über den Verkauf bis zur Multichannel-Anbindung – schnell digitalisieren und automatisieren lassen. Die Plattform ist mandantenfähig und auf Erweiterbarkeit ausgelegt.

## Was asToolkit bietet
- Mandantenisolierte REST-API für Kunden-, Produkt-, Lager- und Auftragsverwaltung
- Bausteine für Angebote, Verkäufe, Rechnungen und Warenzugänge inklusive Nachverfolgung
- Multichannel-Anbindung: Verkaufskanäle (z. B. Shopware, WooCommerce, eBay, Point of Sale) und Versanddienstleister über konfigurierbare Schnittstellen
- Cross-Plattform-Oberflächen auf Basis der Uno Platform für Desktop-, Web- und Mobile-Clients
- Auswertungen zu Verkäufen, Produkten und Lagerbewegungen für schnelle Entscheidungen im Tagesgeschäft
- KI-gestützte Funktionen (z. B. Prompt-Verwaltung) zur Automatisierung wiederkehrender Aufgaben
- Kostenfrei, quelloffen und erweiterbar

## Für wen eignet sich asToolkit?
asToolkit richtet sich an Einzelhändler:innen sowie an Integrator:innen und IT-Dienstleister, die ein funktionsreiches Fundament suchen, um Handelsprozesse zu digitalisieren – ohne ein vollständiges ERP einführen zu müssen. Durch die klare Trennung von Server, UI-Clients und Integrationen lässt sich gezielt nur das nutzen und erweitern, was im jeweiligen Geschäft gebraucht wird. Umfangreiche automatische Tests (rund 1.500 Szenarien) sorgen für eine hohe Abdeckung der Kernprozesse und erleichtern die kontinuierliche Weiterentwicklung.

# Installation

asToolkit bietet verschiedene Installationsmöglichkeiten für unterschiedliche Anwendungsfälle und Infrastrukturen.

**Standard-Zugangsdaten**
- E-Mail: `admin@localhost.com`
- Passwort: `P@ssword1`

## 1. Installation per Docker Compose

Die einfachste Art, asToolkit mit einer vollständigen Umgebung zu starten. Alle benötigten Services (Server, Web-UI, Datenbank, Monitoring) werden automatisch konfiguriert und gestartet.

### Voraussetzungen
- Docker und Docker Compose installiert
- Git für das Klonen des Repositories

### SQLite (Standard, keine externe Datenbank erforderlich)
```bash
# Repository klonen
git clone https://github.com/asToolkit/asToolkit.git
cd asToolkit

# SQLite-Version starten
docker-compose up -d

# Mit Development-Einstellungen
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

### PostgreSQL
```bash
# PostgreSQL-Version starten
docker-compose -f docker-compose.postgresql.yml up -d

# Mit Development-Einstellungen
docker-compose -f docker-compose.postgresql.yml -f docker-compose.postgresql.override.yml up -d
```

### Microsoft SQL Server
```bash
# MSSQL-Version starten
docker-compose -f docker-compose.mssql.yml up -d

# Mit Development-Einstellungen
docker-compose -f docker-compose.mssql.yml -f docker-compose.mssql.override.yml up -d
```

### Zugriff auf die Services
- **asToolkit Server API**: `http://localhost:8443` (Swagger: `/swagger`)
- **asToolkit Web UI**: `http://localhost:8444`
- **Grafana Agent**: `http://localhost:12345`
- **Datenbank-Ports** (wenn in docker-compose aktiviert):
  - PostgreSQL: `localhost:5432`
  - MSSQL: `localhost:1433`

## 2. Installation mit externem Datenbank-Server

Für Produktionsumgebungen oder bei bereits vorhandener Datenbankinfrastruktur.

### Lokale Installation ohne Docker
1. .NET 10 SDK installieren
2. Repository klonen: `git clone https://github.com/asToolkit/asToolkit.git`
3. Abhängigkeiten laden: `dotnet restore`
4. Datenbankkonfiguration in `src/asToolkit.Server/appsettings.json` anpassen
5. Server starten: `dotnet run --project src/asToolkit.Server/asToolkit.Server.csproj`
6. API verfügbar unter: `https://localhost:5001` (Swagger: `/swagger`)

### Docker mit externer Datenbank
Alle Beispiele veröffentlichen den Server auf Port `8080`. Ersetze die Verbindungsparameter entsprechend Deiner Datenbankumgebung.

**SQLite (eingebaute Datei-Datenbank)**
```bash
docker run -d \
  --name astoolkit-server-sqlite \
  -p 8080:80 \
  -e DatabaseConfig__Provider=SQLite \
  -e DatabaseConfig__ConnectionString="Data Source=/data/astoolkit.db" \
  -v astoolkit-sqlite-data:/data \
  astoolkit/server:latest
```

**PostgreSQL (externe Datenbank)**
```bash
docker run -d \
  --name astoolkit-server-postgres \
  -p 8080:80 \
  -e DatabaseConfig__Provider=PostgreSQL \
  -e DatabaseConfig__ConnectionString="Host=postgres-host;Port=5432;Database=astoolkit;Username=astoolkit;Password=astoolkit;" \
  astoolkit/server:latest
```

**Microsoft SQL Server (externe Datenbank)**
```bash
docker run -d \
  --name astoolkit-server-sqlserver \
  -p 8080:80 \
  -e DatabaseConfig__Provider=MSSQL \
  -e DatabaseConfig__ConnectionString="Server=sqlserver-host;Database=astoolkit;User Id=astoolkit;Password=astoolkit;TrustServerCertificate=True;" \
  astoolkit/server:latest
```

## 3. Installation auf Synology NAS

asToolkit lässt sich optimal auf Synology NAS-Systemen über den Container Manager betreiben.

### Voraussetzungen
- Synology NAS mit DSM 7.0 oder höher
- Container Manager (ehemals Docker) aus dem Paket-Zentrum installiert
- Mindestens 2 GB RAM empfohlen

### Installation über Container Manager GUI

#### Schritt 1: Projekt erstellen
1. Container Manager öffnen → **Projekt** → **Erstellen**
2. Projektname: `astoolkit`
3. Pfad wählen (z.B. `/docker/astoolkit`)

#### Schritt 2: Docker Compose Datei konfigurieren
Wähle eine der folgenden Konfigurationen je nach gewünschter Datenbank:

**Für SQLite (empfohlen für kleine bis mittlere Installationen):**
```yaml
name: astoolkit

services:
  astoolkit.server:
    image: astoolkit/server:latest
    container_name: astoolkit-server
    environment:
      - DatabaseConfig__Provider=Sqlite
      - DatabaseConfig__ConnectionString=Data Source=/app/data/astoolkit.db
      - HTTP_PORTS=8443
    ports:
      - "8443:8443"
    volumes:
      - ./data:/app/data
    restart: unless-stopped

  astoolkit.browser:
    image: astoolkit/browser:latest
    container_name: astoolkit-browser
    environment:
      - ASTOOLKIT_SERVER_BASE_URL=http://localhost:8443
    ports:
      - "8444:80"
    depends_on:
      - astoolkit.server
    restart: unless-stopped
```

**Für PostgreSQL (empfohlen für größere Installationen):**
```yaml
name: astoolkit-postgresql

services:
  astoolkit.server:
    image: astoolkit/server:latest
    container_name: astoolkit-server
    environment:
      - DatabaseConfig__Provider=PostgreSQL
      - DatabaseConfig__ConnectionString=Host=postgresql;Port=5432;Database=astoolkit_01;Username=astoolkit;Password=astoolkit;
      - HTTP_PORTS=8443
    ports:
      - "8443:8443"
    depends_on:
      postgresql:
        condition: service_healthy
    restart: unless-stopped

  astoolkit.browser:
    image: astoolkit/browser:latest
    container_name: astoolkit-browser
    environment:
      - ASTOOLKIT_SERVER_BASE_URL=http://localhost:8443
    ports:
      - "8444:80"
    depends_on:
      - astoolkit.server
    restart: unless-stopped

  postgresql:
    image: postgres:16-alpine
    container_name: astoolkit-postgres
    environment:
      POSTGRES_DB: astoolkit_01
      POSTGRES_USER: astoolkit
      POSTGRES_PASSWORD: astoolkit
      PGDATA: /var/lib/postgresql/data/pgdata
    volumes:
      - ./postgres-data:/var/lib/postgresql/data
    restart: unless-stopped
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U astoolkit -d astoolkit_01"]
      interval: 10s
      timeout: 5s
      retries: 5
```

#### Schritt 3: Projekt starten
1. **Erstellen** klicken
2. Warten bis alle Container heruntergeladen und gestartet sind
3. Status im Container Manager überprüfen

#### Schritt 4: Zugriff konfigurieren

**Lokaler Zugriff:**
- Server-API: `http://[NAS-IP]:8443`
- Web-UI: `http://[NAS-IP]:8444`

**Externe Zugriffe (optional):**
1. DSM Systemsteuerung → **Externe Zugriffe** → **Router-Konfiguration**
2. Ports weiterleiten: 8443 (Server), 8444 (Web-UI)
3. Oder Reverse Proxy in DSM konfigurieren für SSL/HTTPS-Zugriff

### Installation über SSH (Fortgeschrittene)

```bash
# Per SSH auf das NAS verbinden
ssh admin@[NAS-IP]

# In Docker-Verzeichnis wechseln
cd /volume1/docker

# asToolkit-Verzeichnis erstellen
sudo mkdir astoolkit && cd astoolkit

# Docker Compose Datei erstellen (SQLite-Beispiel)
sudo tee docker-compose.yml << 'EOF'
name: astoolkit

services:
  astoolkit.server:
    image: astoolkit/server:latest
    container_name: astoolkit-server
    environment:
      - DatabaseConfig__Provider=Sqlite
      - DatabaseConfig__ConnectionString=Data Source=/app/data/astoolkit.db
      - HTTP_PORTS=8443
    ports:
      - "8443:8443"
    volumes:
      - ./data:/app/data
    restart: unless-stopped

  astoolkit.browser:
    image: astoolkit/browser:latest
    container_name: astoolkit-browser
    environment:
      - ASTOOLKIT_SERVER_BASE_URL=http://localhost:8443
    ports:
      - "8444:80"
    depends_on:
      - astoolkit.server
    restart: unless-stopped
EOF

# Container starten
sudo docker-compose up -d

# Status prüfen
sudo docker-compose ps
```

### Tipps für Synology NAS
- **Automatischer Start**: Container werden automatisch mit dem NAS gestartet
- **Updates**: Über Container Manager → Projekt → **Aktion** → **Erstellen**
- **Backups**: Daten-Ordner in Synology Backup-Routine einbeziehen
- **Monitoring**: Task Scheduler für Health-Checks nutzen
- **Ressourcen**: Bei mehreren Containern CPU/RAM-Limits setzen

### Troubleshooting
- **Port-Konflikte**: Andere Ports verwenden (z.B. 9443 statt 8443, 9444 statt 8444)
- **Berechtigungen**: Ordner-Berechtigungen für Docker-Volumes prüfen
- **Logs**: Container Manager → Container → **Details** → **Terminal** → **Logs**

## Nützliche Ressourcen
- GitHub-Repository: https://github.com/asToolkit/asToolkit
- Docker Hub: https://hub.docker.com/u/astoolkit
- Live-Frontend zur Benutzung mit beliebigen asToolkit.Server-Instanzen: https://www.astoolkit.de
