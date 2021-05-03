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