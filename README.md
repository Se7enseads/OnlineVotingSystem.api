# Online Voting System - API

## Setup instructions

1. [Linux](#linux)
2. [Windows](#windows)

---

## Linux

### 1. Install .NET 8 SDK

Run the following command to download the .NET installation script:

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
```

Then execute it:

```bash
chmod +x dotnet-install.sh
./dotnet-install.sh --version latest
```

To make sure .NET is installed, run:

```bash
dotnet --version
```

### 2. Install Entity Framework Core global tool

```bash
dotnet tool install --global dotnet-ef
```

### 3. Clone the repository

```bash
git clone https://github.com/Se7enseads/OnlineVotingSystem.api.git
```
### 4. Install [Jetbrains toolbox](https://www.jetbrains.com/toolbox-app/) and then install Rider .NET in the toolbox

### 5. Open the cloned repo with rider
```bash
rider OnlineVotingSystem.api
```

### 5. Install dependencies in the rider terminal

```bash
dotnet restore
```

### 6. Apply database migrations in the terminal

```bash
dotnet ef database update
```

### 7. Run the application or `Ctrl + F5`

```bash
dotnet run
```

The API should now be running at `http://localhost:5000` or any other port.

---

## Windows

### 1. Install .NET 8 SDK

Download the latest .NET SDK from the official [Microsoft website](https://dotnet.microsoft.com/en-us/download) and install it.

Verify the installation by running:

```powershell
dotnet --version
```

### 2. Install Visual Studio

Download and install [Visual Studio](https://visualstudio.microsoft.com/) with the ".NET Core cross-platform development" workload.

### 3. Install Entity Framework Core global tool

```powershell
dotnet tool install --global dotnet-ef
```

### 4. Clone the repository

Open PowerShell and run:

```powershell
git clone <your-repository-url>
cd <your-project-folder>
```

### 5. Open the project in Visual Studio

Launch Visual Studio and open the cloned directory.

### 6. Install dependencies

```powershell
dotnet restore
```

### 7. Apply database migrations

```powershell
dotnet ef database update
```

### 8. Run the application

```powershell
dotnet run
```

The API should now be running at `http://localhost:5000`.

---

## Notes
- To change the listening port, modify `appsettings.json` or use:

  ```bash
  dotnet run --urls=http://localhost:PORT
  ```
- Videos to watch
> https://youtu.be/AhAxLiGC7Pc
> https://youtu.be/w8I32UPEvj8



