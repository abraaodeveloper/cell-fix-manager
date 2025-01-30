# Guia de Configuração do Ambiente de Desenvolvimento

## Ubuntu/Debian

### 1. Instalar .NET SDK
```bash
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-7.0
```

### 2. Instalar dependências necessárias
```bash
sudo apt-get install -y libfontconfig1 libgtk-3-0
```

### 3. Instalar VS Code
```bash
sudo snap install code --classic
```

### 4. Instalar Git
```bash
sudo apt-get install git
```

### 5. Instalar templates Avalonia
```bash
dotnet new install Avalonia.Templates
```

### 6. Instalar ferramentas de desenvolvimento
```bash
dotnet tool install -g dotnet-watch
```

## Fedora/RHEL

### 1. Instalar .NET SDK
```bash
sudo dnf install dotnet-sdk-7.0
```

### 2. Instalar dependências necessárias
```bash
sudo dnf install fontconfig gtk3
```

### 3. Instalar VS Code
```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo sh -c 'echo -e "[code]\nname=Visual Studio Code\nbaseurl=https://packages.microsoft.com/yumrepos/vscode\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/vscode.repo'
sudo dnf install code
```

### 4. Instalar Git
```bash
sudo dnf install git
```

### 5. Instalar templates Avalonia
```bash
dotnet new install Avalonia.Templates
```

### 6. Instalar ferramentas de desenvolvimento
```bash
dotnet tool install -g dotnet-watch
```

## macOS

### 1. Instalar Homebrew (se ainda não tiver)
```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

### 2. Instalar .NET SDK
```bash
brew install --cask dotnet-sdk
```

### 3. Instalar VS Code
```bash
brew install --cask visual-studio-code
```

### 4. Instalar Git
```bash
brew install git
```

### 5. Instalar templates Avalonia
```bash
dotnet new install Avalonia.Templates
```

### 6. Instalar ferramentas de desenvolvimento
```bash
dotnet tool install -g dotnet-watch
```

## Windows

### 1. Instalar Chocolatey (Execute no PowerShell como Administrador)
```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

### 2. Instalar .NET SDK
```powershell
choco install dotnet-sdk
```

### 3. Instalar VS Code
```powershell
choco install vscode
```

### 4. Instalar Git
```powershell
choco install git
```

### 5. Instalar templates Avalonia
```powershell
dotnet new install Avalonia.Templates
```

### 6. Instalar ferramentas de desenvolvimento
```powershell
dotnet tool install -g dotnet-watch
```

## Verificação da Instalação

### Verificar versão do .NET
```bash
dotnet --version
```

### Verificar se o Avalonia está instalado
```bash
dotnet new list | grep avalonia
```

### Criar projeto de teste
```bash
dotnet new avalonia.mvvm -n TestProject
cd TestProject
dotnet run
```

## Configuração de Debug no VS Code

Crie um arquivo `launch.json` com o seguinte conteúdo:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Launch Avalonia",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/bin/Debug/net7.0/CellFixManager.Desktop.dll",
      "args": [],
      "cwd": "${workspaceFolder}",
      "stopAtEntry": false,
      "console": "internalConsole"
    }
  ]
}
```

## Criar e Executar um Projeto Avalonia

### Criar novo projeto
```bash
dotnet new avalonia.mvvm -n CellFixManager.Desktop
```

### Executar com hot reload
```bash
dotnet watch run
```

### Publicar para diferentes plataformas
```bash
dotnet publish -c Release -r win-x64 --self-contained true
dotnet publish -c Release -r linux-x64 --self-contained true
dotnet publish -c Release -r osx-x64 --self-contained true
```

## Ajustes Adicionais para macOS

Adicionar Homebrew ao caminho:
```bash
echo 'eval "$(/opt/homebrew/bin/brew shellenv)"' >> ~/.zprofile
eval "$(/opt/homebrew/bin/brew shellenv)"
```

## Ajustes Adicionais para Windows

Habilitar execução de scripts no PowerShell:
```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

