# Desafio Técnico - Sistema de Cadastro de Estudantes

Este projeto é a resolução de um desafio técnico prático para a vaga de Desenvolvedor(a) Trainee, focado em demonstrar habilidades em desenvolvimento FullStack.

## 🚀 Funcionalidades

O sistema permite o cadastro de estudantes e suas respectivas notas em diversas disciplinas. As principais funcionalidades são:
* **Cadastro de Estudante:** Inserção de `Nome` e `Idade`.
* **Cadastro de Notas:** Associação de `Disciplina` e `Nota` a um estudante, permitindo múltiplas notas por estudante.
* **Validações de Negócio:** Aplicação de regras de negócio para garantir a integridade dos dados:
    * Nome do estudante não pode ser vazio.
    * Idade do estudante deve ser maior que 0.
    * Nota da disciplina deve estar entre 0 e 10.
* **Comunicação Front-End ↔ Back-End:** Integração completa entre a interface do usuário e a API.

## 💻 Tecnologias Utilizadas

* **Back-End (API):**
    * `ASP.NET Core 8.0` (LTS)
    * `C#`
    * `Dapper` (Micro-ORM para acesso a dados)
    * `SQL Server Express` (Banco de Dados Relacional)
    * `Swagger/OpenAPI` (Documentação e teste da API)
* **Front-End:**
    * `Angular` (CLI v17.x.x)
    * `TypeScript`
    * `HTML5`
    * `CSS3` (Estilização básica)
* **Controle de Versão:**
    * `Git` & `GitHub`

## 📁 Estrutura do Projeto

O repositório está organizado em três pastas principais, refletindo a arquitetura do projeto:

* `Backend/`: Contém o projeto ASP.NET Core Web API em C#.
* `Frontend/`: Contém o projeto Angular.
* `Database/`: Contém os scripts SQL para criação do banco de dados e tabelas.

Na raiz do repositório, você também encontrará:
* `perguntas_feitas_para_ia`: Documentação sobre o uso de Inteligência Artificial durante o desenvolvimento.
* `SitesDocumentacoes`: Lista de documentações e tutoriais externos consultados.
* `Manual Básico de Rotinas`: Manual detalhado com prints da aplicação em funcionamento.


## ▶️ Como Rodar o Projeto (Passo a Passo)

Siga estas instruções para configurar e executar a aplicação em seu ambiente local.

### **Pré-requisitos:**

* `Node.js` (versão LTS recomendada) e `npm` (gerenciador de pacotes).
* `Angular CLI` (instalado globalmente via `npm install -g @angular/cli@17`).
* `.NET SDK 8.0` (ou superior).
* `Visual Studio 2022 Community`.
* `SQL Server Management Studio (SSMS)` e uma instância de `SQL Server Express`.

### **1. Configurar o Banco de Dados:**

1.  Abra o `SQL Server Management Studio (SSMS)`.
2.  Conecte-se à sua instância do SQL Server (ex: `localhost\SQLEXPRESS` ou `[NOME_DO_SEU_PC]\SQLEXPRESS`).
3.  Crie um novo banco de dados chamado `estudantes_db`.
4.  Abra uma nova consulta no `estudantes_db` e execute os scripts `estudantes.sql` e `estudantenotas.sql` localizados na pasta `Database/`.
    * Os scripts criarão as tabelas `Estudantes` e `EstudanteNotas`.

### **2. Iniciar o Back-End (API ASP.NET Core):**

1.  Abra a solução `Backend/EstudantesApi/EstudantesApi.sln` no Visual Studio 2022.
2.  Pressione `F5` (ou clique no botão 'Play') para compilar e iniciar a API.
3.  A API será executada e exibirá as portas de acesso no console (ex: `https://localhost:7249`). A interface do Swagger UI (ex: `https://localhost:7249/swagger`) será aberta no navegador para testes. **Mantenha esta janela aberta.**

### **3. Iniciar o Front-End (Aplicativo Angular):**

1.  Abra um terminal (Git Bash/MINGW64 é recomendado).
2.  Navegue até a pasta raiz do projeto Angular: `cd Frontend/estudantes-app`.
3.  Na primeira vez (ou se a pasta `node_modules` for excluída), execute `npm install` para instalar as dependências.
4.  Execute `ng serve --open` para compilar e iniciar o servidor de desenvolvimento.
5.  O aplicativo Angular será aberto no navegador (geralmente em `http://localhost:4200`). **Mantenha este terminal aberto.**

### **4. Interagir com a Aplicação:**

1.  Com Back-End e Front-End rodando, acesse `http://localhost:4200` no seu navegador.
2.  Utilize o formulário para cadastrar estudantes e suas notas.
3.  Observe as mensagens de sucesso ou erro (via `alert()` e console do navegador).
4.  (Opcional) Verifique no SQL Server Management Studio se os dados foram persistidos.

## 💡 Aprendizados e Considerações Finais

Este projeto foi uma jornada de aprendizado intenso, especialmente na integração FullStack. Dentre os principais pontos, destaco:

* **Separação de Responsabilidades (MVC):** A importância de dividir a lógica entre Controller e Service para um código limpo e testável.
* **Injeção de Dependência:** Como o .NET Core e o Angular gerenciam as dependências, facilitando a modularidade.
* **Comunicação API (CORS):** A necessidade crítica de configurar o CORS no Back-End para permitir requisições de outras origens.
* **Depuração de Ambiente:** A resiliência necessária para depurar problemas complexos de configuração (como os erros de `tsconfig` e `node_modules` no Angular), que são comuns no desenvolvimento real.
* **Uso de IA como Ferramenta:** A eficácia de utilizar ferramentas de IA como o Gemini para depuração e compreensão de conceitos, acelerando o aprendizado e a resolução de problemas.

Agradeço a oportunidade de demonstrar minhas habilidades e minha paixão por aprender e resolver problemas.
