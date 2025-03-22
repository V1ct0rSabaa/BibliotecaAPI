# Dependências do Projeto

Este projeto utiliza as seguintes dependências:

## Frameworks e Bibliotecas

### ASP.NET Core
- **Microsoft.AspNetCore.OpenApi** (v8.0.0): Biblioteca necessária para habilitar o OpenAPI no projeto, utilizada pelo Swagger para documentação da API.
- **Swashbuckle.AspNetCore** (v6.0.0): Biblioteca para integração com o Swagger, gerando a documentação automática da API.

### Entity Framework Core
- **Microsoft.EntityFrameworkCore** (v8.0.4): Biblioteca principal para interagir com o banco de dados via Entity Framework Core.
- **Microsoft.EntityFrameworkCore.SqlServer** (v8.0.3): Suporte a bancos de dados SQL Server (potencialmente desnecessário se não for usado).
- **Microsoft.EntityFrameworkCore.Design** (v8.0.3): Ferramentas de design e migração do Entity Framework Core.
- **Npgsql.EntityFrameworkCore.PostgreSQL** (v8.0.4): Suporte para o PostgreSQL no Entity Framework Core.

## Banco de Dados
- **PostgreSQL** versão **14.7.1**: Usado como banco de dados principal do projeto.
- **pgAdmin 4**: Ferramenta de administração do PostgreSQL para gerenciar e monitorar o banco de dados.

### Configuração de Banco de Dados
Este projeto utiliza **PostgreSQL 14.7.1** como banco de dados. Certifique-se de ter o PostgreSQL instalado e configurado corretamente, bem como o pgAdmin 4 para facilitar o gerenciamento do banco de dados.

### Arquitetura do projeto
Padrão de Arquitetura: **Model View Controller(MVC)**
Design Patterns:
- **Estruturais**: **Data Transfer Object(DTO)**
```
PrimeiraAPI/
│
├── Models/                           # Contém as classes de modelo de dados
│   ├── Author.cs                     
│   ├── Book.cs                       
│   └── Response.cs                   # Resposta HTTP para a API
│
├── DTO/                              # Contém os objetos de transferência de dados (DTOs)
│   ├── AuthorDTO/                    
│   │   ├── AuthorCreateDTO.cs        
│   │   └── AuthorUpdateDTO.cs        
│   └── BookDTO/                      
│       ├── BookCreateDTO.cs          
│       └── BookUpdateDTO.cs          
│
├── Controllers/                      
│   ├── AuthorController.cs           
│   └── BookController.cs             
│
├── Services/                         # Contém as regras de negócio
│   ├── AuthorServices/               # Serviços relacionados aos autores
│   │   └── AuthorService.cs
│   └── BookServices/                 # Serviços relacionados aos livros
│       └── BookService.cs
│
├── Data/                             # Contém a configuração do banco de dados
│   └── AppDbContext.cs               # Contexto do banco de dados (EF Core)
│
├── Migrations/                       # Contém as migrações do banco de dados
│   └── [Migrations Arquivos]         # Arquivos gerados pelas migrações do EF Core
│
└── Program.cs                        # Arquivo de inicialização e configuração da API
```
Aqui está a documentação dos endpoints para os controladores `BookController` e `AuthorController` no formato Markdown:

### Endpoints da API

#### Gerenciamento de Livros - **BookController**

1. **Listar Todos os Livros**
   - **Método:** `GET /api/book/ListBooks`
   - **Descrição:** Recupera uma lista de todos os livros.
   - **Resposta:**
     - `200 OK`: Retorna a lista de livros.
   - **Exemplo de Resposta:**
   ```json
   [
     {
       "id": 1,
       "title": "Livro Exemplo",
       "authorId": 1,
       "publicationYear": 2021
     }
   ]
   ```

2. **Obter Livro por ID**
   - **Método:** `GET /api/book/GetBookById/{id}`
   - **Descrição:** Recupera um livro com o ID especificado.
   - **Parâmetros:**
     - `id`: O ID do livro a ser recuperado.
   - **Resposta:**
     - `200 OK`: Retorna o livro com o ID especificado.
     - `404 Not Found`: Se o livro não for encontrado.
   - **Exemplo de Resposta:**
   ```json
   {
     "id": 1,
     "title": "Livro Exemplo",
     "authorId": 1,
     "publicationYear": 2021
   }
   ```

3. **Obter Livro por ID do Autor**
   - **Método:** `GET /api/book/GetBookByAuthorId/{authorId}`
   - **Descrição:** Recupera um livro baseado no ID do autor.
   - **Parâmetros:**
     - `authorId`: O ID do autor para o qual o livro será recuperado.
   - **Resposta:**
     - `200 OK`: Retorna o livro associado ao ID do autor especificado.
     - `404 Not Found`: Se nenhum livro for encontrado para o autor.
   - **Exemplo de Resposta:**
   ```json
   {
     "id": 1,
     "title": "Livro Exemplo",
     "authorId": 1,
     "publicationYear": 2021
   }
   ```

