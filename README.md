# .NET Microservice Setup

Dette projekt består af **2 microservices** og en **API gateway**.  
README’en fokuserer på hvordan du anvender systemet gennem **Postman**.

## Information om systemet

## Struktur
| Komponent            | Beskrivelse                 | Port	  |
|----------------------|-----------------------------|--------|
| ProductMicroservice  | Håndtere produkt funktioner | `5002` |
| AuthMicroservice     | Håndtere bruger funktioner  | `5001` |
| Gateway (YARP)       | Routing mellem services     | `5000` |

## Postman

For at bruge dette system skal du anvende **Postman**, da der ikke er noget UI tilknyttet systemet.  

# AuthMicroservice

**AuthMicroservice** bruges til at håndtere alt, der vedrører brugere og godkendelse af logins.  
Den står for oprettelse af nye brugere og validering af brugeroplysninger ved login.

## Register

For at oprette en bruger i systemt skal du bruge:
`http://localhost:8080/api/user/register`

Metoden skal sættes til **POST**, og i **Body** skal du indsætte følgende JSON:
```
{
  "username": "User1",
  "password": "User1"
}
```
Grunden til, at det ovenfor skal indsættes i body’en, er, at metoden i API’en er markeret med `[FromBody]`.  
Det betyder, at API’en skal læse dataen fra body’en og ikke fra parametre i URL’en.

## Login
Den samme fremgangsmåde bruges til login, men kaldet ændres til:
`http://localhost:8080/api/user/login`

# ProductMicroservice

**ProductMicroservice** bruges til at håndtere alt vedrørende produkter.  
Den kan tilføje nye produkter, hente enkeltprodukter og hente et bestemt antal produkter opdelt på sider,  
f.eks. til en hjemmeside eller andre systemer.  

## Add
For at oprette et produkt i systemet skal dette kald bruges:
`http://localhost:8080/api/product/add`

Metoden skal sættes til **POST**, og i **Body** skal du indsætte følgende JSON:
```
{
    "productName": "SmartBook X1",
    "productDescription": "Something",
    "productCategory": "Laptops",
    "productPrice": 1299.99,
    "productImageUrl": "hello"
}
```
Dette er den samme fremgangsmåde, som blev brugt til **Register** og **Login**.

## Get
For at hente et produkt fra systemet skal du bruge dette kald: `http://localhost:8080/api/product/get/X`  

Metoden sættes til **GET**

`X` repræsenterer produktets id. I stedet for at skrive "id" direkte i kaldet indsætter du et tal.  
Hvis du for eksempel vil hente det produkt, du lige har oprettet, indsætter du 61 på `X`’s plads.
Dette er fordi metoden i API’en bruger `[HttpGet("{id}")]`.  

Derfor skal id angives direkte i URL’en, i stedet for som en parameter, f.eks.: `http://localhost:8080/api/product/get?id=1`

## Get/Pages
I dette system kan du hente produkter til en side med: `api/product/get/pages?page=1&pageSize=20&category=`.  

Metoden skal igen sættes til **GET**.

Her bruges parametre til at sende data, fordi metoden er markeret med `[FromQuery]`.
For at hente f.eks. 20 produkter pr. side udfylder du parametrene i Postman på denne måde:

<img width="524" height="154" alt="image" src="https://github.com/user-attachments/assets/35f70f3a-d5dd-498e-8945-e6715a631410" />

