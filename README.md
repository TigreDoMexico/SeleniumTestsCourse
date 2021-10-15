# Curso Selenium

Código do Curso de Selenium feito na Alura

## Como funciona
O Selenium é uma biblioteca para teste de usabilidade de sites. Através de um IWebDriver, a biblioteca abre um navegador e simula as ações de um usuário
Este projeto tem um sistema feito em DotNet Core 2.2 de leilões. A partir desse sistema, os testes do Selenium são feitos.

### Executando o Sistema de Leilões
:warning: Precisa ter o SQL Server instalado :warning:

Para rodar o sistema, é preciso primeiro atualizar o Banco de Dados com os Migrations existentes
Os migrations se encontram no projeto WebApp

Para executar os Migrations:
- Acesse o projeto WebApp via PowerShell ou PM Console
- Execute o comando abaixo

```bash
Update-Database

```

Apos isso, execute o projeto WebApp

```bash
dotnet run

```

## Conceitos aprendidos
- Web Drivers
- Web Elements
- Selectors
- Product Objects
- Waiters
- Teste com Mobile

<pre>Código criado originalmente por Daniel Portugal</pre>