4. **Criar um Novo Livro**
   - **Método:** `POST /api/book/CreateBook`
   - **Descrição:** Cria um novo livro.
   - **Parâmetros:**
     - `bookDTO`: Objeto contendo os dados do livro.
   - **Resposta:**
     - `201 Created`: Retorna o livro criado.
     - `400 Bad Request`: Se os dados fornecidos forem inválidos.
   - **Exemplo de Payload:**
   ```json
   {
     "title": "Novo Livro",
     "authorId": 2,
     "publicationYear": 2023
   }
   ```

5. **Atualizar um Livro Existente**
   - **Método:** `PUT /api/book/UpdateBook/{id}`
   - **Descrição:** Atualiza um livro existente.
   - **Parâmetros:**
     - `id`: O ID do livro a ser atualizado.
     - `bookDTO`: Objeto com os dados atualizados do livro.
   - **Resposta:**
     - `200 OK`: Retorna o livro atualizado.
     - `404 Not Found`: Se o livro não for encontrado.
   - **Exemplo de Payload:**
   ```json
   {
     "title": "Livro Atualizado",
     "authorId": 1,
     "publicationYear": 2022
   }
   ```

6. **Remover um Livro**
   - **Método:** `DELETE /api/book/RemoveBook/{id}`
   - **Descrição:** Remove um livro pelo seu ID.
   - **Parâmetros:**
     - `id`: O ID do livro a ser removido.
   - **Resposta:**
     - `200 OK`: Retorna a lista de livros restantes.
     - `404 Not Found`: Se o livro não for encontrado.

---

#### Gerenciamento de informações dos Autores - **AuthorController**

1. **Listar Todos os Autores**
   - **Método:** `GET /api/author/ListAuthors`
   - **Descrição:** Recupera uma lista de todos os autores.
   - **Resposta:**
     - `200 OK`: Retorna a lista de autores.
   - **Exemplo de Resposta:**
   ```json
   [
     {
       "id": 1,
       "name": "Autor Exemplo",
       "lastname": "Sobrenome Exemplo"
     }
   ]
   ```

2. **Obter Autor por ID**
   - **Método:** `GET /api/author/GetAuthorById/{id}`
   - **Descrição:** Recupera um autor pelo seu ID.
   - **Parâmetros:**
     - `id`: O ID do autor.
   - **Resposta:**
     - `200 OK`: Retorna o autor com o ID especificado.
     - `404 Not Found`: Se o autor não for encontrado.
   - **Exemplo de Resposta:**
   ```json
   {
     "id": 1,
     "name": "Autor Exemplo",
     "lastname": "Sobrenome Exemplo"
   }
   ```

3. **Obter Autor por ID de Livro**
   - **Método:** `GET /api/author/GetAuthorByBookId/{bookId}`
   - **Descrição:** Recupera o autor de um livro baseado no ID do livro.
   - **Parâmetros:**
     - `bookId`: O ID do livro para o qual o autor será recuperado.
   - **Resposta:**
     - `200 OK`: Retorna o autor associado ao livro.
     - `404 Not Found`: Se o autor não for encontrado.
   - **Exemplo de Resposta:**
   ```json
   {
     "id": 1,
     "name": "Autor Exemplo",
     "lastname": "Sobrenome Exemplo"
   }
   ```

4. **Criar um Novo Autor**
   - **Método:** `POST /api/author/CreateAuthor`
   - **Descrição:** Cria um novo autor.
   - **Parâmetros:**
     - `authorDTO`: Objeto contendo os dados do autor.
   - **Resposta:**
     - `201 Created`: Retorna a lista de autores atualizada após a criação.
     - `400 Bad Request`: Se os dados fornecidos forem inválidos.
   - **Exemplo de Payload:**
   ```json
   {
     "name": "Novo Autor",
     "lastname": "Sobrenome Novo"
   }
   ```

5. **Remover um Autor**
   - **Método:** `DELETE /api/author/RemoveAuthor/{id}`
   - **Descrição:** Remove um autor pelo seu ID.
   - **Parâmetros:**
     - `id`: O ID do autor a ser removido.
   - **Resposta:**
     - `200 OK`: Retorna a lista de autores restante.
     - `404 Not Found`: Se o autor não for encontrado.

6. **Atualizar um Autor Existente**
   - **Método:** `PUT /api/author/UpdateAuthor/{id}`
   - **Descrição:** Atualiza um autor existente.
   - **Parâmetros:**
     - `id`: O ID do autor a ser atualizado.
     - `authorDTO`: Objeto com os dados atualizados do autor.
   - **Resposta:**
     - `200 OK`: Retorna a lista de autores atualizada.
     - `404 Not Found`: Se o autor não for encontrado.
   - **Exemplo de Payload:**
   ```json
   {
     "name": "Autor Atualizado",
     "lastname": "Sobrenome Atualizado"
   }
   ```

---
