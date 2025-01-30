# Sistema de Ordem de Serviço para Assistência Técnica

Sistema completo para gerenciamento de ordens de serviço em assistências técnicas de celulares, composto por uma aplicação desktop (WPF) e um aplicativo mobile (React Native).

## 📱 Visão Geral

O sistema permite gerenciar todo o fluxo de trabalho de uma assistência técnica, desde o recebimento do aparelho até a entrega ao cliente, incluindo:
- Gestão de ordens de serviço
- Controle financeiro
- Gestão de estoque
- Registro fotográfico via app
- Comunicação com clientes

## 🏗 Arquitetura

![Diagrama de Componentes](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/abraaodeveloper/cell-fix-manager/main/component_diagram.puml)

O sistema é composto por:
- **Aplicação Desktop (WPF)**: Sistema principal de gerenciamento
- **Aplicativo Mobile (React Native)**: Para registro de fotos e atualizações em campo
- **API Server**: Integração entre o app mobile e o sistema desktop
- **Banco de Dados**: Armazenamento centralizado
- **Serviço de Armazenamento**: Para fotos e documentos

### Fluxo de Dados

![Diagrama de Fluxo](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/abraaodeveloper/cell-fix-manager/main/data_flow_diagram.puml)

## 🛠 Funcionalidades Principais

### Sistema Desktop
- Cadastro de clientes e aparelhos
- Gestão de ordens de serviço
- Controle de estoque de peças
- Gestão financeira
- Geração de relatórios
- Impressão de OS e recibos

### Aplicativo Mobile
- Registro fotográfico dos aparelhos
- Atualização de status das OS
- Consulta de estoque
- Chat interno com a loja
- Leitura de QR Code das OS

### Gestão Financeira
- Controle de custos por serviço
- Gestão de compra de peças
- Cálculo de lucro por OS
- Relatórios financeiros
- Controle de pagamentos

## 🔧 Tecnologias Utilizadas

### Desktop (WPF)
- C# (.NET 6+)
- WPF (XAML)
- Entity Framework Core
- ASP.NET Minimal API
- iTextSharp/QuestPDF

### Mobile (React Native)
- React Native
- Expo
- Axios
- React Navigation
- React Native Camera

### Banco de Dados
- MySQL/SQLite
- Entity Framework Core

## 📋 Status do Projeto

- [x] Definição da arquitetura
- [x] Diagramas de sistema
- [ ] Implementação do sistema desktop
- [ ] Implementação do aplicativo mobile
- [ ] Testes integrados
- [ ] Documentação completa

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).
