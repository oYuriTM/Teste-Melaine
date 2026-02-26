 Client CRUD API

API REST desenvolvida em .NET 7 + Entity Framework Core + SQL Server para gerenciamento de clientes.

 Como Rodar o Projeto
 Atualizar o Banco de Dados

Antes de tudo, adicionar ConnectionString na classe "DataContextFactory"

Dentro da pasta do projeto da API, execute:

dotnet ef database update
 Executar a API
dotnet run
 Swagger

Após rodar o projeto, acesse no navegador:

https://localhost:5001/swagger

(O endereço pode variar conforme a porta exibida no terminal)

 Endpoints
-+ Criar Cliente

POST /api/client

{
  "name": "John Silva",
  "email": "john@email.com",
  "phone": "(21) 99999-9999",
  "cep": "01001000",
  "number": "123",
  "complement": "Apt 101"
}
-+ Atualizar Cliente

PUT /api/client

{
  "id": 1,
  "name": "John Updated",
  "email": "new@email.com",
  "phone": "21999999999",
  "cep": "20040002",
  "number": "456",
  "complement": "House"
}
-+ Listar Todos

GET /api/client

-+ Buscar por Id

GET /api/client/{id}

-+ Deletar

DELETE /api/client/{id}
