## EndPoints do projeto

> Nota: `Se certifique de verificar o localhost do projeto. `

> Nota: `Certifique-se de verificar se está executando chamadas HTTPS ou HTTP`

| MÉTODO | ENDPOINT |
| ------ | ------ |
| [GET] Obter Dinheiro | "api/dinheiro" |
| [POST] Cadastrar Dinheiro | "api/dinheiro" |
| [POST] Cadastrar Vários | "api/dinheiro/varios" |

```sh
Uma vez que o localhost pode ser "https://localhost:44337", a chamada para o método [GET] Obter Dinheiro é https://localhost:44337/api/dinheiro
```

```sh
Caso esteja realizando chamadas HTTP pelo Postman, pode ser necessário desabilitar o certificado SSL do mesmo. 
Para isso siga os passos: Files - Settings - SSL certificate verification -> off
```


## Padrão do objeto Json esperado pela API

```sh
{
 "moeda": "USD",
 "data_inicio": "2010-01-01",
 "data_fim": "2010-12-01"
 }
```

## Caso queira inserir uma lista de objetos, é possível, basta chamar o endpoint "vários" 

[POST] localhost/api/dinheiro/varios

```sh
[
 {
 "moeda": "USD",
 "data_inicio": "2010-01-01",
 "data_fim": "2010-12-01"
 },
 {
 "moeda": "EUR",
 "data_inicio": "2020-01-01",
 "data_fim": "2010-12-01"
 },
 {
 "moeda": "JPY",
 "data_inicio": "2000-03-11",
 "data_fim": "2000-03-30"
 }
]
```

## Para executar o projeto Rotina, atente-se para mudar o valor da variável "URL" que está na classe "Program", variável esta necessária para chamada da API MOEDAS
Sua declaração está como: private const string URL = "https://localhost:44337/api/dinheiro";

Altere o localhost para o indicado

```sh
Com o projeto API MOEDA em execução, execute o projeto Rotina.
Caso queira parar a execução do projeto Rotina, aperta as teclas Ctrl + C.
```

## Execução do teste
> Após realizar as alterações necessárias no código, vistas acima basta executar o projeto Api Moeda
> 
> Em seguida execute o projeto Rotina
> 
> O projeto após alterado estará pronto para ser executado de uma maneira mais rápida
> 
> Uma vez que você pode já ter fechado os projetos, para reutilizá-los basta entrar na pasta ApiMoeda, executar o arquivo ApiMoeda.sln e iniciar a aplicação
> 
> Entrar na pasta Rotina, executar o arquivo Rotina.sln e iniciar a aplicação