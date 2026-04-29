# SchoolAPI - TP6 Project

Un projet .NET 8 contenant une API REST et une application client Razor Pages pour gérer les écoles.

## Structure du Projet

- **SchoolAPI**: Une API REST construite avec ASP.NET Core Web API
- **SchoolWebAppClient**: Une application Razor Pages qui consomme l'API

## Prérequis

- **.NET 8 SDK**: [Télécharger ici](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **Visual Studio 2026** ou supérieur
- **SQL Server LocalDB**: Inclus avec Visual Studio

## Installation et Configuration

### 1. Cloner le Repository
```bash
git clone https://github.com/firasmrabet/tp_6.git
cd tp_6
```

### 2. Démarrer SQL Server LocalDB
Ouvrez PowerShell et exécutez:
```powershell
sqllocaldb start mssqllocaldb
```

### 3. Appliquer les Migrations de Base de Données
Dans Visual Studio, ouvrez la **Package Manager Console** et exécutez:
```powershell
Update-Database -Project SchoolAPI
```

## Lancer le Projet

### Option 1: Avec Visual Studio
1. Ouvrez `TP6-Mrabet.sln` dans Visual Studio
2. **Définissez SchoolAPI comme projet de démarrage** en premier
3. Appuyez sur `F5` pour lancer l'API
4. **Ouvrez une deuxième instance de Visual Studio** (ou un autre terminal)
5. Lancez **SchoolWebAppClient**

### Option 2: Avec la Ligne de Commande
Terminal 1 - Démarrer l'API:
```bash
cd SchoolAPI
dotnet run
```

Terminal 2 - Démarrer le Client:
```bash
cd SchoolWebAppClient
dotnet run
```

## Ports par Défaut

- **API SchoolAPI**: `https://localhost:7005`
- **Client SchoolWebAppClient**: `https://localhost:7100`

## Accès à l'Application

- Application Client: https://localhost:7100
- Swagger API: https://localhost:7005/swagger/index.html

## Base de Données

La base de données est configurée dans `SchoolAPI/appsettings.json`:
```json
"ConnectionStrings": {
    "SchoolConnection": "Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## Important ⚠️

**Les deux applications doivent fonctionner en parallèle**:
- Ne fermez pas l'API SchoolAPI pendant l'utilisation du client
- Si vous changez le port de l'API, mettez à jour l'URL dans:
  - `SchoolWebAppClient/Controllers/SchoolClientController.cs` (ligne 16)

## Endpoints API

- `GET /api/SchoolsRepo/get-all-schools` - Obtenir toutes les écoles
- `GET /api/SchoolsRepo/get-school-by-id/{id}` - Obtenir une école par ID
- `GET /api/SchoolsRepo/search-by-name/{name}` - Chercher par nom
- `POST /api/SchoolsRepo/create-school` - Créer une nouvelle école
- `PUT /api/SchoolsRepo/edit-school/{id}` - Modifier une école
- `DELETE /api/SchoolsRepo/delete-school/{id}` - Supprimer une école

## Troubleshooting

### Erreur: "Aucune connexion n'a pu être établie"
- Vérifiez que SQL Server LocalDB est en cours d'exécution
- Vérifiez que l'API SchoolAPI est en cours d'exécution sur le port 7005
- Vérifiez la configuration de l'URL dans `SchoolClientController.cs`

### Erreur: "Database not found"
- Exécutez les migrations: `Update-Database -Project SchoolAPI`
- Vérifiez que la chaîne de connexion est correcte dans `appsettings.json`

## Technologies Utilisées

- .NET 8
- ASP.NET Core Web API
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger/OpenAPI

## Auteur

Firas Mrabet
