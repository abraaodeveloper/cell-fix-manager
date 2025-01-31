# Sistema de Ordem de Serviço para Assistência Técnica de Celulares

## 📌 Visão Geral
Este projeto consiste em um **sistema de ordem de serviço** voltado para assistências técnicas de celulares, permitindo a gestão completa dos reparos, clientes, estoque de peças e fluxo financeiro. O sistema é composto por três principais componentes:

1. **Aplicação Desktop (WPF - C#)**: Interface principal para gerenciar ordens de serviço, estoque e financeiro.
2. **Aplicativo Mobile (React Native)**: Permite técnicos cadastrarem fotos e atualizarem status remotamente.
3. **WebService (Laravel + MySQL)**: Centraliza todas as informações para que qualquer aplicação possa consumir os dados.

## 🔧 Tecnologias Utilizadas

| Componente        | Tecnologia         |
|------------------|------------------|
| **Frontend Desktop** | WPF (C#) |
| **Frontend Mobile** | React Native |
| **Backend** | Laravel (PHP) |
| **Banco de Dados** | MySQL |

---

## ⚙️ Arquitetura do Sistema
O sistema foi projetado para que todos os dados sejam armazenados e gerenciados pelo **WebService Laravel**, permitindo que qualquer aplicação (desktop, mobile ou web) possa acessar as informações de forma centralizada.

### **Diagrama de Componentes**
![Fluxo de Dados](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/abraaodeveloper/cell-fix-manager/main/docs/component_diagram.puml)

### **Fluxo de Dados**
![Fluxo de Dados](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/abraaodeveloper/cell-fix-manager/main/docs/data_flow_diagram.puml)



### **Sequência - Atualização de Status**
![Diagrama de Sequência](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/abraaodeveloper/cell-fix-manager/main/docs/sequence_status_update.puml)

---

## 🔥 Funcionalidades

### 🖥️ **Aplicação Desktop (WPF - C#)**
✅ Gerenciamento de Ordens de Serviço (Cadastro, Edição, Exclusão)
✅ Impressão de Ordem de Serviço com QR Code
✅ Controle de Estoque de Peças
✅ Relatórios Financeiros (Lucro por Serviço, Gastos com Peças)
✅ Histórico de Reparos por Cliente
✅ Integração com WhatsApp para avisos automáticos

### 📱 **Aplicativo Mobile (React Native)**
✅ Captura e envio de fotos do aparelho para a OS
✅ Atualização de Status da OS em tempo real
✅ Chat interno entre técnico e loja
✅ Consulta rápida de peças no estoque
✅ Leitura de QR Code para abrir OS diretamente no app

### 🌐 **WebService (Laravel + MySQL)**
✅ API RESTful para comunicação com todas as aplicações
✅ Gerenciamento centralizado das Ordens de Serviço
✅ Controle de Estoque e Movimentação Financeira
✅ Autenticação e controle de usuários
✅ Upload e armazenamento de imagens

---

## 🚀 Como Rodar o Projeto

### 🔹 Backend (Laravel)
```bash
# Clone o repositório
git clone https://github.com/abraaodeveloper/cell-fix-manager.git
cd cell-fix-manager/backend

# Instale as dependências
composer install

# Configure o banco de dados
cp .env.example .env
nano .env  # Edite as credenciais do MySQL
php artisan migrate --seed

# Rode o servidor
php artisan serve
```

### 🔹 Aplicação Desktop (WPF - C#)
- Abra o projeto no **Visual Studio**
- Configure a URL do WebService Laravel
- Compile e execute

### 🔹 Aplicativo Mobile (React Native)
```bash
# Clone o repositório e entre no diretório mobile
cd cell-fix-manager/mobile

# Instale as dependências
npm install

# Execute em um dispositivo/emulador
npx expo start
```

---

## 🔄 Melhorias Futuras
🚀 Criar uma interface web para acesso via navegador
🚀 Implementar notificações push para atualização de status
🚀 Integração com pagamento online para clientes

Se tiver dúvidas ou sugestões, abra uma issue! 😊

