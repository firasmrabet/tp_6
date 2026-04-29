# 🚀 GUIDE DE LANCEMENT RAPIDE

## Démarrage en 5 minutes

### Étape 1: Démarrer SQL Server LocalDB
```powershell
sqllocaldb start mssqllocaldb
```

### Étape 2: Ouvrir la solution
- Ouvrez `TP6-Mrabet.sln` dans Visual Studio

### Étape 3: Appliquer les migrations
Package Manager Console:
```powershell
Update-Database -Project SchoolAPI
```

### Étape 4: Lancer l'API
1. Clic droit sur le projet **SchoolAPI** → "Set as Startup Project"
2. Appuyez sur **F5**
3. Attendez que l'API démarre sur `https://localhost:7005`

### Étape 5: Lancer le Client
1. Clic droit sur le projet **SchoolWebAppClient** → "Set as Startup Project"
2. Appuyez sur **F5**
3. L'application se lancera sur `https://localhost:7100`

## ✅ C'est prêt!

Vous pouvez maintenant:
- 📋 Voir toutes les écoles
- ➕ Ajouter une nouvelle école
- ✏️ Modifier une école
- 🗑️ Supprimer une école
- 🔍 Chercher une école par nom

## Liens utiles

- **API Swagger**: https://localhost:7005/swagger/index.html
- **Application Client**: https://localhost:7100

## Problèmes courants?

Voir le README.md pour le troubleshooting complet.
