# API-C#

SDK da plataforma de pagamento Apus. 
* Language: C#

## Principais recursos

* [x] Pagamentos por cartão.
* [ ] Pagamentos recorrentes.
* [ ] Pagamentos por transferência.
* [ ] Consulta de pagamentos.

<hr>

## Blockchains suportadas

| Blockchain       | Constante              | Recorrente |
|------------------|------------------------|------------|
| Bitcoin          | Blockchain::BTC        | Sim        |
| Decred           | CreditCard::DCR        | Sim        |
| Ethereum         | CreditCard::ETH        | Sim        |
| Litecoin         | CreditCard::LTC        | Sim        |

<hr>

## Pagamentos por cartão.

Pagamentos utilizando número do cartão e senha

### Requisição

> POST https://api.apus.exchange/v1/pay/

```c#
{
  "card": "0000111122223333",
  "password": "*******",
  "type": Blockchain.BTC,
  "amount": 10.00,
  "currency": "BRL"
}
```
 
### Resposta

```c#
{
    "status": true,
    "message": "Pagamento aprovado",
    "txid": "d5a82f2e8469b1d30a98cbca29c40cb732c46c6b19ab729e1785806237417153",
    "data": {
        "serial": "A666A",
        "buyer": "João Comprador"
    }
}
```
