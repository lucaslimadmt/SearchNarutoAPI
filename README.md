# SearchNarutoAPI

Aplicação web desenvolvida em **Blazor WebAssembly com .NET 10** para consultar personagens do universo Naruto por meio da **Dattebayo API**.

Este projeto foi realizado para a disciplina de Desenvolvimento Web, com o objetivo de praticar consumo de APIs REST, uso do HttpClient e exibição de dados em componentes Blazor.

## Funcionalidades

- Listar os personagens retornados pela API.
- Pesquisar personagens pelo nome (por exemplo: Naruto, Sasuke ou Sakura).
- Exibir nome, imagem, clã ou afiliação e patente ninja.
- Consultar a lista de jutsus de cada personagem.
- Navegar entre páginas de resultados.
- Informar quando não há resultados, imagens ou dados disponíveis.
- Exibir uma mensagem amigável caso a consulta falhe.

## Tecnologias utilizadas

| Tecnologia | Utilização |
| --- | --- |
| C# e .NET 10 | Linguagem e plataforma do projeto |
| Blazor WebAssembly | Interface web executada no navegador |
| HttpClient | Requisições HTTP à API |
| System.Text.Json | Leitura dos dados JSON |
| HTML e CSS | Estrutura, estilo e responsividade |

## Como executar

**Pré-requisito:** ter o [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0) instalado.

1. Clone este repositório:

   ```bash
   git clone https://github.com/lucaslimadmt/SearchNarutoAPI.git
   ```

2. Entre na pasta do projeto:

   ```bash
   cd SearchNarutoAPI
   ```

3. Restaure as dependências e execute a aplicação:

   ```bash
   dotnet restore
   dotnet run
   ```

4. Abra no navegador o endereço local mostrado no terminal (configuração inicial: `http://localhost:5110`).

Também é possível abrir o arquivo `SearchNarutoAPI.csproj` no Visual Studio 2022/2026 com suporte ao .NET 10.

## Como usar

Ao abrir o site, os personagens são carregados da API. Para fazer uma pesquisa, digite o nome de um personagem e clique em **Buscar** ou pressione Enter. Também existem botões de busca rápida.

Os cartões mostram os dados principais. Ao clicar em **Ver lista de jutsus**, é possível conferir os jutsus fornecidos pela API. Os botões **Anterior** e **Próxima** permitem navegar entre as páginas. Para voltar à listagem geral, use **Limpar busca**.

## Integração com a API

A aplicação utiliza a [Dattebayo API](https://api-dattebayo.vercel.app/docs), que fornece dados de personagens do universo Naruto.

**URL base:** `https://dattebayo-api.onrender.com`

| Requisição | Finalidade |
| --- | --- |
| `GET /characters?page=1&limit=12` | Listar a primeira página de personagens |
| `GET /characters?page=1&limit=12&name=Naruto` | Buscar personagens pelo nome |

A interface utiliza os campos `name`, `images`, `personal.clan` ou `personal.affiliation`, `jutsu` e `rank.ninjaRank`, conforme o enunciado da atividade. Como alguns personagens têm dados incompletos, os campos ausentes são tratados sem interromper a exibição.

## Estrutura do projeto

```text
SearchNarutoAPI/
├── Components/
│   └── CharacterCard.razor
├── Models/
│   ├── CharactersResponse.cs
│   └── NarutoCharacter.cs
├── Pages/
│   └── Home.razor
├── Properties/
│   └── launchSettings.json
├── Services/
│   └── NarutoApiService.cs
├── wwwroot/
│   ├── css/app.css
│   ├── favicon.svg
│   └── index.html
├── App.razor
├── Program.cs
├── _Imports.razor
└── SearchNarutoAPI.csproj
```

## Observações

- O projeto precisa de conexão com a internet para consultar os personagens.
- A API é um serviço externo e pode levar alguns segundos para responder, principalmente na primeira solicitação.
- As imagens também são fornecidas por servidores externos; quando estiverem indisponíveis, o site mostra uma indicação no lugar da foto.
- Não é necessário cadastrar chave de API nem configurar um banco de dados local.

## Autor

**Lucas Eduardo Lima Demetrio**  
Engenharia de Software — Desenvolvimento Web

Projeto acadêmico desenvolvido para praticar os conceitos estudados na disciplina.
