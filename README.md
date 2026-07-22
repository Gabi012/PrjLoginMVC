# ASP.NET Core MVC Authentication com Cookies e Roles (.NET 8)

Projeto de demonstração desenvolvido em **ASP.NET Core MVC (.NET 8)** para estudo de autenticação utilizando **Cookies Authentication**, **Claims** e **Roles**, sem utilizar o ASP.NET Core Identity.

O objetivo é entender como funciona a autenticação nativa do ASP.NET Core, implementando manualmente todo o fluxo de login, autorização e controle de acesso.

---

## Objetivos do Projeto

- Entender o funcionamento da autenticação por Cookies.
- Implementar Login e Logout sem utilizar Identity.
- Criar controle de acesso baseado em Roles.
- Aprender o funcionamento das Claims.
- Proteger Controllers e Actions utilizando Authorization.
- Organizar o projeto utilizando boas práticas.

---

## Tecnologias

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Cookie Authentication
- Claims
- Authorization
- Bootstrap 5

---

## Conceitos estudados

### Autenticação

Implementação utilizando:

```csharp
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(...);
```

Foi estudado:

- Como o middleware funciona
- Login
- Logout
- Expiração do Cookie
- Sliding Expiration
- Login Persistente ("Lembrar-me")
- Cookies seguros

---

### Authorization

Utilização dos atributos:

```csharp
[Authorize]
```

e

```csharp
[Authorize(Roles = "Admin")]
```

para proteger páginas específicas.

---

### Claims

Durante o login são criadas as Claims do usuário:

```csharp
new Claim(ClaimTypes.Name, user.Username)
new Claim(ClaimTypes.Role, user.Role)
new Claim("UserId", user.Id.ToString())
```

Essas informações são gravadas dentro do Cookie de autenticação.

Após isso ficam disponíveis em qualquer Controller ou View através de:

```csharp
User.Identity.Name
User.IsInRole("Admin")
User.FindFirst("UserId")
```

---

### Cookie Authentication

Ao realizar o Login:

```
Usuário
      │
      ▼
Validação no Banco
      │
      ▼
Criação das Claims
      │
      ▼
SignInAsync()
      │
      ▼
Cookie criptografado
      │
      ▼
Navegador
```

Nas próximas requisições:

```
Browser
      │
Cookie
      │
      ▼
Middleware Authentication
      │
      ▼
HttpContext.User
```

Sem necessidade de consultar o banco de dados a cada requisição.

---

## Funcionalidades

- Cadastro de usuários
- Login
- Logout
- Lembrar-me
- Área protegida
- Área exclusiva para Administradores
- Controle por Roles
- Mensagens utilizando TempData

---

## Estrutura do Projeto

```
Controllers
│
├── AccountController
├── HomeController
└── AdminController

Models
│
├── User
├── LoginViewModel
└── RegisterViewModel

Services
│
└── PasswordHasher

Views
│
├── Account
├── Home
└── Admin

wwwroot
```

---


## Roles

Cada usuário possui uma Role, por exemplo:

- Admin
- User

Durante a autenticação a Role é adicionada como Claim:

```csharp
new Claim(ClaimTypes.Role, user.Role)
```

Permitindo utilizar:

```csharp
User.IsInRole("Admin")
```

ou

```csharp
[Authorize(Roles = "Admin")]
```


