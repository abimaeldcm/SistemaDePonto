# Sistema de Registro de Ponto de Funcionários - ASP.NET MVC

Bem-vindo ao repositório do Sistema de Registro de Ponto de Funcionários desenvolvido em ASP.NET MVC. Este sistema permite aos 
funcionários resgitrarem os seus ponto (entrada, pausa, volta da pausa e saída) e ver o histórico de marcações. Também permite aos administradores gerenciar o registro de pontos dos funcionários, criar contas de usuário, visualizar histórico e gerenciar informações dos funcionários.

## Funcionalidades

1. **Autenticação e Contas de Usuário:**
   - Os aministradores podem criar contas com informações como nome, login, e-mail, perfil. A senha será definida pelo usuário no momento do primeiro login.
   - Recuperação de senha através de um processo seguro de redefinição.

2. **Registro de Ponto:**
   - Os funcionários podem marcar seus pontos, indicando entrada, pausas e saída.
   - Os pontos são registrados com a data e hora correspondentes.

3. **Histórico de Pontos:**
   - Os funcionários podem visualizar o seu histórico de marcações e os administradores podem visualizar o histórico de pontos de cada funcionário.
   - O histórico exibe datas e horas das marcações.

4. **Gerenciamento de Funcionários:**
   - Os administradores têm permissão para gerenciar informações de funcionários.
   - Opções incluem criar, alterar, visualizar informações e excluir funcionários.

## Tecnologias Utilizadas

- ASP.NET MVC: Um framework da Microsoft para desenvolvimento web.
- Entity Framework: Biblioteca para mapeamento objeto-relacional e acesso a banco de dados.
- SQL Server: Banco de dados relacional para armazenamento de dados.
- HTML, CSS e JavaScript: Para a interface do usuário e interações.

## Pré-requisitos

- Visual Studio 2022 (ou superior) instalado.
- SQL Server instalado e configurado.
- Pacotes NuGet do Entity Framework instalados.
   - Design
   - SqlServer
   - Tools
   - Newtonsoft.Json

## Configuração do Banco de Dados

1. Abra o SQL Server Management Studio e crie um novo banco de dados chamado "Ponto".
2. Execute os scripts SQL fornecidos para criar as tabelas necessárias.

## Configuração da Aplicação

1. Clone este repositório em sua máquina local.
2. Abra o projeto no Visual Studio.
3. Abra o arquivo `appsettings.json` e atualize a string de conexão com o banco de dados.

*Configure de acordo com a strings de conexão do seu banco de dados

4. Execute o comando `Update-Database` no Console do Gerenciador de Pacotes para aplicar as migrações ao banco de dados.

## Executando a Aplicação

1. Compile o projeto no Visual Studio.
2. Execute a aplicação em seu navegador.
3. Navegue pelas diferentes funcionalidades do sistema.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para fazer um fork deste repositório, implementar melhorias e enviar um pull request.
