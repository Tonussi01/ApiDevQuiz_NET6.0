# API DevQuiz

A **API DevQuiz** é um serviço RESTful que fornece perguntas aleatórias para um quiz. Esta API é ideal para criar quizzes interativos e dinâmicos em aplicações web.

## Disponivel em
https://apidevquiznet60-production.up.railway.app/api/question

## Índice

- [Visão Geral](#visão-geral)
- [Funcionalidades](#funcionalidades)
- [Instalação](#instalação)
- [Uso](#uso)
- [Endpoints](#endpoints)
- [Modelo de Dados](#modelo-de-dados)
- [Exemplos](#exemplos)
- [Licença](#licença)

## Visão Geral

A API DevQuiz fornece um endpoint que retorna uma pergunta aleatória com múltiplas opções de resposta. A API é desenvolvida utilizando ASP.NET Core e pode ser facilmente configurada e integrada em projetos de desenvolvimento.

## Funcionalidades

- Retorna uma pergunta aleatória com opções de resposta.
- Responde a solicitações GET para fornecer perguntas.
- Utiliza um arquivo JSON para armazenar as perguntas e opções.

## Instalação

Para executar a API DevQuiz localmente, siga os passos abaixo:

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/Tonussi01/ApiDevQuiz_NET6.0

  2. **Navegue até o diretório do projeto:**
     
     ```bash
     cd ApiDevQuiz
     
  3. **Restaurar pacotes:**
      ```bash
      dotnet restore

 4. **Executar a API:**
      ```bash
      cd ApiDevQuiz

A API será iniciada e estará disponível no endereço https://localhost:5001 por padrão.

## Uso
Após iniciar a API, você pode acessar o endpoint para obter uma pergunta aleatória.

 1. **Endpoint**
 
        GET /api/question

    Retorna uma pergunta aleatória com o seguinte formato JSON:
    ```bash
    {
      "id": 16,
      "question": "Em .Net, um cache de tabelas em memória obtidas de um bd relacional ou de um doc XML é",
      "optionA": "um DAL.",
      "optionB": "um DataSet.",
      "optionC": "uma Entidade de dados.",
      "optionD": "uma Entidade Externa.",
      "optionE": "um ClassSet.",
      "correctAnswer": "b"
    }

## Licença

Distribuído sob a licença MIT.
